using System;

namespace Utils
{
    public abstract class AwaiterBase<TAwaited> : IAwaiter<TAwaited>
    {
        private Action _continuation;
        private bool _isCompleted;
        private TAwaited _result;

        public bool IsCompleted => _isCompleted;

        public void OnCompleted(Action continuation)
        {
            if (_isCompleted)
            {
                continuation?.Invoke();
            }
            else
            {
                _continuation = continuation;
            }
        }

        public TAwaited GetResult() => _result;

        protected void OnWaitFinish(TAwaited result)
        {
            _result = result;
            _isCompleted = true;
            _continuation?.Invoke();
        }

    }
}