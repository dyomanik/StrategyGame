using Abstractions;
using UnityEngine;

namespace Core
{
    public class FractionMember : MonoBehaviour, IFractionMember
    {
        public int FractionId => _fractionId;
        [SerializeField] private int _fractionId;

        public void SetFraction(int fractionId)
        {
            _fractionId = fractionId;
        }
    }
}