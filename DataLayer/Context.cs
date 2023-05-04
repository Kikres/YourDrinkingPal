using DataLayer.Data;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IContext
    {
        IRepositoryColor Color { get; }
        IRepositoryDrink Drink { get; }
        IRepositoryFlavour Flavour { get; }
        IRepositoryGarnish Garnish { get; }
        IRepositoryGeneratedImage GeneratedImage { get; }
        IRepositoryGlass Glass { get; }
        IRepositoryIngridient Ingridient { get; }
        IRepositoryInstruction Instruction { get; }
        IRepositoryMeasurement Measurement { get; }
        IRepositoryRecipe Recipe { get; }
        IRepositoryStyle Style { get; }
        IRepositoryTag Tag { get; }
        IRepositoryTool Tool { get; }
        IRepositoryTransparency Transparency { get; }
        IRepositoryUnit Unit { get; }
        IRepositoryUploadedImage UploadedImage { get; }
    }

    public class Context : IContext
    {
        public Context(ApplicationDbContext context)
        {
            Color = new RepositoryColor(context);
            Drink = new RepositoryDrink(context);
            Flavour = new RepositoryFlavour(context);
            Garnish = new RepositoryGarnish(context);
            GeneratedImage = new RepositoryGeneratedImage(context);
            Glass = new RepositoryGlass(context);
            Ingridient = new RepositoryIngridient(context);
            Instruction = new RepositoryInstruction(context);
            Measurement = new RepositoryMeasurement(context);
            Recipe = new RepositoryRecipe(context);
            Style = new RepositoryStyle(context);
            Tag = new RepositoryTag(context);
            Tool = new RepositoryTool(context);
            Transparency = new RepositoryTransparency(context);
            Unit = new RepositoryUnit(context);
            UploadedImage = new RepositoryUploadedImage(context);
        }

        public IRepositoryColor Color { get; }
        public IRepositoryDrink Drink { get; }
        public IRepositoryFlavour Flavour { get; }
        public IRepositoryGarnish Garnish { get; }
        public IRepositoryGeneratedImage GeneratedImage { get; }
        public IRepositoryGlass Glass { get; }
        public IRepositoryIngridient Ingridient { get; }
        public IRepositoryInstruction Instruction { get; }
        public IRepositoryMeasurement Measurement { get; }
        public IRepositoryRecipe Recipe { get; }
        public IRepositoryStyle Style { get; }
        public IRepositoryTag Tag { get; }
        public IRepositoryTool Tool { get; }
        public IRepositoryTransparency Transparency { get; }
        public IRepositoryUnit Unit { get; }
        public IRepositoryUploadedImage UploadedImage { get; }
    }
}