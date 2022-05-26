using BallManipulation;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Shows fail canvas when there are no active balls on scene
    /// </summary>
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