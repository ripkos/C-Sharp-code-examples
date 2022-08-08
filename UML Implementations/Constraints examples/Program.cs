using System;

namespace mp4
{
    class Program
    {
        static void Main(string[] args)
        {
            LeftMan l = new LeftMan { Name = "L" };
            RightMan r = new RightMan { Name = "R" };
            MiddleMan m = new MiddleMan { RightMan = r, Name = "M"};
            try
            {
                m.LeftMan = l;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }
            Console.ReadLine();
        }
    }
}
