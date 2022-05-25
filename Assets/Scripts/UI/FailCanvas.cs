using BallManipulation;
using UnityEngine;

namespace UI
{
    public class FailCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject canvas;

        private void Start()
        {
            canvas.SetActive(false);
            BallCountChanger.OnGameOver.AddListener(() => canvas.SetActive(true));
        }
    }
}