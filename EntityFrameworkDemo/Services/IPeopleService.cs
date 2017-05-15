namespace EntityFrameworkDemo.Services
{
    using EntityFrameworkDemo.Entities;
    using System.Collections.Generic;

    public interface IPeopleService
    {
        Person GetPerson(int id);
        IEnumerable<Person> GetAllPeople();
        void NewPerson(Person person);
        void SavePerson(Person person);
    }
}
