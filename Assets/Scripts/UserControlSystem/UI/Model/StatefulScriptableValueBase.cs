using UniRx;
using System;

namespace UserControlSystem 
{
    public abstract class StatefulScriptableValueBase<T> : ScriptableValueBase<T>, IObservable<T> 
    {
        private ReactiveProperty<T> _valueStream = new ReactiveProperty<T>();

        public override void SetValue(T value)
        {
            base.SetValue(value);
           _valueStream.Value = value;
        }

        public IDisposable Subscribe(IObserver<T> observer) => _valueStream.Subscribe(observer);
    }
}