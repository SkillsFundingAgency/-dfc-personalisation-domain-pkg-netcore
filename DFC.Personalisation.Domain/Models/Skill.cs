using System;

namespace DFC.Personalisation.Domain.Models
{
    public class Skill
    {
        public string Id { get; private set; } // unique Uri for the Skill
        public string Name { get; private set; }
        public SkillType SkillType { get; private set; }
        public RelationshipType RelationshipType { get; private set; }
        
        public string[] AlternativeNames { get; private set; }

        public Skill(string id, string name, SkillType skillType)
        {
            if (string.IsNullOrWhiteSpace((id)))
                throw new ArgumentNullException(nameof(id), "Id must be specified.");
            if (string.IsNullOrWhiteSpace((name)))
                throw new ArgumentNullException(nameof(name), "Skill name must be specified.");
            this.Id = id;
            this.Name = name;
            this.SkillType = skillType;
        }

        public Skill(string id, string name, SkillType skillType, string[] alternativeNames)
            :this(id,name,skillType)
        {
            if (null == alternativeNames || 0 == alternativeNames.Length)
                throw new ArgumentNullException(nameof(alternativeNames), "Alternative names must be specified.");
            foreach (var alternativeName in alternativeNames)
            {
                if(string.IsNullOrWhiteSpace(alternativeName)) throw new ArgumentNullException(nameof(alternativeNames), "Missing or empty value in alternativeNames array.");
            }
            AlternativeNames = (string[])alternativeNames.Clone();
        }

        public Skill(string id, string name, SkillType skillType, string[] alternativeNames,RelationshipType relationshipType)
            :this(id,name,skillType,alternativeNames)
        {
            this.RelationshipType = relationshipType;
        }
        public Skill(string id, string name, SkillType skillType,RelationshipType relationshipType)
            :this(id,name,skillType)
        {
            this.RelationshipType = relationshipType;
        }
    }
}