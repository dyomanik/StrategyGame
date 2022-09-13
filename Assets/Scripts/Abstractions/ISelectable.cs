using UnityEngine;

namespace Abstractions
{
    public interface ISelectable : IHealthHolder
    {
        Transform Transform { get; }

        Sprite Icon { get; }
    }
}