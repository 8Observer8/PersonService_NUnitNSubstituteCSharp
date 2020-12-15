using NSubstitute;
using NUnit.Framework;

namespace PersonService.UnitTests
{
    [TestFixture]
    public class PersonServiceTests
    {
        [Test]
        public void Save_SaveIsCalledIfPersonIsValid_Called()
        {
            // Arrange
            var validator = Substitute.For<IPersonValidator>();
            var dataContext = Substitute.For<IDataContext>();
            var person = new Person();
            validator.IsValid(person).Returns(true);
            var personService = new PersonService(validator, dataContext);

            // Act
            personService.Save(person);

            // Assert
            validator.Received(1).IsValid(person);
            dataContext.Received(1).Save(person);
        }
    }
}
