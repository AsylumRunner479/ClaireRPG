using UnityEngine;
using UnityEngine.UI;
namespace Claire
{
    [AddComponentMenu("Game Systems/RPG/Dialogue Linear")]
    public class Dialogue : MonoBehaviour
    {
        [Header("References")]
        public bool showDia;
        public int index;
        public GameObject player;
        public Player.MouseLook mouseLook;
        [Header("User Interfacing")]
        public GameObject panel;
        public Text npcName;
        public Text textBox;
        public GameObject next;
        public GameObject bye;
        [Header("NPC Name and Dialogue")]
        public new string name;
        public string[] diaText;
        public void CallDialogue()
        {
            showDia = true;
            npcName.text = name;
            textBox.text = diaText[index];
            panel.SetActive(true);
        }
        public void NextBitch()
        {
            index++;
            if(index >= (index - 1))
            {
                bye.SetActive(true);
                next.SetActive(false);
            }
        }
        public void ByeBitch()
        {
            showDia = false;
            index = 0;
            Camera.main.GetComponent<Player.MouseLook>().enabled = true;
            mouseLook.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        /*
        private void OnGUI()
        {
            Vector2 scr;
            scr.x = Screen.width / 16;
            scr.y = Screen.height / 9;
            if (showDia)
            {
                GUI.Box(new Rect(0, 6 * scr.y, Screen.width, scr.y * 3), name + " : " + diaText[index]);
                if (index < diaText[index].Length - 1)
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.5f * scr.y, scr.x, scr.y * 0.5f), "Next"))
                    {
                        index++;
                        Debug.Log(index);
                    }
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
        */
    }
}