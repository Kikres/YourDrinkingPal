using BusinessLayer.Services;

namespace BusinessLayer
{
    public class Service
    {
        public ServiceColor Color { get; }
        public ServiceDrink Drink { get; }
        public ServiceFlavour Flavour { get; }
        public ServiceGarnish Garnish { get; }
        public ServiceGeneratedImage GeneratedImage { get; }
        public ServiceGlass Glass { get; }
        public ServiceIngridient Ingridient { get; }
        public ServiceInstruction Instruction { get; }
        public ServiceMeasurement Measurement { get; }
        public ServiceRecipe Recipe { get; }
        public ServiceStyle Style { get; }
        public ServiceTag Tag { get; }
        public ServiceTool Tool { get; }
        public ServiceTransparency Transparency { get; }
        public ServiceUnit Unit { get; }
        public ServiceUploadedImage UploadedImage { get; }

        public Service(ServiceColor color, ServiceDrink drink, ServiceFlavour flavour, ServiceGarnish garnish, ServiceGeneratedImage generatedImage, ServiceGlass glass, ServiceIngridient ingridient, ServiceInstruction instruction, ServiceMeasurement measurement, ServiceRecipe recipe, ServiceStyle style, ServiceTag tag, ServiceTool tool, ServiceTransparency transparency, ServiceUnit unit, ServiceUploadedImage uploadedImage)
        {
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
            UploadedImage = uploadedImage;
        }
    }
}