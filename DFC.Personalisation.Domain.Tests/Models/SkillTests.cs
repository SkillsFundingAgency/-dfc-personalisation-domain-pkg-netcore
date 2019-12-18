using System;
using DFC.Personalisation.Domain.Models;
using FluentAssertions;
using NUnit.Framework;

namespace DFC.Personalisation.Domain.Tests.Models
{
    [TestFixture]
    public class SkillTests
    {
        [TestFixture]
        public class Constructor
        {
            [Test]
            public void When_Skill_Created_Then_Id_ShouldNotBeNullOrEmpty()
            {
                // Arrange

                string id = "";
                string name = "perform upholstery repair";
                SkillType skillType = SkillType.Competency;

                // Act
                Action act = () => new Skill(id, name, skillType);

                // Assert

                act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("id");
            }

            [Test]
            public void When_Skill_Created_Then_Name_ShouldNotBeNullOrEmpty()
            {
                // Arrange

                string id = "http://data.europa.eu/esco/skill/ca99a4f9-4ead-4d17-a430-dda2cd6fb5ed";
                string name = "";
                SkillType skillType = SkillType.Competency;

                // Act
                Action act = () => new Skill(id, name, skillType);

                // Assert

                act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("name");
            }

            [Test]
            public void When_Skill_CreatedWithAlternateNames_Then_AlternateNames_MustNotBeNullOrEmpty()
            {
                // Arrange

                string id = "http://data.europa.eu/esco/skill/ca99a4f9-4ead-4d17-a430-dda2cd6fb5ed";
                string name = "perform upholstery repair";
                SkillType skillType = SkillType.Competency;
                string[] alternateNames = new string[]{ "perform upholstery repairs", "undertake upholstery repair" };

                // Act

                var skill = new Skill(id, name, skillType, alternateNames);

                // Assert

                skill.AlternativeNames.Should().Equal(alternateNames);
            }

            [Test]
            public void When_Skill_CreatedWithAlternateNames_Then_AlternateNames_MustNotHaveMissingValues()
            {
                // Arrange

                string id = "http://data.europa.eu/esco/skill/ca99a4f9-4ead-4d17-a430-dda2cd6fb5ed";
                string name = "perform upholstery repair";
                SkillType skillType = SkillType.Competency;
                string[] alternateNames = new string[] { "perform upholstery repairs", "", "undertake upholstery repair" };

                // Act

                Action act = () => new Skill(id, name, skillType, alternateNames);

                // Assert

                act.Should().Throw<ArgumentNullException>().And.Message.Should().Be("Missing or empty value in alternativeNames array. (Parameter 'alternativeNames')");
            }
        }

        [TestFixture]
        public class Id
        {
            [Test]
            public void Id_ShouldBeImmutable()
            {
                // Arrange

                string id = "http://data.europa.eu/esco/skill/ca99a4f9-4ead-4d17-a430-dda2cd6fb5ed";
                string name = "perform upholstery repair";
                SkillType skillType = SkillType.Competency;
                var skill = new Skill(id, name, skillType);

                // Act

                id = "changed source value";

                // Assert

                skill.Id.Should().Be("http://data.europa.eu/esco/skill/ca99a4f9-4ead-4d17-a430-dda2cd6fb5ed");
            }
        }

        [TestFixture]
        public class Name
        {
            [Test]
            public void Name_ShouldBeImmutable()
            {
                // Arrange

                string id = "http://data.europa.eu/esco/skill/ca99a4f9-4ead-4d17-a430-dda2cd6fb5ed";
                string name = "perform upholstery repair";
                SkillType skillType = SkillType.Competency;
                var skill = new Skill(id, name, skillType);

                // Act

                name = "changed source value";

                // Assert

                skill.Name.Should().Be("perform upholstery repair");
            }
        }

        [TestFixture]
        public class SkillTypeProperty
        {
            [Test]
            public void SkillType_ShouldBeImmutable()
            {
                // Arrange

                string id = "http://data.europa.eu/esco/skill/ca99a4f9-4ead-4d17-a430-dda2cd6fb5ed";
                string name = "perform upholstery repair";
                SkillType skillType = SkillType.Competency;
                var skill = new Skill(id, name, skillType);

                // Act

                skillType = SkillType.Knowledge;

                // Assert

                skill.SkillType.Should().Be(SkillType.Competency);
            }
        }

        [TestFixture]
        public class AlternativeNames
        {
            [Test]
            public void AlternativeNames_ShouldBeImmutable()
            {
                // Arrange

                string id = "http://data.europa.eu/esco/skill/ca99a4f9-4ead-4d17-a430-dda2cd6fb5ed";
                string name = "perform upholstery repair";
                SkillType skillType = SkillType.Competency;
                string[] alternateNames = new string[] { "perform upholstery repairs", "undertake upholstery repair" };
                var skill = new Skill(id, name, skillType, alternateNames);

                // Act

                alternateNames[0] = "changed source value";

                // Assert

                skill.AlternativeNames[0].Should().Be("perform upholstery repairs");
            }
        }
    }
}
