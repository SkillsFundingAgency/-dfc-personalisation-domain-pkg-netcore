namespace DFC.Personalisation.Domain.Models
{
    public class Skill
    {
        public string skillType { get; set; }
        public string skill { get; set; }
        public string[] alternativeLabels { get; set; }
        public string uri { get; set; }
    }
}

