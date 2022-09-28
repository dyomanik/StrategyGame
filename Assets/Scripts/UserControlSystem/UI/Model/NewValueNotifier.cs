using Utils;

namespace UserControlSystem
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
                OnWaitFinish(obj);
            }
        }
}