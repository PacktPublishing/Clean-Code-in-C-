using System;

namespace CH01_CodingStandardsAndPrinciples.GoodCode.Food
{
    public interface IChef
    {
        event EventHandler FoodCookingHandler;
        event EventHandler FoodCookedHandler;

        FoodTypes Speciality { get; }

        void StartCooking();
    }
}
