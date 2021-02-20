using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("GarageApplikation.Tests")]

namespace GarageApplikation
{
   public class Garage<T> : IEnumerable<T> where T : Vehicle 
    {
         private T[] vehicles;
        private int capacity;
        private int count;
        public int Count { get { return count; } set
            {
                value = Math.Max(0, count);
            }  }
        public bool IsFull => capacity == count;

        public Garage(int capacity)
        {
            this.capacity = Math.Max(0, capacity);
            vehicles = new T[this.capacity];
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T vehicle in vehicles)
            {
                if (vehicle != null)
                    yield return vehicle;
            }
        }
        public void Add(T vehicle)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] is null)
                {
                    vehicles[i] = vehicle;
                    count++; 
                    break;
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Remove(T vehicleToRemove)
        {

            for (int i = 0; i < vehicles.Length; i++)
            {
                if(vehicles[i] == vehicleToRemove)
                {
                    vehicles[i] = null;
                    count--;
                }
            }
        }
    }
}
