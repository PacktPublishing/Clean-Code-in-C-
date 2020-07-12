using CH11_AddressingCrossCuttingConcerns.Interfaces;
using PostSharp.Aspects;
using PostSharp.Serialization;
using System;

namespace CH11_AddressingCrossCuttingConcerns.Attributes
{
    [PSerializable]
    [AttributeUsage(AttributeTargets.Parameter)]
    [LinesOfCodeAvoided(2)]
    public class ApplyFiltersAttribute : FilterAttribute
    {
        public override object ApplyFilter(object value)
        {
            if (value == null)
            {
                return null;
            }

            GetFilterable(value).ApplyFilter();

            return value;
        }


        private static IFilterable GetFilterable(object value)
        {
            var filterable = value as IFilterable;

            if (filterable == null)
            {
                throw new InvalidOperationException($"The type {value.GetType().FullName} is not IFilterable.");
            }

            return filterable;
        }
    }
}
