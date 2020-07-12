using System;

namespace CH11_ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new CustomException("Custom exception!");
            }
            catch (CustomException cex)
            {
                cex.Data.Add("Username", "Student One");
                cex.Data.Add("Role", "Student");
                Console.WriteLine(
                    $"Status: {cex.Status}, Message: {cex.Message}, Username: {cex.Data["Username"]}, Role: {cex.Data["Role"]}");
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
