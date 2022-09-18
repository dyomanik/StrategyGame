using Abstractions.Commands;
using UnityEngine;
using Abstractions.Commands.CommandsInterfaces;

namespace Core.CommandExecutors
{
    public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
    {
        public override void ExecuteSpecificCommand(IPatrolCommand command)
        {
            Debug.Log($"{name} is patrolling between {command.Start} and {command.Target}!");
        }
    }
}