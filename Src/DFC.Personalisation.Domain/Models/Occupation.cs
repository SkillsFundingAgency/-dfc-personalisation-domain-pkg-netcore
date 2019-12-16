namespace DFC.Personalisation.Domain.Models
{
    public class Occupation
    {
        public string occupation { get; set; }
        public string[] alternativeLabels { get; set; }
        public DateTime lastModified { get; set; }
        public string uri { get; set; }
    }
}
