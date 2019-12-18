using System;

namespace DFC.Personalisation.Domain.Models
{
    public class Occupation
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string[] AlternativeNames { get; private set; }
        public DateTime LastModified { get; private set; }

        public Occupation(string id, string name, DateTime lastModified)
        {
            if (string.IsNullOrWhiteSpace((id)))
                throw new ArgumentNullException(nameof(id), "Id must be specified.");
            if (string.IsNullOrWhiteSpace((name)))
                throw new ArgumentNullException(nameof(name), "Occupation name must be specified.");
            Id = id;
            Name = name;
            LastModified = lastModified;
            AlternativeNames = new string[0];
        }

        public Occupation(string id, string name, DateTime lastModified, string[] alternativeNames)
        {
            if (string.IsNullOrWhiteSpace((id)))
                throw new ArgumentNullException(nameof(id), "Id must be specified.");
            if (string.IsNullOrWhiteSpace((name)))
                throw new ArgumentNullException(nameof(name), "Occupation name must be specified.");
            if (null == alternativeNames || 0 == alternativeNames.Length)
                throw new ArgumentNullException(nameof(alternativeNames), "Alternative names must be specified.");
            foreach (var alternativeName in alternativeNames)
            {
                if (string.IsNullOrWhiteSpace(alternativeName)) throw new ArgumentNullException(nameof(alternativeNames), "Missing or empty value in alternativeNames array.");
            }
            Id = id;
            Name = name;
            LastModified = lastModified;
            AlternativeNames = (string[])alternativeNames.Clone();
        }
    }
}
