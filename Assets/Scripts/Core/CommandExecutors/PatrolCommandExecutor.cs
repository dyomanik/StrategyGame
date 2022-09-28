using UnityEngine;
using Abstractions.Commands.CommandsInterfaces;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine.AI;
using Utils;

namespace Core.CommandExecutors
{
    public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private StopCommandExecutor _stopCommandExecutor;
        [SerializeField] private UnitMovementStop _unitMovementStop;

        public override async Task ExecuteSpecificCommand(IPatrolCommand command)
        {
            var point1 = command.Start;
            var point2 = command.Target;

            while (true)
            {
                GetComponent<NavMeshAgent>().destination = point2;
                _animator.SetTrigger(Animator.StringToHash(UnitAnimationType.WALK.ToString()));
                _stopCommandExecutor.CancellationTokenSource = new CancellationTokenSource();
                try
                {
                    await _unitMovementStop.WithCancellation(_stopCommandExecutor.CancellationTokenSource.Token);
                }
                catch
                {
                    GetComponent<NavMeshAgent>().isStopped = true;
                    GetComponent<NavMeshAgent>().ResetPath();
                    break;
                }
                var tempPoint = point1;
                point1 = point2;
                point2 = tempPoint;
            }
            _stopCommandExecutor.CancellationTokenSource = null;
            _animator.SetTrigger(Animator.StringToHash(UnitAnimationType.IDLE.ToString()));
        }
    }
}