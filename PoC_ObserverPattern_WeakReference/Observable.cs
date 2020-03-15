using System.Collections.Generic;

namespace PoC_ObserverPattern_WeakReference
{
    public abstract class Observable<T> where  T : Observable<T>
    {
        internal SubjectBag<T> bag;
    }
}
