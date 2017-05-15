namespace EntityFrameworkDemo.Repositories
{
    using EntityFrameworkDemo.Entities;

    class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(EntityFrameworkDemoContext context) : base(context)
        {
        }

        public override Person Read(object id)
        {
            var p = base.Read(id);
            this._context.Entry(p).Collection( person => person.Addresses).Load();
            return p;
        }
    }
}
