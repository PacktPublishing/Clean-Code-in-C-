using CH11_Transactions.Attributes;
using CH11_Transactions.Data;
using CH11_Transactions.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CH11_Transactions
{
    class Program
    {
        private DatabaseContext _context = null;

        static void Main(string[] args)
        {
            var program = new Program();
            program.InitialiseDbContext();
            program.AddBusinesses();
        }

        private void InitialiseDbContext()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
               .UseInMemoryDatabase(databaseName: "Businesses")
               .Options;

            _context = new DatabaseContext(options);
        }

        private void AddBusinesses()
        {
            AddBusiness("Microsoft");
            AddBusiness("Apple");
            AddBusiness("Sun Microsystems");
            try
            {
                throw new NotImplementedException();
            }
            catch { }
            AddBusiness("Oracle");
        }

        [RequiresTransaction]
        private void AddBusiness(string name)
        {
            var id = _context.Businesses.Count() + 1;
            _context.Businesses.Add(new Business { Id = id, Name = name });
            _context.SaveChanges();
        }
    }
}
