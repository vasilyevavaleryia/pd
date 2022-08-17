using System;
using System.ComponentModel.DataAnnotations;

namespace ProProsecco.Helpers.Validators
{
    public class RangeAttributeUntilCurrentYear : RangeAttribute
    {
        public RangeAttributeUntilCurrentYear(int minimum) : base(minimum, DateTime.Now.Year)
        {
        }
    }
}
