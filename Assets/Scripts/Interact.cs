using UnityEngine;
namespace Claire
{
    [AddComponentMenu("Game Systems/RPG/Player/Interact")]
    public class Interact : MonoBehaviour
    {
        public PlayerHandler player;
        public CanvasDialogueMaster cDM;
        private void Update()
        {
            if (Input.GetKey(KeyBindManager.keys["Interact"]) && !PauseMenu.isPaused)
            {
                Ray interact = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
                RaycastHit hitInfo;
                if (Physics.Raycast(interact, out hitInfo, 50))
                {
                    #region NPC
                    if (hitInfo.collider.CompareTag("NPC"))
                    {
                        if (hitInfo.collider.GetComponent<ThisGoesOnThem>())
                        {
                            ThisGoesOnThem npc = hitInfo.collider.GetComponent<ThisGoesOnThem>();
                            cDM.theirName = npc.nameString;
                            cDM.dia = npc.diaString;
                            cDM.SetUp();
                            cDM.panel.SetActive(true);
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                            Camera.main.GetComponent<Player.MouseLook>().enabled = false;
                            GetComponent<Player.MouseLook>().enabled = false;
                        }
                        if (hitInfo.collider.GetComponent<Dialogue>())
                        {
                            hitInfo.collider.GetComponent<Dialogue>().showDia = true;
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                            Camera.main.GetComponent<Player.MouseLook>().enabled = false;
                            GetComponent<Player.MouseLook>().enabled = false;
                        }
                        if (hitInfo.collider.GetComponent<OptionLinearDialogue>())
                        {
                            hitInfo.collider.GetComponent<OptionLinearDialogue>().showDia = true;
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                            Camera.main.GetComponent<Player.MouseLook>().enabled = false;
                            GetComponent<Player.MouseLook>().enabled = false;
                        }
                        if (hitInfo.collider.GetComponent<ApprovalDialogue>())
                        {
                            hitInfo.collider.GetComponent<ApprovalDialogue>().Greetings();
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                            Camera.main.GetComponent<Player.MouseLook>().enabled = false;
                            GetComponent<Player.MouseLook>().enabled = false;
                        }
                    }
                    #endregion
                    #region Item
                    if (hitInfo.collider.gameObject.CompareTag("Item"))
                    {
                        ItemHandler handler = hitInfo.transform.GetComponent<ItemHandler>();
                        if(handler != null)
                        {
                            player.currentQuest.goal.ItemCollected(handler.itemID);
                            handler.OnCollection(player.gameObject.GetComponent<KinInventory>());
                        }
                    }
                    #endregion
                    #region Chest
                    if(hitInfo.collider.CompareTag("Chest"))
                    {
                        KinInvParent curChest = hitInfo.transform.GetComponent<KinChest>();
                        if(curChest != null)
                        {
                            curChest.showInv = true;
                            KinInvParent inv = player.gameObject.GetComponent<KinInventory>();
                            inv.showInv = true;
                            inv.otherInv = curChest;
                            curChest.otherInv = inv;
                            curChest.Initiate();
                        }
                    }
                    #endregion
                }
            }
        }
    }
}