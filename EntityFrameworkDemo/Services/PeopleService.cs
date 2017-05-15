namespace EntityFrameworkDemo.Services
{
    using EntityFrameworkDemo.Entities;
    using EntityFrameworkDemo.Repositories;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class PeopleService : IPeopleService
    {
        IPersonRepository _personRepository;
        IUnitOfWork _unitOfWork;

        public PeopleService(IPersonRepository personRepository, IUnitOfWork unitOfWork)
        {
            this._personRepository = personRepository;
            this._unitOfWork = unitOfWork;
        }

        public Person GetPerson(int id)
        {
            return this._personRepository.Read(id);
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return this._personRepository.Read();
        }
        
        public void NewPerson(Person person)
        {
            this._personRepository.Create(person);
            this._unitOfWork.SaveChanges();
        }

        public void SavePerson(Person person)
        {
            this._personRepository.Update(person);
            this._unitOfWork.SaveChanges();
        }
    }
}
