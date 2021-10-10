using System;
using System.Collections.Generic;
using System.Text;
using LightBDD.NUnit3;
using NUnit.Framework;

namespace Gherkin.Steps
{
    class Class1
    {

        [Given(@"the current total is "(.*)"")]
        public void GivenTheCurrentTotalIs(int p0)
        {
            calculator.currentTotal = p0;
        }





    }
}
