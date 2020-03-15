using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;

namespace PoC_ObserverPattern_WeakReference
{
    public class SubjectBag<T> where T : Observable<T>
    {
        private static SubjectBag<T> instance;
        private List<Observer> observers = new List<Observer>();

        internal SubjectBag(T observable)
        {
            this.Observable = observable;
        }

        public readonly T Observable;

        public static SubjectBag<T> Instance(T observable)
        {
            return instance ??= new SubjectBag<T>(observable);
        }

        public static SubjectBag<T> Instance()
        {
            if (instance == null)
            {
                throw new ConstraintException("Trying to get an instance of the bag while not observable is attached.");
            }

            return instance;
        }

        public void Attach(Observer observer)
        {
            this.observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            this.observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in this.observers)
            {
                observer.Update();
            }
        }
    }
}
