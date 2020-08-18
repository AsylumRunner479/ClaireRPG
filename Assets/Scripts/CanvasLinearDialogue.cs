using UnityEngine;
using UnityEngine.UI;
namespace Homework
{
    [AddComponentMenu("Game Systems/RPG/Dialogue Linear")]
    public class Dialogue : MonoBehaviour
    {
        /*
        #region Variables
        [Header("References")]
        public bool showDia;
        public int index;
        public Vector2 scr;
        public GameObject player;
        public Player.MouseLook mouseLook;
        [Header("NPC Name and Dialogue")]
        public new string name;
        public string[] diaText;
        public bool decision = false;
        #endregion
        #region Start
        find and reference the player object by tag
        find and reference the maincamera by tag and get the mouse look component 
        #endregion
        #region OnGUI
        private void OnGUI()
        {
            if (showDia)
            {
                scr.x = Screen.width / 16;
                scr.y = Screen.height / 9;
                GUI.Box(new Rect(0, 6 * scr.y, Screen.width, scr.y * 3), name + " : " + diaText[index]);
                if (GUI.Button(new Rect(15 * scr.x, 8.5f * scr.y, scr.x, scr.y * 0.5f), "Next"))
                {
                    index++;
                }
                else
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.5f * scr.y, scr.x, scr.y * 0.5f), "Bye"))
                    {
                        showDia = false;
                        index = 0;
                        Camera.main.GetComponent<Player.MouseLook>().enabled = true;
                        mouseLook.enabled = true;
                        Cursor.lockState = CursorLockMode.Locked;
                        Cursor.visible = false;
                    }
                }
            }
        }
        #endregion
        */
        public GameObject dialoguePanel;
        public Text dialogueText;
        public string[] currentDialouge;
        public int index;
        public Player.MouseLook playerMouseLook;
        public void NextDialogue()
        {
            if (!(index >= currentDialouge.Length -1))
            {
                index++;
            }
            else
            {

            }
        }

        private void Start()
        {
            
        }
        
        public void OnEnable()
        {
            
        }
    }
}