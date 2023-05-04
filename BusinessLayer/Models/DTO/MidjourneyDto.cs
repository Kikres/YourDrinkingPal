using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.DTO
{
    public class MidjourneyDto
    {
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public List<string> Buttons { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ResponseAt { get; set; }
        public string Ref { get; set; }
        public string OriginatingMessageId { get; set; }
        public string ButtonMessageId { get; set; }
    }

    public class MidjourneyResponseDto
    {
        public bool Success { get; set; }
        public string MessageId { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class MidjourneyCreateDto
    {
        public string cmd { get; set; }
        public string msg { get; set; }
    }

    public class MidjourneyUpscaleDto
    {
        public string button { get; set; }
        public string buttonMessageId { get; set; }
        public string webhookOverride { get; set; }
        public string Ref { get; set; }
    }
}