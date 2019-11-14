using System;

namespace Animal
{
    public abstract class AnimalClass
    {
        protected string sound;
        protected string name;

        public abstract string MakeSound();
        public abstract string GetName();

       
    }
}
