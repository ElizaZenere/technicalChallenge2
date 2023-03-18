namespace technicalChallenge.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class NameModel
    {
        public string Name { get; set; }

    }


}