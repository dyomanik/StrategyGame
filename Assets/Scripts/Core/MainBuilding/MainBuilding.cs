using Abstractions;
using UnityEngine;

namespace Core
{
    public sealed class MainBuilding : MonoBehaviour, ISelectable, IAttackable
    {
        [SerializeField] private Transform _unitsParent;
        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Transform _transform;

        private float _health = 1000;

        public Transform Transform => _transform;
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;
        public Vector3 CollectionPoint { get; set; }

        public void ReceiveDamage(int amount)
        {
            if (_health <= 0)
            {
                return;
            }
            _health -= amount;
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}