using UnityEngine;

namespace Abstractions
{
    public interface ISelectable
    {
        Transform Transform { get; }
        float Health { get; }
        float MaxHealth { get; }
        Sprite Icon { get; }
    }
}