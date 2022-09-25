using UnityEngine;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem.CommandsRealization;

namespace UserControlSystem.UI.Model.CommandCreator
{
    public sealed class SetCollectionPointCommandCreator : CancellableCommandCreatorBase<ISetCollectionPointCommand, Vector3>
    {
        protected override ISetCollectionPointCommand CreateCommand(Vector3 argument) => new SetCollectionPointCommand(argument);
    }
}
