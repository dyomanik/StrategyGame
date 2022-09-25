using UnityEngine;
using Abstractions.Commands.CommandsInterfaces;
using System.Threading.Tasks;

namespace Core.CommandExecutors
{
    public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
    {
        public override async Task ExecuteSpecificCommand(IPatrolCommand command)
        {
            Debug.Log($"{name} is patrolling between {command.Start} and {command.Target}!");
        }
    }
}