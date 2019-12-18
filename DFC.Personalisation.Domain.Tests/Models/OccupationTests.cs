using FluentAssertions;
using NUnit.Framework;
using System;
using DFC.Personalisation.Domain.Models;
using FluentAssertions.Extensions;

namespace DFC.Personalisation.Domain.Tests.Models
{
    [TestFixture]
    public class OccupationTests
    {
        [TestFixture]
        public class Constructor
        {
            [Test]
            public void When_Occupation_Created_Then_Id_ShouldNotBeNullOrEmpty()
            {
                // Arrange

                string id = "";
                string name = "furniture upholsterer";
                DateTime lastModified = DateTime.UtcNow;

                // Act
                Action act = () => new Occupation(id, name, lastModified);

                // Assert

                act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("id");
            }

            [Test]
            public void When_Occupation_Created_Then_Name_ShouldNotBeNullOrEmpty()
            {
                // Arrange

                string id = "http://data.europa.eu/esco/occupation/cd3f5356-a16f-4aca-9d4b-ceba2b2afec5";
                string name = "";
                DateTime lastModified = DateTime.UtcNow;

                // Act
                Action act = () => new Occupation(id, name, lastModified);

                // Assert

                act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("name");
            }
        }

        [TestFixture]
        public class Name
        {
            [Test]
            public void Name_ShouldBeImmutable()
            {
                // Arrange

                string id = "http://data.europa.eu/esco/occupation/cd3f5356-a16f-4aca-9d4b-ceba2b2afec5";
                string name = "furniture upholsterer";
                DateTime lastModified = DateTime.UtcNow;
                var occupation = new Occupation(id, name, lastModified);

                // Act

                name = "pensions administrator";

                // Assert

                occupation.Name.Should().Be("furniture upholsterer");
            }
        }

        [TestFixture]
        public class AlternativeNames
        {
            [Test]
            public void AlternativeNames_ShouldBeImmutable()
            {
                // Arrange

                string id = "http://data.europa.eu/esco/occupation/cd3f5356-a16f-4aca-9d4b-ceba2b2afec5";
                string name = "furniture upholsterer";
                DateTime lastModified = DateTime.UtcNow;
                string[] alternateNames = new string[] { "chair builder", "craftsman upholster" };
                var occupation = new Occupation(id, name, lastModified, alternateNames);

                // Act

                alternateNames[0] = "changed source value";

                // Assert

                occupation.AlternativeNames[0].Should().Be("chair builder");
            }
        }

        [TestFixture]
        public class Id
        {
            [Test]
            public void Id_ShouldBeImmutable()
            {
                // Arrange

                string id = "http://data.europa.eu/esco/occupation/cd3f5356-a16f-4aca-9d4b-ceba2b2afec5";
                string name = "furniture upholsterer";
                DateTime lastModified = DateTime.UtcNow;
                var occupation = new Occupation(id, name, lastModified);

                // Act

                id = "changed value";

                // Assert

                occupation.Id.Should().Be("http://data.europa.eu/esco/occupation/cd3f5356-a16f-4aca-9d4b-ceba2b2afec5");
            }
        }

        [TestFixture]
        public class LastModified
        {
            [Test]
            public void LastModified_ShouldBeImmutable()
            {
                // Arrange

                string id = "http://data.europa.eu/esco/occupation/cd3f5356-a16f-4aca-9d4b-ceba2b2afec5";
                string name = "furniture upholsterer";
                DateTime lastModified = new DateTime(2019, 12, 18, 15,00,00);
                var occupation = new Occupation(id, name, lastModified);

                // Act

                lastModified = lastModified.AddHours(-1);

                // Assert

                occupation.LastModified.Should().Be(18.December(2019).At(15,00,00));
            }
        }
    }
}
