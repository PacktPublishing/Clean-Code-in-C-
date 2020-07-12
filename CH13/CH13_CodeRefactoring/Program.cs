using System;
using System.Collections.Generic;
using CH13_CodeRefactoring.ProblemCode;
using CH13_CodeRefactoring.RefactoredCode;
using Report = CH13_CodeRefactoring.ProblemCode.Report;

namespace CH13_CodeRefactoring
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //AdapterPatternExample();
            //BooleanBlindnessExample();
            //ClassDependencyExample();
            //CombinatorialExplosionExample();
            CyclomaticComplexityExample();
            //LooselyCoupledExample();
            //MutantVariablesExample();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        #region Adapter Pattern

        private static void AdapterPatternExample()
        {
            var client = new Client();
            client.Operation();
        }

        #endregion

        #region Boolean Blindness

        private static void BooleanBlindnessExample()
        {
            BooleanBlindnessConcertBooking();
            ClearSightedConcertBooking();
        }

        private static void BooleanBlindnessConcertBooking()
        {
            var booking = new ProblemCode.ConcertBooking();
            booking.BookConcert("Solitary Experiments", true);
        }

        private static void ClearSightedConcertBooking()
        {
            var booking = new RefactoredCode.ConcertBooking();
            booking.BookConcert("Chrom", TicketType.Seated);
        }


        #endregion

        #region Class Dependency

        private static void ClassDependencyExample()
        {
            ClassDependencyProblem();
            ClassDependencyRefactored();
        }

        private static void ClassDependencyProblem()
        {
            var dogOwner = new DogOwner();
            dogOwner.Walkies(new ProblemCode.Dog());
        }

        private static void ClassDependencyRefactored()
        {
            var petOwner = new PetOwner();
            IPet tiddles = new Cat();
            IPet pepe = new RefactoredCode.Dog();
            petOwner.Walkies(tiddles);
            petOwner.Walkies(pepe);
        }

        #endregion

        #region Combinatorial Explosion

        private static void CombinatorialExplosionExample()
        {
            CombinatorialExplosion();
            SingleVersion();
        }

        private static void CombinatorialExplosion()
        {
            var addition = new ProblemCode.Addition();
            addition.Add(1, 2);
            addition.Add(1.2, 3.4);
            addition.Add(4.5f, 6.3f);
        }

        private static void SingleVersion()
        {
            var addition = new RefactoredCode.Maths();
            addition.Add<int>(1, 2);
            addition.Add<double>(1.2, 3.4);
            addition.Add<float>(5.6f, 7.8f);
        }

        #endregion

        #region Cyclomatic Complexity

        private static void CyclomaticComplexityExample()
        {
            CyclomaticComplexity();
            RunReport();
        }

        private static void CyclomaticComplexity()
        {
            var cc = new CyclomaticComplexity();
            cc.RunReport(Report.StaffShiftPattern);
        }

        private static void RunReport()
        {
            var rr = new ReportRunner();
            rr.RunReport(RefactoredCode.Report.StaffShiftPattern);

            ReportBase newStarters = new NewStartersReport();
            newStarters.Print();

            ReportBase leavers = new LeaversReport();
            leavers.Print();
        }

        #endregion

        #region Mutation of Variables

        private static void MutantVariablesExample()
        {
            MutationExample();
            FunctionalExample();
        }

        private static void MutationExample()
        {
            var mutant = new ProblemCode.Mutant();
            var sum = mutant.IntegerSquaredSum(new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9});
            Console.WriteLine($"The sum of the integers 1, 2, 3, 4, 5, 6, 7, 8, 9 squared is {sum}.");
        }

        private static void FunctionalExample()
        {
            var mutant = new ProblemCode.Mutant();
            var sum = mutant.IntegerSquaredSum(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Console.WriteLine($"The sum of the integers 1, 2, 3, 4, 5, 6, 7, 8, 9 squared is {sum}.");
        }

        #endregion

        #region Dependency Injection

        private static void LooselyCoupledExample()
        {
            var lc = new LooselyCoupled(new Dependency());
            lc.DoWork();
        }

        #endregion
    }
}
