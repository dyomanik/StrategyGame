using UniRx;
using System;

namespace UserControlSystem 
{
    public abstract class StatelessScriptableValueBase<T> : ScriptableValueBase<T>, IObservable<T> 
    {
        private Subject<T> _valueStream = new Subject<T>();

        public override void SetValue(T value)
        {
            base.SetValue(value);
            _valueStream.OnNext(value);
        }

        public IDisposable Subscribe(IObserver<T> observer) => _valueStream.Subscribe(observer);
    }
}