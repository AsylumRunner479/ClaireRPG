using UnityEngine;
using UnityEngine.UI;
namespace Claire
{
    public class CanvasDialogueMaster : MonoBehaviour
    {
        [Header("User Interfacing")]
        public GameObject panel;
        public Text buttonText;
        public Text npcName;
        public Text textBox;
        public string theirName;
        public string[] dia;
        public int index;
        public Player.MouseLook playerMouse;
        public GameObject questButton;
        public QuestGiver questGiver;
        private void Start()
        {
            playerMouse = GameObject.FindGameObjectWithTag("Player").GetComponent<Player.MouseLook>();
        }
        public void SetUp()
        {
            npcName.text = theirName;
            textBox.text = dia[index];
            buttonText.text = "Next";
            if (questGiver.quest.goal.questState == QuestState.Complete || questGiver.quest.goal.questState == QuestState.Available)
            {
                questButton.SetActive(true);
            }
            else
            {
                questButton.SetActive(false);
            }
        }
        public void ClickyBitch()
        {
            if (!(index >= dia.Length - 1))
            {
                index++;
                if (index >= dia.Length - 1)
                {
                    buttonText.text = "Bye";
                }
            }
            else
            {
                index = 0;
                Camera.main.GetComponent<Player.MouseLook>().enabled = true;
                playerMouse.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                panel.SetActive(false);
            }
            npcName.text = theirName;
            textBox.text = dia[index];
        }
    }
}