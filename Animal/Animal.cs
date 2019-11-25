using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class Animal

    {
        protected string name;
        protected string sound;

        public  string GetName()
        {
            return name;
        }

        public  string MakeSound()
        {
            return sound;
        }
    }
}
