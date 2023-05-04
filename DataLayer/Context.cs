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

        public Context(IRepositoryUploadedImage uploadedImage, IRepositoryColor color, IRepositoryDrink drink, IRepositoryFlavour flavour, IRepositoryGarnish garnish, IRepositoryGeneratedImage generatedImage, IRepositoryGlass glass, IRepositoryIngridient ingridient, IRepositoryInstruction instruction, IRepositoryMeasurement measurement, IRepositoryRecipe recipe, IRepositoryStyle style, IRepositoryTag tag, IRepositoryTool tool, IRepositoryTransparency transparency, IRepositoryUnit unit)
        {
            UploadedImage = uploadedImage;
            Color = color;
            Drink = drink;
            Flavour = flavour;
            Garnish = garnish;
            GeneratedImage = generatedImage;
            Glass = glass;
            Ingridient = ingridient;
            Instruction = instruction;
            Measurement = measurement;
            Recipe = recipe;
            Style = style;
            Tag = tag;
            Tool = tool;
            Transparency = transparency;
            Unit = unit;
        }
    }
}