using Literals;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    /// <summary>
    /// Changes level
    /// </summary>
    public class LevelChooser : MonoBehaviour
    {
        [SerializeField] private Levels nextLevel = Levels.Second;
        [SerializeField] private Levels currentLevel = Levels.First;
        
        public void OnClickContinueBtn()
        {
            SceneManager.LoadSceneAsync(GetLevelName(nextLevel));
        } 
        public void OnClickRestartBtn()
        {
            SceneManager.LoadSceneAsync(GetLevelName(currentLevel));
        }

        private string GetLevelName(Levels level)
        {
            return level switch
            {
                Levels.First => LevelNames.Level1,
                Levels.Second => LevelNames.Level2,
            };
        }
    }
}