using System.Collections.ObjectModel;

namespace BusinessLayer.Models.DTO
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public int GlassId { get; set; }
        public GlassDto? Glass { get; set; } = new GlassDto();
        public List<ToolDto> Equipment { get; set; } = new List<ToolDto>();
        public List<MeasurementDto> Measurements { get; set; } = new List<MeasurementDto>();
        public List<InstructionDto> Instructions { get; set; } = new List<InstructionDto>();
        public string Garnish { get; set; }
    }
}