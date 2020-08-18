using System;
using UnityEngine;
namespace Claire
{
    public class KinShop : KinInvParent
    {
        #region variables
        [Header("Shop Exclusive")]
        public ApprovalDialogue aD;
        public GameObject sortinButto;
        public string sortType = "";
        public string[] enumTypesForItems;
        #endregion
        public override void Start()
        {
            base.Start();
            inv.Add(ItemData.CreateItem(UnityEngine.Random.Range(0, 2)));
            enumTypesForItems = new string[]
            {
                "All", "Foood", "Weapon", "Apparel", "Crafting",
                "Ingredients", "Potions", "Scrolls", "Quest"
            };
            sortinButto.SetActive(false);
            slotKing.SetActive(false);
        }
        public override void Update()
        {
            base.Update();
        }
        public override void Initiate()
        {
            base.Initiate();
            if (!showInv)
            {
                showInv = false;
                otherInv.showInv = false;
                otherInv.otherInv = null;
                slotKing.SetActive(false);
            }
            if (showInv)
            {
                showInv = true;
                slotKing.SetActive(true);
            }
        }
        public override void Koshin()
        {
            base.Koshin();
            for (int i = 0; i < slots.Length; i++)
            {
                if (i < inv.Count)
                {
                    if (true)//type == "All")
                    {
                        slots[i].slotIcon.sprite = Sprite.Create(inv[i].Icon, new Rect(0, 0, inv[i].Icon.width, inv[i].Icon.height), Vector2.zero);
                        slots[i].slot.interactable = true;
                    }
                    else
                    {
                        
                    }
                }
                else
                {
                    slots[i].slot.interactable = false;
                    slots[i].slotIcon.sprite = blank;
                }
            }
        }
        public override void ItemSelect(int slotID)
        {
            base.ItemSelect(slotID);
        }
        public override void ItemUse()
        {
            base.ItemUse();
        }
        public override void ItemDiscard()
        {
            base.ItemDiscard();
            discardText.text = "Sell";
            money += selectedItem.Value;
            inv.Add(selectedItem);
            if (selectedItem.Amount > 1)
            {
                selectedItem.Amount--;
            }
            else
            {
                inv.Remove(selectedItem);
                selectedItem = null;
                return;
            }
        }
        #region ffffffffffffffffffffffffff
        public void Sort()
        {
            if (sortType == "All" || sortType == "")
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    selectedItem = inv[i];
                }
            }
            else
            {
                ItemType type = (ItemType)Enum.Parse(typeof(ItemType), sortType);
                int amount = 0;
                int position = 0;
                for (int  i = 0;  i < inv.Count;  i++)
                {
                    if (inv[i].Type == type)
                    {
                        amount++;
                        position++;
                    }
                }
            }
        }
        private void OnGUI()
        {
            if (showInv)
            {
                for (int i = 0; i < enumTypesForItems.Length; i++) //gui sorting buttons
                {
                    if (GUI.Button(new Rect(), enumTypesForItems[i]))
                    {
                        sortType = enumTypesForItems[i];
                    }
                }
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(), inv[i].Name))
                    {
                        selectedItem = inv[i];
                    }
                }
                if (selectedItem != null)
                {
                    GUI.Box(new Rect(), "");
                    GUI.Box(new Rect(), selectedItem.Icon);
                    GUI.Box(new Rect(), selectedItem.Name);
                    if (otherInv.money >= selectedItem.Value)
                    {
                        if (GUI.Button(new Rect(), "Buy"))
                        {
                            otherInv.money -= selectedItem.Value;
                            otherInv.inv.Add(selectedItem);
                            inv.Remove(selectedItem);
                            selectedItem = null;
                            return;
                        }
                    }
                }
                if (GUI.Button(new Rect(), "nop"))
                {
                    showInv = false;
                    otherInv.showInv = false;
                    otherInv.otherInv = null;
                    aD.Greetings();
                }
                GUI.Box(new Rect(), "‎¥" + otherInv.money);
            }
        }
#endregion
    }
}