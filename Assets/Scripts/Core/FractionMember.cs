using Abstractions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core
{
    public class FractionMember : MonoBehaviour, IFractionMember
    {
        [SerializeField] private int _fractionId;

        private static Dictionary<int, List<int>> _membersCount = 
            new Dictionary<int, List<int>>();

        public int FractionId => _fractionId;

        public static int FractionsCount
        {
            get
            {
                lock (_membersCount)
                {
                    return _membersCount.Count;
                }
            }
        }

        public static int GetWinner()
        {
            lock (_membersCount)
            {
                return _membersCount.Keys.First();
            }
        }

        private void Awake()
        {
            if (_fractionId != 0)
            {
                Register();
            }
        }

        private void OnDestroy()
        {
            Unregister();
        }

        private void Register()
        {
            lock (_membersCount)
            {
                if (!_membersCount.ContainsKey(_fractionId))
                {
                    _membersCount.Add(_fractionId, new List<int>());
                }
                if (!_membersCount[_fractionId].Contains(GetInstanceID()))
                {
                    _membersCount[_fractionId].Add(GetInstanceID());
                }
            }
        }

        private void Unregister()
        {
            lock (_membersCount)
            {
                if (_membersCount[_fractionId].Contains(GetInstanceID()))
                {
                    _membersCount[_fractionId].Remove(GetInstanceID());
                }
                if (_membersCount[_fractionId].Count == 0)
                {
                    _membersCount.Remove(_fractionId);
                }
            }
        }

        public void SetFraction(int fractionId)
        {
            _fractionId = fractionId;
        }
    }
}