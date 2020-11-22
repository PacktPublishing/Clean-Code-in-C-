using System;

namespace CH01_CodingStandardsAndPrinciples.GoodCode.Food
{
    public class CookingClass
    {
        private static IChef _chef;

        public void StartCookingLesson()
        {
            CookingLesson(new SushiChef());
            CookingLesson(new VeganChef());
        }

        private static void CookingLesson(IChef chef)
        {
            _chef = chef;
            _chef.FoodCookingHandler += Chef_FoodCookingHandler;
            _chef.FoodCookedHandler += Chef_FoodCookedHandler;
            _chef.StartCooking();
        }

        private static void Chef_FoodCookedHandler(object sender, EventArgs e)
        {
            Console.WriteLine($"{_chef.Speciality} Chef has now finished teaching {_chef.Speciality} cooking class.");
            Console.WriteLine($"{_chef.Speciality} class finished!");
        }

        private static void Chef_FoodCookingHandler(object sender, EventArgs e)
        {
            Console.WriteLine($"{_chef.Speciality} Chef now teaching {_chef.Speciality} cooking class.");
            Console.WriteLine($"{_chef.Speciality} students observing and taking notes...");
        }
    }
}
