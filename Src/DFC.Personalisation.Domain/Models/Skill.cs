namespace DFC.Personalisation.Domain.Models
{
    public class Skill
    {
        public string Name { get; private set; }

        public Skill(string name)
        {
            this.Name = name;
        }
    }
}
