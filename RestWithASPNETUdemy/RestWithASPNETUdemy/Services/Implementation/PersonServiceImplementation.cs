
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;

namespace RestWithASPNETUdemy.Services.Implementation
{
    public class PersonServiceImplementation : IPersonService
    {
        private PsqlContext _context;


        public PersonServiceImplementation(PsqlContext context)
        {
            _context = context;
        }
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        public void Delete(long id)
        {
            var result = _context.person.SingleOrDefault(p => p.id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        public List<Person> FindAll()
        {
            return _context.person.ToList();
        }


        public Person FindByID(long id)
        {
            return _context.person.SingleOrDefault(p => p.id.Equals(id));
        }

        public Person Update(Person person)
        {
            if (!Exists(person.id)) return new Person();
            var result = _context.person.SingleOrDefault(p => p.id.Equals(person.id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return person;
        }

        private bool Exists(long id)
        {
            return _context.person.Any(p => p.id.Equals(id));
        }
    }
}