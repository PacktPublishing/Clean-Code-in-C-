using PostSharp.Patterns.Caching;
using System;
using System.Threading;

namespace CH11_Caching
{
    [CacheConfiguration(AbsoluteExpiration = 10)]
    internal class StudentServices
    {
        [Cache]
        public static Student GetStudent(int id)
        {
            Console.WriteLine($">> Retrieving the student {id} from database...");
            Thread.Sleep(1000);
            return new Student { Id = id, Name = "Spring Chicken" };
        }

        [InvalidateCache(nameof(GetStudent))]
        public static void UpdateStudent(int id, string name)
        {
            Console.WriteLine($">> Updating the student {id} in database...");
            Thread.Sleep(1000);
        }

        public static void DeleteStudent(int id, string student)
        {
            Console.WriteLine($">> Deleting the student {id} from database...");
            Thread.Sleep(1000);
            CachingServices.Invalidation.Invalidate(GetStudent, id);
        }
    }
}
