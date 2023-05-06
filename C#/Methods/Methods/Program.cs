using Methods;
using System;
namespace Method

{
  
   class Program
    {
        public static void Main(string[] args)
        {
            var point = new point(10,12);

            point.move(new point(20,25));

            Console.WriteLine(point.x);
            Console.WriteLine(point.y);

            point.move(40, 50);

            Console.WriteLine(point.x);
            Console.WriteLine(point.y);

            try
            {
                point.move(null);

                Console.WriteLine(point.x);
                Console.WriteLine(point.y);
            }
            catch 
            {
                Console.WriteLine("unexpected error occured"); 
           
            }

            var para = new Param();
            Console.WriteLine(para.add(1,2,3,4,5,6,6));
            Console.WriteLine(para.add(1, 2));

            Console.ReadLine();

        }

    }

}