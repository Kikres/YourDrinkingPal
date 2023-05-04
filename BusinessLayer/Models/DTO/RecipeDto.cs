﻿using System.Collections.ObjectModel;

namespace BusinessLayer.Models.DTO
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public List<ToolDto> Equipment { get; set; }
        public List<MeasurementDto> Measurements { get; set; }
        public List<InstructionDto> Instructions { get; set; }
    }
}