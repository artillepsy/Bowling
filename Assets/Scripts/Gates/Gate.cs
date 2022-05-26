using System;
using Literals;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Gates
{
    /// <summary>
    /// Manipulates ball count 
    /// </summary>
    public class Gate : MonoBehaviour
    {
        [SerializeField] private OperationType operationType;
        [SerializeField] private TextMeshPro operationLabel;
        [SerializeField] private int secondOperand = 10;
        [SerializeField] UnityEvent OnActivated = new UnityEvent(); 
        public static UnityEvent<Func<int, int, int>, int> OnGateActivated = new UnityEvent<Func<int, int, int>, int>();
        
        private void Awake()
        {
            var sign = operationType switch
            {
                OperationType.Difference => "-",
                OperationType.Multiplication => "*",
                OperationType.Sum => "+"
            };
            operationLabel.text = sign + secondOperand;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Tags.Ball)) return;
            OnActivated?.Invoke();       
            switch (operationType)
            {
                case OperationType.Difference:
                    OnGateActivated?.Invoke(GateOperations.Difference, secondOperand);
                    break;
                case OperationType.Multiplication:
                    OnGateActivated?.Invoke(GateOperations.Multiplication, secondOperand);
                    break;
                case OperationType.Sum:
                    OnGateActivated?.Invoke(GateOperations.Sum, secondOperand);
                    break;
            }
        }
    }
}