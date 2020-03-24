namespace DFC.Personalisation.Domain.Models
{
    public enum SkillType
    {
        Knowledge,
        Competency,
        Unknown
    }

    public enum SkillReusability
    {
        Transversal,
        CrossSectoral,
        SectorSpecific,
        OccupationSpecific
    }

    public enum RelationshipType
    {
        Essential,
        Optional
    }
}
