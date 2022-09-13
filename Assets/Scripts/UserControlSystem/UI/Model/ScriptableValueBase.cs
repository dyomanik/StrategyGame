using System;
using UnityEngine;
using Utils;

namespace UserControlSystem
{
    public abstract class ScriptableValueBase<T> : ScriptableObject, IAwaitable<T>
    {
        public class NewValueNotifier<TAwaited> : AwaiterBase<TAwaited>
        {
            private readonly ScriptableValueBase<TAwaited> _scriptableValueBase;

            public NewValueNotifier(ScriptableValueBase<TAwaited> scriptableValueBase)
            {
                _scriptableValueBase = scriptableValueBase;
                _scriptableValueBase.OnNewValue += onNewValue;
            }

            private void onNewValue(TAwaited obj)
            {
                _scriptableValueBase.OnNewValue -= onNewValue;
                onWaitFinish(obj);
            }
        }

        public T CurrentValue { get; private set; }
        public Action<T> OnNewValue;

        public void SetValue(T value)
        {
            CurrentValue = value;
            OnNewValue?.Invoke(value);
        }

        public IAwaiter<T> GetAwaiter()
        {
            return new NewValueNotifier<T>(this);
        }
    }
}