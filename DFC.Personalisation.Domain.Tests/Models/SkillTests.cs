using DFC.Personalisation.Domain.Models;
using FluentAssertions;
using NUnit.Framework;

namespace DFC.Personalisation.Domain.Tests.Models
{
    [TestFixture]
    public class SkillTests
    {
        [Test]
        public void When_SkillCreated_Then_NameShouldHaveValue()
        {
            var s = new STSkill("perform upholstery repair");

            s.Skill.Should().Be("perform upholstery repair");
        }
    }
}
