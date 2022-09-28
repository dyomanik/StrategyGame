using Abstractions;
using Assets.Scripts.Abstractions;
using Core.CommandExecutors;
using UnityEngine;
using Utils;

namespace Core
{
    public class Chomper : MonoBehaviour, ISelectable, IAttackable, IUnit, IDamageDealer
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private int _damage = 25;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Animator _animator;
        [SerializeField] private StopCommandExecutor _stopCommand;

        private float _health = 100;

        public Transform Transform => _transform;
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;
        public int Damage => _damage;

        public void ReceiveDamage(int amount)
        {
            if (_health <= 0)
            {
                return;
            }
            _health -= amount;
            if (_health <= 0)
            {
                _animator.SetTrigger(UnitAnimationType.PLAYDEAD.ToString());
                Invoke(nameof(Destroy), 1f);
            }
        }

        private async void Destroy()
        {
            await _stopCommand.ExecuteSpecificCommand(new StopCommand());
            Destroy(gameObject);
        }
    }
}