using ApplicationLayer.Models;
using ApplicationLayer.Models.Partial;
using Business_Layer.Services;
using DataLayer.Data;
using DataLayer.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ApplicationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ServiceDrink _serviceDrink;
        private readonly ApplicationDbContext _context;

        public HomeController(ServiceDrink serviceDrink, ApplicationDbContext context)
        {
            _serviceDrink = serviceDrink;
            _context = context;
        }

        public IActionResult Index()
        {
            //Seed();

            var drinks = _serviceDrink.Take(7, true);
            var featuredDrinksViewModel = new DrinksFeaturedViewModel
            {
                Title = "Omtyckta Drinkar",
                Description = "Vi tycker att det ska vara lätt att hitta det man letar efter, inget tjafs! Med det i åtanke så har vi samlat de populäraste drinkarna på ett och samma ställe!",
                Drinks = drinks
            };

            var homeViewModel = new HomeViewModel
            {
                DrinksFeaturedViewModel = featuredDrinksViewModel,
            };

            //return View();
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }

        private void Seed()
        {
            var path = "D:\\Workspace\\HenrikEget\\Projekt\\Webbutveckling\\YourDrinkingPalWeb\\BusinessLayer\\Data\\Recept.json";
            var pathUnits = "D:\\Workspace\\HenrikEget\\Projekt\\Webbutveckling\\YourDrinkingPalWeb\\BusinessLayer\\Data\\Recept-units.json";
            using StreamReader reader = new(path);
            using StreamReader readerTwo = new(pathUnits);
            var json = reader.ReadToEnd();
            var jsonTwo = readerTwo.ReadToEnd();
            List<dtoDrink> drinksDto = JsonConvert.DeserializeObject<List<dtoDrink>>(json);
            List<dtoUnits> unitsDto = JsonConvert.DeserializeObject<List<dtoUnits>>(jsonTwo);

            var drinks = new List<Drink>();

            foreach (var item in drinksDto)
            {
                if (_context.Drink.FirstOrDefault(o => o.Name == item.Name) != null) continue;
                try
                {
                    var splittTools = item.Tools.Trim().ToLower().Split(", ");
                    List<Tool> tools = new List<Tool>();
                    foreach (var toolStr in splittTools)
                    {
                        var toolDb = _context.Tool.FirstOrDefault(o => o.Name == toolStr);

                        if (toolDb == null)
                        {
                            var newTool = new Tool
                            {
                                Name = toolStr,
                            };

                            _context.Tool.Add(newTool);
                            toolDb = newTool;
                        }

                        tools.Add(toolDb);
                    }
                    _context.SaveChanges();

                    var splittStep = item.Steps.Split("\n");
                    var instructions = new List<Instruction>();
                    for (int i = 1; i <= splittStep.Length; i++)
                    {
                        instructions.Add(new Instruction
                        {
                            Position = i,
                            Description = splittStep[i - 1]
                        });
                    };

                    var relUnits = unitsDto.Where(o => o.Name == item.Name).ToList();
                    var relUnitsDist = Math.Sqrt(relUnits.Count);

                    var stop = 1;

                    var measurements = new List<Measurement>();

                    var countUnit = 0;
                    while (countUnit * relUnitsDist < relUnits.Count)
                    {
                        dtoUnits ingr = relUnits[(countUnit * (int)relUnitsDist) + countUnit];
                        countUnit++;

                        ////////
                        Ingridient ingredient = new Ingridient();
                        var splittTest = ingr.Field3.Split("\n");
                        if (splittTest.Length > 1) ingr.Field3 = splittTest[0];

                        ingredient = _context.Ingridient.FirstOrDefault(o => o.Name == ingr.Field3);

                        if (ingredient == null)
                        {
                            var newIngredient = new Ingridient
                            {
                                Name = ingr.Field3,
                            };

                            _context.Ingridient.Add(newIngredient);
                            ingredient = newIngredient;
                            _context.SaveChanges();
                        }

                        ////////
                        decimal amount = 0;
                        Unit unit = null;

                        if (!string.IsNullOrEmpty(ingr.Field4))
                        {
                            // 7 cl
                            // 10-12 st
                            var splitUnit = ingr.Field4.Split(" ");
                            if (splitUnit.Length == 1)
                            {
                                break;
                            }
                            else if (splitUnit.Length == 2)
                            {
                                var amountStr = splitUnit[0];
                                if (amountStr.Split("-").Length > 1)
                                {
                                    amount = decimal.Parse(amountStr.Split("-")[0]) + 1;
                                }
                                else
                                {
                                    amount = decimal.Parse(amountStr);
                                }

                                var unitStr = splitUnit[1];
                                unit = _context.Unit.FirstOrDefault(o => o.Name == unitStr);
                                if (unit == null)
                                {
                                    var newUnit = new Unit
                                    {
                                        Name = unitStr,
                                    };

                                    _context.Unit.Add(newUnit);
                                    unit = newUnit;
                                }
                                _context.SaveChanges();
                            }
                            else
                            {
                                break;
                            }
                        }
                        else if (string.IsNullOrEmpty(ingr.Field4))
                        {
                            unit = _context.Unit.FirstOrDefault(o => o.Name == "");
                            if (unit == null)
                            {
                                var newUnit = new Unit
                                {
                                    Name = "",
                                };

                                _context.Unit.Add(newUnit);
                                unit = newUnit;
                            }
                            _context.SaveChanges();
                        }

                        measurements.Add(new Measurement
                        {
                            Ingridient = ingredient,
                            Unit = unit,
                            Amount = amount,
                        });
                    }

                    var recipe = new Recipe
                    {
                        Measurements = measurements,
                        Instructions = instructions,
                        Garnish = item.Garnish
                    };

                    var tag = _context.Tag.FirstOrDefault(o => o.Name == item.Tag);
                    if (tag == null)
                    {
                        var newTag = new Tag
                        {
                            Name = item.Tag,
                        };

                        _context.Tag.Add(newTag);
                        tag = newTag;
                    }
                    _context.SaveChanges();

                    var flavour = _context.Flavour.FirstOrDefault(o => o.Name == item.Flavour);
                    if (flavour == null)
                    {
                        var newflavour = new Flavour
                        {
                            Name = item.Flavour,
                        };

                        _context.Flavour.Add(newflavour);
                        flavour = newflavour;
                    }
                    _context.SaveChanges();

                    var glass = _context.Glass.FirstOrDefault(o => o.Name == item.Glass);
                    if (glass == null)
                    {
                        var newglass = new Glass
                        {
                            Name = item.Glass,
                        };

                        _context.Glass.Add(newglass);
                        glass = newglass;
                    }
                    _context.SaveChanges();

                    var drink = new Drink
                    {
                        Name = item.Name,
                        UrlSlug = item.Name.ToLower().Trim().Replace(" ", "-"),
                        Description = item.Description,
                        Tag = tag,
                        Flavour = flavour,
                        Recipe = recipe
                    };

                    drink.Recipe.Glass = glass;
                    drink.Recipe.Equipment = tools;

                    _context.Drink.Add(drink);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }
    }
}

public class dtoDrink
{
    public string Tag { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Flavour { get; set; }
    public string Glass { get; set; }
    public string Tools { get; set; }
    public string Ingridients { get; set; }
    public string Steps { get; set; }
    public string Garnish { get; set; }
}

public class dtoUnits
{
    public string Name { get; set; }
    public string Field3 { get; set; }
    public string Field4 { get; set; }
}