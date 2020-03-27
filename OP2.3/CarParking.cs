using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP2._3
{
    public class CarParking
    {
        public Dictionary<Int32, Car> Cars { get; private set; }
        public Dictionary<Int32, DateTime> Time { get; private set; }
        public List<Int32> Places { get; private set; }
        public Int32 Capasity { get; private set; }
        public Car GetCar(Int32 i)
        {
            if (Places.Contains(i))
            {
                Places.Remove(i);
                TimeSpan time = DateTime.Now.Subtract(Time[i]);
                int t = Convert.ToInt32(time.TotalSeconds)/3600;
                if (t == 0)
                {
                    Console.WriteLine("You have to pay 10$");
                }
                else
                {
                    Console.WriteLine($"You have to pay {t + 10}$");
                }
                Car car= Cars[i];
                Time.Remove(i);
                Cars.Remove(i);
                return car;
            }
            else
            {
                throw new Exception("There is no car with this number");
            }
        }
        public Int32 ParkCar(Car car)
        {
            Int32 i = FindPlace();
            Cars[i] = car;
            Time[i] = DateTime.Now;
            return i;
        }
        public Int32 FindPlace()
        {
            int max = 0;
            for(Int32 i = 0; i < Places.Count; i++)
            {
                if (!Places.Contains(i))
                {
                    Places.Add(i);
                    return i;
                }
                if (max < i)
                {
                    max = i;
                }
            }
            if (max < Capasity)
            {
                Places.Add(max);
                return max;
            }
            else
            {
                throw new ArgumentException("Parking if out of free space");
            }
            
        }
        public CarParking(Int32 capasity)
        {
            Cars = new Dictionary<int, Car>();
            Time = new Dictionary<int, DateTime>();
            Places = new List<int>();
            if (capasity > 0)
            {
                Capasity = capasity;
            }
            else
            {
                throw new ArgumentException("capasity cannot be less then 1");
            }

        }
    }
}
