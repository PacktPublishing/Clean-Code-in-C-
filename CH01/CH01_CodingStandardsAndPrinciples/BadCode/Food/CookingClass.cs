using System;

namespace CH01_CodingStandardsAndPrinciples.BadCode.Food
{
    public class CookingClass
    {
        private SushiChef _sushiChef;
        private VeganChef _veganChef;

        public void StartCookingLesson()
        {
            SushiCookingLesson();
            VeganCookingLesson();
        }

        private void SushiCookingLesson()
        {
            _sushiChef = new SushiChef();
            _sushiChef.FoodCookedHandler += SushiChef_FoodCookedHandler;
            _sushiChef.FoodCookingHandler += SushiChef_FoodCookingHandler;
            _sushiChef.StartCooking();
        }

        private void SushiChef_FoodCookingHandler(object sender, EventArgs e)
        {
            Console.WriteLine($"{_sushiChef.Speciality} Chef now teaching {_sushiChef.Speciality} cooking class.");
            Console.WriteLine($"{_sushiChef.Speciality} students observing and taking notes...");
        }

        private void SushiChef_FoodCookedHandler(object sender, EventArgs e)
        {
            Console.WriteLine($"{_sushiChef.Speciality} Chef has now finished teaching {_sushiChef.Speciality} cooking class.");
            Console.WriteLine($"{_sushiChef.Speciality} class finished!");
        }

        private void VeganCookingLesson()
        {
            _veganChef = new VeganChef();
            _veganChef.FoodCookedHandler += VeganChef_FoodCookedHandler;
            _veganChef.FoodCookingHandler += VeganChef_FoodCookingHandler;
            _veganChef.StartCooking();
        }

        private void VeganChef_FoodCookingHandler(object sender, EventArgs e)
        {
            Console.WriteLine($"{_veganChef.Speciality} Chef now teaching {_veganChef.Speciality} cooking class.");
            Console.WriteLine($"{_veganChef.Speciality} students observing and taking notes...");
        }

        private void VeganChef_FoodCookedHandler(object sender, EventArgs e)
        {
            Console.WriteLine($"{_veganChef.Speciality} Chef has now finished teaching {_veganChef.Speciality} cooking class.");
            Console.WriteLine($"{_veganChef.Speciality} class finished!");
        }
    }
}
