using System;
using UnityEngine.Events;
using R3;

namespace SplenSoft.Unity
{
    public class UnityEventR3
    {
        private UnityEvent _event = new();
        private Observable<Unit> Observable => _event.AsObservable();

        public IDisposable Subscribe(Action x)
        {
            return Observable.Subscribe(y => x());
        }

        public void Invoke()
        {
            _event?.Invoke();
        }
    }

    public class UnityEventR3<T1>
    {
        private UnityEvent<T1> _event = new();
        private Observable<T1> Observable => _event.AsObservable();

        public IDisposable Subscribe(Action x)
        {
            return Observable.Subscribe(y => x());
        }

        public IDisposable Subscribe(Action<T1> x)
        {
            return Observable.Subscribe(x);
        }

        public void Invoke(T1 t1)
        {
            _event?.Invoke(t1);
        }
    }

    public class UnityEventR3<T1, T2>
    {
        private UnityEvent<T1, T2> _event = new();
        private Observable<(T1, T2)> Observable => _event.AsObservable();

        public IDisposable Subscribe(Action x)
        {
            return Observable.Subscribe(y => x());
        }

        public IDisposable Subscribe(Action<(T1, T2)> x)
        {
            return Observable.Subscribe(x);
        }

        public void Invoke(T1 t1, T2 t2)
        {
            _event?.Invoke(t1, t2);
        }
    }
}