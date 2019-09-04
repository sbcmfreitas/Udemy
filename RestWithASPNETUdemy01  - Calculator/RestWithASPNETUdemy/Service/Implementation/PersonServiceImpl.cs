using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;

namespace RestWithASPNETUdemy.Service.Implementation
{
    public class PersonServiceImpl : IPersonService
    {

        private PgContext _context;

        private volatile int count;

        public PersonServiceImpl(PgContext context)
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
            catch(Exception e)
            {
                throw e;
                
            }
            return person;
        }

        public bool Delete(long id)
        {

            if (!Exist(id))
            {
                throw new System.ArgumentException("Parameter cannot be null", "person.Id");
            }

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));


            if (result!=null)
            {
                throw new System.ArgumentException("Person not exist for id", id.ToString());
            }

            try
            {
                if(result!=null) _context.Persons.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;

            }

            return id>0;
        }

        public List<Person> FindAll()
        {

            List<Person> personList = new List<Person>();
            for(int i=0; i < 8; i++)
            {
                Person person = MockPerson(i);
                personList.Add(person);
            }
            return personList;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FisrtName = "Person Name "+i,
                LastName = "Person Last Name " + i,
                Gender = "Some Gender " + i,
            };
        }

        private long IncrementAndGet()
        {
            
            return Interlocked.Increment(ref count);
        }

        public Person FindById(long id)
        {
            return new Person { 
                      Id = id,
               FisrtName = "Marcos",
                LastName = "Freitas",
                Gender = "Taubaté"
            };
        }

        public Person Update(Person person)
        {
            if (!Exist(person.Id))
            {
                throw new System.ArgumentException("Parameter cannot be null", "person.Id");
            }

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            if (result == null)
            {
                throw new System.ArgumentException("Person not exist for id", person.Id.ToString() );
            }

            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;

            }
            return person;
        }

        private bool Exist(long? id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
