using UnityEngine;
using UnityEngine.SceneManagement;
namespace Claire
{
    public class MenuButtons : MonoBehaviour
    {
        public void ChangeScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}