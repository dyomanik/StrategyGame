using Abstractions.Commands;
using UnityEngine;
using Abstractions.Commands.CommandsInterfaces;
using System.Threading;

namespace Core.CommandExecutors
{
    public class StopCommandExecutor : CommandExecutorBase<IStopCommand>
    {
        public CancellationTokenSource CancellationTokenSource;

        public override void ExecuteSpecificCommand(IStopCommand command)
        {
            CancellationTokenSource?.Cancel();
            Debug.Log("Stop command");
        }
    }
}