using System;
using System.Threading;

namespace CH01_CodingStandardsAndPrinciples.BadCode.Food
{
    public class SushiChef
    {
        public FoodTypes Speciality => FoodTypes.Sushi;

        public delegate void Action(object sender, EventArgs e);
        public event EventHandler FoodCookingHandler;
        public event EventHandler FoodCookedHandler;

        public void StartCooking()
        {
            FoodCookingHandler?.Invoke(this, EventArgs.Empty);
            Thread.Sleep(5000);
            FoodCookedHandler?.Invoke(this, EventArgs.Empty);
        }
    }
}
