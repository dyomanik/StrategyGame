using Abstractions.Commands;
using UnityEngine;
using Abstractions.Commands.CommandsInterfaces;

namespace Core.CommandExecutors
{
    public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
    {
        public override void ExecuteSpecificCommand(IMoveCommand command)
        {
            Debug.Log($"{name} is moving to {command.Target}!");
        }
    }
}