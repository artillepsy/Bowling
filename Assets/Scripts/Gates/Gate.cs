using System;
using Literals;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Gates
{
    public class Gate : MonoBehaviour
    {
        [SerializeField] private OperationType operationType;
        [SerializeField] private int secondArg = 10;
        [SerializeField] private TextMeshPro operationLabel;
        
        [SerializeField] UnityEvent OnActivated = new UnityEvent(); 
        public static UnityEvent<Func<int, int, int>, int> OnGateActivated = new UnityEvent<Func<int, int, int>, int>();
        
        private void Awake()
        {
            var str = operationType switch
            {
                OperationType.Difference => "-",
                OperationType.Multiplication => "*",
                OperationType.Sum => "+"
            };
            operationLabel.text = str + secondArg;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Tags.Ball)) return;
            OnActivated?.Invoke();       
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
        }
    }
}