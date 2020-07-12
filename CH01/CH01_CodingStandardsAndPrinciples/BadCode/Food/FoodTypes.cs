using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH01_CodingStandardsAndPrinciples.BadCode.Food
{
    [Flags]
    public enum FoodTypes
    {
        Sushi,
        Vegan,
        Vegetarian,
        Omnivorous
    }
}
