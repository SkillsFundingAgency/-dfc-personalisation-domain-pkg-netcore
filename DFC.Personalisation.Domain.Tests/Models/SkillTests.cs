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
                RelationshipType relationshipType = RelationshipType.Essential;

                // Act
                Action act = () => new Skill(id, name, skillType,relationshipType);

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

            [Test]
            public void When_Skill_CreatedWithRelationshipType_Then_RelationshipType_MustNotHaveMissingValues()
            {
                // Arrange

                string id = "http://data.europa.eu/esco/skill/ca99a4f9-4ead-4d17-a430-dda2cd6fb5ed";
                string name = "perform upholstery repair";
                SkillType skillType = SkillType.Competency;
                RelationshipType relationshipType = RelationshipType.Essential;


                // Act

                var sut  = new Skill(id, name, skillType, relationshipType);

                // Assert
                sut.RelationshipType.Should().Be(RelationshipType.Essential);

            }
            [Test]
            public void When_Skill_CreatedWithIdAndName_Then_Skill_Created()
            {
                // Arrange

                string id = "http://data.europa.eu/esco/skill/ca99a4f9-4ead-4d17-a430-dda2cd6fb5ed";
                string name = "perform upholstery repair";
                

                // Act

                var sut  = new Skill(id, name);

                // Assert
                sut.Name.Should().Be("perform upholstery repair");

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
        public class RelationshipTypeProperty
        {
            [Test]
            public void RelationshipType_ShouldBeImmutable()
            {
                // Arrange

                string id = "http://data.europa.eu/esco/skill/ca99a4f9-4ead-4d17-a430-dda2cd6fb5ed";
                string name = "perform upholstery repair";
                SkillType skillType = SkillType.Competency;
                RelationshipType relationshipType = RelationshipType.Essential;
                string[] alternateNames = new string[] { "perform upholstery repairs", "undertake upholstery repair" };
                
                var skill = new Skill(id, name, skillType,alternateNames,relationshipType);


                // Act
                relationshipType = RelationshipType.Optional;

                // Assert
                skill.RelationshipType.Should().Be(RelationshipType.Essential);
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

        [TestFixture]
        public class GetHashCode
        {
            [Test]
            public void When_SkillCreated_Then_HashCodeShouldBeIdHashCode()
            {
                // Arrange
                var id = @"/esco/skill/fe29e658-7cad-4b70-a169-10a240ec0bef";

                // Act
                var skill = new Skill(id, "work in a logistics team");

                // Assert
                skill.GetHashCode().Should().Be(id.GetHashCode());
            }
        }

        [TestFixture]
        public class Equals
        {
            [Test]
            public void When_SkillsHaveSameId_Then_TheyAreEqual()
            {
                // Arrange
                var id = @"/esco/skill/fe29e658-7cad-4b70-a169-10a240ec0bef";
                var skill_1 = new Skill(id, "work in a logistics team");
                var skill_2 = new Skill(id, "work as part of a logistics team");

                // Act
                var isEqual = skill_1.Equals(skill_2);

                // Assert
                isEqual.Should().BeTrue();
            }

            [Test]
            public void When_SkillsHaveDifferentId_Then_TheyAreNotEqual()
            {
                // Arrange
                var id_1 = @"/esco/skill/fe29e658-7cad-4b70-a169-10a240ec0bef";
                var id_2 = @"/esco/skill/fe29e658-7cad-4b70-a169-10a240ec0bff";
                var skill_1 = new Skill(id_1, "work in a logistics team");
                var skill_2 = new Skill(id_2, "work in a logistics team");

                // Act
                var isEqual = skill_1.Equals(skill_2);

                // Assert
                isEqual.Should().BeFalse();
            }
        }
    }
}
