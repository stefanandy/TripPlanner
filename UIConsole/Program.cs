using System;
using System.Text;
using Business;


namespace UIConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            Animal[] animalList= { new Cat(), new Dog(), new Lion() };
            
            Console.WriteLine(animalSounds(animalList));
        }


        static string animalSounds(Animal[] animalList) {
           
            StringBuilder ss = new StringBuilder();

            for (SByte i = 0; i < animalList.Length; i++)
            {
                ss.Append(animalList[i].GetName());
                ss.Append(" makes ");
                ss.Append(animalList[i].MakeSound());
                ss.Append(Environment.NewLine);
            }

            return ss.ToString();
        }
    }
}
