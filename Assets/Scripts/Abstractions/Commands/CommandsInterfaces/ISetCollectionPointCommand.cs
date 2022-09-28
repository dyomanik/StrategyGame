using UnityEngine;

namespace Abstractions.Commands.CommandsInterfaces
{
    public interface ISetCollectionPointCommand : ICommand
    {
        public Vector3 CollectionPoint { get;}
    }
}
