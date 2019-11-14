using System;
using Animal;
using System.Text;

namespace UIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
           
           
            AnimalClass[] l= { new Cat(), new Dog(), new Lion()};
            
            Console.WriteLine(animalSounds(l));
        }


        static string animalSounds(AnimalClass[] l) {
           
            StringBuilder ss = new StringBuilder(50);

            for (SByte i = 0; i < l.Length; i++)
            {
                ss.Append(l[i].GetName());
                ss.Append(" makes ");
                ss.Append(l[i].MakeSound());
                ss.Append(Environment.NewLine);
            }

            return ss.ToString();
        }
    }
}
