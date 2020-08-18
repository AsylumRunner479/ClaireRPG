using UnityEngine;
namespace Claire
{
    public class OptionLinearDialogue : MonoBehaviour
    {
        #region Variables
        [Header("References")]
        public bool showDia;
        public int index, optionIndex;
        public Vector2 scr;
        public GameObject player;
        private Player.MouseLook mouseLook;
        [Header("NPC Name and Dialogue")]
        public new string name;
        public string[] diaText;
        #endregion
        private void OnGUI()
        {
            if (showDia)
            {
                scr.x = Screen.width / 16;
                scr.y = Screen.height / 9;
                GUI.Box(new Rect(0, 6 * scr.y, Screen.width, 3 * scr.y), name + " : " + diaText[index]);
                if (!(index >= diaText.Length - 1 || index == optionIndex))
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.5f * scr.y, scr.x, 0.5f * scr.y), "Next"))
                    {
                        index++;
                    }
                }
                else if (index == optionIndex)
                {
                    if (GUI.Button(new Rect(10 * scr.x, 8.5f * scr.y, scr.x, scr.y * 0.5f), "Ja"))
                    {
                        index++;
                    }
                    if (GUI.Button(new Rect(15 * scr.x, 8.5f * scr.y, scr.x, scr.y * 0.5f), "Nien"))
                    {
                        index = diaText.Length - 1;
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
    }
}