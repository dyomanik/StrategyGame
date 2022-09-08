using UnityEngine;

namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IPatrolCommand : ICommand
    {
        public Vector3 Start { get; }
        public Vector3 Target { get; }
    }
}