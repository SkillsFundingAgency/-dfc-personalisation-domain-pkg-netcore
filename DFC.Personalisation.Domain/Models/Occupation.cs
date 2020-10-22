using System;
using System.Linq;

namespace DFC.Personalisation.Domain.Models
{
    public class Occupation
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string[] AlternativeNames { get; private set; }
        public DateTime LastModified { get; private set; }

        public string Description { get; private set; }
        public Occupation(string id, string name, DateTime lastModified, string description)
        {
            if (string.IsNullOrWhiteSpace((id)))
                throw new ArgumentNullException(nameof(id), "Id must be specified.");
            if (string.IsNullOrWhiteSpace((name)))
                throw new ArgumentNullException(nameof(name), "Occupation name must be specified.");
            Id = id;
            Name = name;
            LastModified = lastModified;
            AlternativeNames ??= new string[0];
            Description = description;
        }

        public Occupation(string id, string name, DateTime lastModified, string[] alternativeNames, string description)
            : this(id, name, lastModified, description)
        {
            if (null == alternativeNames || 0 == alternativeNames.Length)
                AlternativeNames = new string[0];
            else
            {
                if (alternativeNames.Any(alternativeName => string.IsNullOrWhiteSpace(alternativeName)))
                {
                    throw new ArgumentNullException(nameof(alternativeNames), "Missing or empty value in alternativeNames array.");
                }

                AlternativeNames = (string[])alternativeNames.Clone();
            }
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (null == obj) return false;
            if (!(obj is Occupation)) return false;
            return ((Occupation)obj).Id.Equals(this.Id);
        }
    }
}
