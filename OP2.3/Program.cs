using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            CarParking p = new CarParking(2);
            Car c = new Car("111");
            int i=p.ParkCar(c);
            Car car = p.GetCar(i);
            Console.WriteLine(car.Number);
            Console.ReadLine();
        }
    }
    public class Car
    {
        public string Number { get; private set; }
        public Car(string number)
        {
            Number = number;
        }
    }
}
