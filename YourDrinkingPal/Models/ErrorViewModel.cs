namespace ApplicationLayer.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        //public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
        public bool ShowRequestId => !string.IsNullOrEmpty("");
    }
}