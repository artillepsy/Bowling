using System;
using UnityEngine;
using UnityEngine.Events;

namespace Gates
{
    public class Gate : MonoBehaviour
    {
        [SerializeField] private OperationType operationType;
        [SerializeField] private int secondArg = 10;
        
        public static UnityEvent<Func<int, int, int>, int> OnGateActivated = new UnityEvent<Func<int, int, int>, int>();
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.transform.parent.CompareTag("Ball")) return;
                
            switch (operationType)
            {
                case OperationType.Difference:
                    OnGateActivated?.Invoke(GateOperations.Difference, secondArg);
                    break;
                case OperationType.Multiplication:
                    OnGateActivated?.Invoke(GateOperations.Multiplication, secondArg);
                    break;
                case OperationType.Sum:
                    OnGateActivated?.Invoke(GateOperations.Sum, secondArg);
                    break;
            }
            Destroy(gameObject);
        }
    }
}