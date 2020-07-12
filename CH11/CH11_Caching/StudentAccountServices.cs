using PostSharp.Patterns.Caching;
using System;
using System.Collections.Generic;
using System.Threading;

namespace CH11_Caching
{
    [CacheConfiguration(ProfileName = "StudentAccount")]
    internal class StudentAccountServices
    {
        [Cache]
        public static StudentAccount GetStudentAccount(int id)
        {
            Console.WriteLine($">> Retrieving the student account {id} from database...");
            Thread.Sleep(1000);
            var account = new StudentAccount { StudentAccountId = id };
            CachingServices.CurrentContext.AddDependency(account);
            return account;
        }

        [Cache]
        public static IEnumerable<StudentAccount> GetStudentAccountsOfStudent(int studentId)
        {
            yield return GetStudentAccount(1);
            yield return GetStudentAccount(2);
        }

        public static void UpdateStudentAccount(StudentAccount studentAccount)
        {
            Console.WriteLine(
                $">> Updating the student account {studentAccount.StudentAccountId} in database..."
            );
            Thread.Sleep(1000);
            CachingServices.Invalidation.Invalidate(studentAccount);
        }
    }
}
