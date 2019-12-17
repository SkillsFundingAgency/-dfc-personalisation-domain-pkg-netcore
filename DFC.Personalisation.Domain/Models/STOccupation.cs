using System;

namespace DFC.Personalisation.Domain.Models
{
    public class STOccupation
    {
        public string Occupation { get; set; }
        public string[] AlternativeLabels { get; set; }
        public DateTime LastModified { get; set; }
        public string Uri { get; set; }
    }
}
