using Abstractions.Commands;
using UnityEngine;
using Abstractions.Commands.CommandsInterfaces;

namespace Core.CommandExecutors
{
    public class StopCommandExecutor : CommandExecutorBase<IStopCommand>
    {
        public override void ExecuteSpecificCommand(IStopCommand command)
        {
            Debug.Log("Stop command");
        }
    }
}