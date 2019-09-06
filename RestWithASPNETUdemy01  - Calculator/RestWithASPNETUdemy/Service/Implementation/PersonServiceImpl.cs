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

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));


            if (result==null)
            {
                throw new PersonNotFoundException();
            }

            try
            {
                _context.Persons.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;

            }

            return true;
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }



        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Update(Person person)
        {
            if (!Exist(person.Id))
            {
                throw new PersonNotFoundException();
            }

            Console.WriteLine(person);

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

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
