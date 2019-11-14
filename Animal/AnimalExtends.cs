using System;
using System.Collections.Generic;
using System.Text;

namespace Animal
{
    public class AnimalExtends : AnimalClass
    {
        public override string GetName()
        {
            return name;
        }

        public override string MakeSound()
        {
            return sound;
        }
    }
}
