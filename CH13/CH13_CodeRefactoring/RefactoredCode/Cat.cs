using System;

namespace CH13_CodeRefactoring.RefactoredCode
{
    public class Cat : IPet
    {
        public void Walkies()
        {
            Console.WriteLine("Meow! Mistress is taking me for walk.");
        }
    }
}
