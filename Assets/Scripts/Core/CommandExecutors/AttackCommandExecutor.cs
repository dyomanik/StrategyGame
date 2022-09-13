using Abstractions.Commands;
using UnityEngine;
using Abstractions.Commands.CommandsInterfaces;

namespace Core.CommandExecutors
{
    public class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
    {
        public override void ExecuteSpecificCommand(IAttackCommand command)
        {
            Debug.Log($"{name} is attacking {command.Target.GetType().Name}");
        }
    }
}