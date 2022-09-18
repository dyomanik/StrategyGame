using Abstractions;
using System;
using UnityEngine;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(AttackableValue), menuName = "Strategy Game/" + nameof(AttackableValue), order = 0)]
    public class AttackableValue : StatelessScriptableValueBase<IAttackable>
    {
       
    }
}