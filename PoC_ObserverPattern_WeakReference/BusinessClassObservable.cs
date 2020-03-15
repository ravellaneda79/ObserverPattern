namespace PoC_ObserverPattern_WeakReference
{
    public class BusinessClassObservable : Observable<BusinessClassObservable>
    {
        private string observableState;

        public BusinessClassObservable()
        {
            this.bag = SubjectBag<BusinessClassObservable>.Instance(this);
            this.observableState = "Initial state";
        }

        public string ObservableState
        {
            get => this.observableState;
            set
            {
                this.observableState = value; 
                this.bag?.Notify();
            }
        }

        public void DoBusinessStuff()
        {
            // I'm doing relevant business stuff here.
            // My observable state change here.
            this.ObservableState = "My new state";
        }
    }
}
