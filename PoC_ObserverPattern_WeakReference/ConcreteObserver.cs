using System;

namespace PoC_ObserverPattern_WeakReference
{
    public class ConcreteObserver : Observer
    {
        private readonly string name;
        private SubjectBag<BusinessClassObservable> subjectBag;

        public ConcreteObserver(string name)
        {
            this.subjectBag = SubjectBag<BusinessClassObservable>.Instance();
            this.subjectBag.Attach(this);
            this.name = name;
            this.ObservableState = "Observer initial status";
        }

        public override void Update()
        {
            this.ObservableState = this.subjectBag.Observable.ObservableState;
            Console.WriteLine($"Observer {this.name}'s new state is {this.ObservableState}");
        }

        public void DetachObservation()
        {
            this.subjectBag.Detach(this);
        }

        public string ObservableState { get; private set; }
    }
}
