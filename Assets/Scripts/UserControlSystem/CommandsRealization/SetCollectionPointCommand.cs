using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem.CommandsRealization
{
    public class SetCollectionPointCommand : ISetCollectionPointCommand
    {
        public Vector3 CollectionPoint { get; }

        public SetCollectionPointCommand(Vector3 collectionPoint)
        {
            CollectionPoint = collectionPoint;
        }
    }
}
