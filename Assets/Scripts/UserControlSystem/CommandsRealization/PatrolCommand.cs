using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem.CommandsRealization
{
    public class PatrolCommand : IPatrolCommand
    {
        public Vector3 Start { get; }
        public Vector3 Target { get; }

        public PatrolCommand(Vector3 start, Vector3 target)
        {
            Start = start;
            Target = target;
        }
    }
}
