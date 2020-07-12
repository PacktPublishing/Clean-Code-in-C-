using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH05_AvoidNullPointerExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person person = null;
                var program = new Program();
                //program.TryCatchExample(person);
                program.ArgumentNullValidatorExample(person);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                Console.ReadKey();
            }
        }

        private void TryCatchExample(Person person)
        {
            try
            {
                Console.WriteLine($"Person's Name: {person.Name}");
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine("Error: The person argument cannot be null.");
                throw;
            }
        }

        private void ArgumentNullValidatorExample(Person person)
        {
            ArgumentNullValidator.NotNull("Person", person);
            Console.WriteLine($"Person's Name: {person.Name}");
        }
    }
}
