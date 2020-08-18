using UnityEngine;
using UnityEngine.UI;
namespace Claire
{
    public class ApprovalDialogue : MonoBehaviour
    {
        #region Variables
        [Header("References")]
        public int index;
        public int? optionIndex = 0;
        public GameObject player;
        private Player.MouseLook mouseLook;
        public KinShop myShop;
        public QuestGiver myQuest;
        [Header("NPC Name and Dialogue")]
        public new string name;
        public string[] diaText;
        public string[] negText, neuText, posText;
        public int approvalAmount;
        [Header("Canvas is a fucking bittttchhhhhhhhh")]
        public GameObject diaPanel;
        public RawImage face;
        public Text itName, itDia;
        public Button nextB, yesB, noB, shopB, questB, byeB;
        #endregion
        private void Start()
        {
            Debug.LogWarning("Approval Dialogue Start");
            if (this.gameObject.name == "Ben")
            {
                optionIndex = null;
                myQuest = null;
            }
            if (this.gameObject.name == "Kevin")
            {
                optionIndex = 3;
                myShop = null;
            }
            mouseLook = player.GetComponent<Player.MouseLook>();
            diaText = neuText;
            nextB.gameObject.SetActive(true);
            yesB.gameObject.SetActive(false);
            noB.gameObject.SetActive(false);
            shopB.gameObject.SetActive(false);
            questB.gameObject.SetActive(false);
            byeB.gameObject.SetActive(false);
            diaPanel.SetActive(false);
        }
        public void Greetings()
        {
            Debug.LogWarning("Approval Dialogue Greetings");
            if (approvalAmount <= -1)
            {
                diaText = negText;
            }
            else if (approvalAmount == 0)
            {
                diaText = neuText;
            }
            else if (approvalAmount >= 1)
            {
                diaText = posText;
            }
            mouseLook.enabled = false;
            Camera.main.GetComponent<Player.MouseLook>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            itName.text = name;
            itDia.text = diaText[index];
            if (this.GetComponent<KinShop>() != null)
            {
                shopB.gameObject.SetActive(true);
            }
            if (this.GetComponent<QuestGiver>() != null)
            {
                questB.gameObject.SetActive(true);
            }
            diaPanel.SetActive(true);
        }
        public void Farewell()
        {
            Debug.LogWarning("Approval Dialogue Farewell");
            index = 0;
            mouseLook.enabled = true;
            Camera.main.GetComponent<Player.MouseLook>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            nextB.gameObject.SetActive(true);
            byeB.gameObject.SetActive(false);
            diaPanel.SetActive(false);
        }
        #region public void Buttons
        public void ButtonNext()
        {
            Debug.LogWarning("Button Next");
            index++;
            if (!(index >= diaText.Length -1 || index == optionIndex))
            {
                itDia.text = diaText[index];
            }
            else if (index == optionIndex)
            {
                yesB.gameObject.SetActive(true);
                noB.gameObject.SetActive(true);
                nextB.gameObject.SetActive(false);
            }
            else
            {
                byeB.gameObject.SetActive(true);
                nextB.gameObject.SetActive(false);
            }
        }
        public void ButtonYes()
        {
            index++;
            if (approvalAmount < 1)
            {
                approvalAmount++;
            }
            yesB.gameObject.SetActive(false);
            noB.gameObject.SetActive(false);
            nextB.gameObject.SetActive(true);
        }
        public void ButtonNo()
        {
            index = diaText.Length - 1;
            if (approvalAmount > -1)
            {
                approvalAmount--;
            }
            yesB.gameObject.SetActive(false);
            noB.gameObject.SetActive(false);
            nextB.gameObject.SetActive(true);
        }
        public void ButtonShop()
        {
            Debug.LogWarning("Button Shop");
            myShop.showInv = true;
            KinInvParent inv = player.GetComponent<KinInventory>();
            inv.showInv = true;
            inv.otherInv = myShop;
            myShop.otherInv = inv;
            myShop.Initiate();
        }
        public void ButtonQuest()
        {

        }
        public void ButtonBye()
        {
            Debug.LogWarning("Bye fucker");
            Farewell();
        }
        #endregion
    }
}