using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    /// <summary>
    /// Changes level
    /// </summary>
    public class LevelChooser : MonoBehaviour
    {
        [SerializeField] private SceneAsset nextScene;
        
        public void OnClickContinueBtn()
        {
            SceneManager.LoadSceneAsync(nextScene.name);
        } 
        public void OnClickRestartBtn()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }
    }
}