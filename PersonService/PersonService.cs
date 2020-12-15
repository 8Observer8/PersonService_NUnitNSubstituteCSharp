using System;

namespace PersonService
{
    public class PersonService
    {
        private IPersonValidator _validator;
        private IDataContext _dataCotext;

        public PersonService(
            IPersonValidator validator,
            IDataContext dataCotext)
        {
            _validator = validator;
            _dataCotext = dataCotext;
        }

        public void Save(Person person)
        {
            if (_validator.IsValid(person))
            {
                _dataCotext.Save(person);
            }
            else
            {
                throw new ArgumentException("Person is not valid");
            }
        }
    }
}
