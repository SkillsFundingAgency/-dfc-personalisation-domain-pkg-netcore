namespace DFC.Personalisation.Domain.Models
{
    public class STSkill
    {
        public string SkillType { get; set; }
        public string Skill { get; set; }
        public string[] AlternativeLabels { get; set; }
        public string Uri { get; set; }

        public STSkill(string skill)
        {
            this.Skill = skill;
        }
    }
}

