using System;

namespace PoC_ObserverPattern_WeakReference
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure Observer pattern

            //var s = new BusinessClassObservable();

            //s.Attach(new ConcreteObserver(s, "X"));
            //s.Attach(new ConcreteObserver(s, "Y"));
            //s.Attach(new ConcreteObserver(s, "Z"));

            //// Change subject and notify observers

            //s.ObservableState = "ABC";
            //s.Notify();

            // Wait for user

            Console.ReadKey();
        }
    }
}
