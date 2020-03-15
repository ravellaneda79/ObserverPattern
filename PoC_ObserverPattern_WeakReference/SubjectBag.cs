using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PoC_ObserverPattern_WeakReference
{
    public class SubjectBag<T> where T : Observable<T>
    {
        private static SubjectBag<T> instance;
        private List<KeyValuePair<Type, WeakReference<Observer>>> observers = new List<KeyValuePair<Type, WeakReference<Observer>>>();
        private readonly WeakReference<T> observable;

        internal SubjectBag(T observable)
        {
            this.observable = new WeakReference<T>(observable);
        }

        public T Observable => this.observable.TryGetTarget(out var target) ? target : null;

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
            this.observers.Add(
                new KeyValuePair<Type, WeakReference<Observer>>(
                    observer.GetType(), 
                    new WeakReference<Observer>(observer)));
        }

        public void Detach(Observer observer)
        {
            if (this.observers.Any(x => x.Key == observer.GetType()))
            {
                var elementToRemove = this.observers.FirstOrDefault(x => x.Key == observer.GetType());
                this.observers.Remove(elementToRemove);
            }
        }

        public void Notify()
        {
            foreach (var observer in this.observers)
            {
                if (observer.Value.TryGetTarget(out var observerToNotify))
                {
                    observerToNotify.Update();
                }
            }
        }
    }
}
