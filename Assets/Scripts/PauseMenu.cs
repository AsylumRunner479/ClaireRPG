using UnityEngine;
namespace Claire
{
    public class PauseMenu : MonoBehaviour
    {
        public static bool isPaused;
        public GameObject pauseMenu, optionsMenu;
        public KinInventory kInv;
        void Start()
        {
            kInv = GameObject.FindGameObjectWithTag("Player").GetComponent<KinInventory>();
            UnPaused();
        }
        void Update()
        {
            if (Input.GetButtonDown("Cancel"))
            {
                if (!optionsMenu.activeSelf)
                { TogglePause(); }
                else
                {
                    pauseMenu.SetActive(true);
                    optionsMenu.SetActive(false);
                }
            }
        }
        void Paused()
        {
            isPaused = true;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        public void UnPaused()
        {
            isPaused = false;
            if(!kInv.showInv)
            {
                Time.timeScale = 1;
            }
            pauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        void TogglePause()
        {
            if(!isPaused)
            { Paused(); }
            else
            { UnPaused(); }
        }
    }
}