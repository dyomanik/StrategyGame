using Abstractions.Commands.CommandsInterfaces;
using System.Threading.Tasks;
using UnityEngine;

namespace Core.CommandExecutors
{
    public sealed class SetCollectionPointCommandExecutor : CommandExecutorBase<ISetCollectionPointCommand>
    {
        public override async Task ExecuteSpecificCommand(ISetCollectionPointCommand command)
        {
            GetComponent<MainBuilding>().CollectionPoint = command.CollectionPoint;
            Debug.Log($"{name} has collection point at {command.CollectionPoint}!");
        }
    }
}
