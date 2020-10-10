using System;
using System.Collections.Generic;

namespace Observer
{


    interface IObserver
    {
        void ChangeColor(Color color);
    }


    interface ISubject
    {
        void Register(IObserver observer);
        void UnRegister(IObserver observer);
        void Notify();
    }


    class Subject : ISubject
    {
        private List<IObserver> lstObservers = new   List<IObserver>();
        Color color = new Color()
        {
            Id = 1,
            Name = "blue"
        };
        

        public void Register(IObserver observer)
        {
            lstObservers.Add(observer);
        }

        public void UnRegister(IObserver observer)
        {
            lstObservers.Remove(observer);
        }

        public void Notify()
        {
            foreach(var item in lstObservers)
            {
                item.ChangeColor(color);
            }
        }
    }

    class ObserverA : IObserver
    {
        public void ChangeColor(Color color)
        {
            Console.WriteLine($"Observer B notified  color: {color.Name}");
        }
    }

    class ObserverB : IObserver
    {
        public void ChangeColor(Color color)
        {
            Console.WriteLine($" Observer B notified color: {color.Name}");
        }
    }


    class Program
    {

        static void Main(string[] args)
        {
            ObserverA objA = new ObserverA();
            ObserverB objB = new ObserverB();


            Subject objSubject = new Subject();
            objSubject.Register(objA);
            objSubject.Register(objB);

            objSubject.Notify();
        }
    }

    class Color{
        public int Id { get; set; }
        public string  Name { get; set; }
    }
}
