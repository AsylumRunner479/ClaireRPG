using System;
using UnityEngine;
namespace Claire
{
    public class KinInventory : KinInvParent
    {
        #region variables
        [Serializable]
        public struct Equipment
        {
            public string slotName;
            public Transform equipLocation;
            public GameObject currentItem;
            public Slots zlotz;
        };
        [Header("Inventory Exclusive")]
        public Transform dropLocation;
        public Equipment[] equipmentSlots;
        #endregion
        public override void Start()
        {
            base.Start();
            slotKing.SetActive(true);
        }
        public override void Update()
        {
            base.Update();
            if (Input.GetKeyDown(KeyBindManager.keys["Inventory"]) && !PauseMenu.isPaused && otherInv == null)
            {
                showInv = !showInv;
                Initiate();
            }
        }
        public override void Initiate()
        {
            base.Initiate();
        }
        public override void Koshin()
        {
            base.Koshin();
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                if (equipmentSlots[i].zlotz.slotItem != null)
                {
                    equipmentSlots[i].zlotz.slotIcon.sprite = Sprite.Create(equipmentSlots[i].zlotz.slotItem.Icon, new Rect(0, 0, equipmentSlots[i].zlotz.slotItem.Icon.width, equipmentSlots[i].zlotz.slotItem.Icon.height), Vector2.zero);
                }
                else
                {
                    equipmentSlots[i].zlotz.slotIcon.sprite = blank;
                }
            }
            base.Koshin();
        }
        public override void ItemSelect(int slotID)
        {
            base.ItemSelect(slotID);
            if (otherInv == null)
            {
                switch (selectedItem.Type)
                {
                    #region case ItemType.Foood:
                    case ItemType.Foood:
                        useText.text = "Eat";
                        if (player.attributes[0].currentValue < player.attributes[0].maxValue)
                        { useButton.interactable = true; }
                        else
                        { useButton.interactable = false; }
                        break;
                    #endregion
                    #region case ItemType.Weapon:
                    case ItemType.Weapon:
                        useButton.interactable = true;
                        if (equipmentSlots[2].currentItem == null || selectedItem.Name != equipmentSlots[2].currentItem.name)
                        { useText.text = "Equip"; }
                        else
                        { useText.text = "Unequipt"; }
                        break;
                    #endregion
                    #region case ItemType.Apparel:
                    case ItemType.Apparel:
                        // "Wear"
                        break;
                    #endregion
                    #region case ItemType.Crafting:
                    case ItemType.Crafting:
                        useButton.interactable = false;
                        break;
                    #endregion
                    #region case ItemType.Ingredients:
                    case ItemType.Ingredients:
                        useButton.interactable = false;
                        break;
                    #endregion
                    #region case ItemType.Potions:
                    case ItemType.Potions:
                        useText.text = "Drink";
                        if (player.attributes[2].currentValue < player.attributes[2].maxValue)
                        { useButton.interactable = true; }
                        else
                        { useButton.interactable = false; }
                        break;
                    #endregion
                    #region case ItemType.Scrolls:
                    case ItemType.Scrolls:
                        // "Read"
                        break;
                    #endregion
                    default:
                        break;
                }
            }
        }
        public override void ItemUse()
        {
            base.ItemUse();
            if(otherInv == null)
            {
                switch (selectedItem.Type)
                {
                    #region case ItemType.Foood:
                    case ItemType.Foood:
                        player.attributes[0].currentValue = Mathf.Clamp(player.attributes[0].currentValue += selectedItem.Heal, 0, player.attributes[0].maxValue);
                        if (selectedItem.Amount == 1)
                        {
                            inv.Remove(selectedItem);
                            selectedItem = null;
                            itemSelected.SetActive(false);
                            return;
                        }
                        if (selectedItem.Amount > 1)
                        {
                            selectedItem.Amount--;
                            itemAmount.text = "#" + selectedItem.Amount.ToString();
                        }
                        break;
                    #endregion
                    #region case ItemType.Weapon:
                    case ItemType.Weapon:
                        if (equipmentSlots[2].currentItem == null || selectedItem.Name != equipmentSlots[2].currentItem.name)
                        {
                            if (equipmentSlots[2].currentItem != null)
                            {
                                Destroy(equipmentSlots[2].currentItem);
                            }
                            GameObject curItem = Instantiate(selectedItem.Mesh, equipmentSlots[2].equipLocation);
                            equipmentSlots[2].currentItem = curItem;
                            curItem.name = selectedItem.Name;
                            useText.text = "Unequipt";
                        }
                        else
                        {
                            useText.text = "Equipt";
                            Destroy(equipmentSlots[2].currentItem);
                        }
                        break;
                    #endregion
                    #region case ItemType.Apparel:
                    case ItemType.Apparel:

                        break;
                    #endregion
                    #region case ItemType.Potions:
                    case ItemType.Potions:
                        player.attributes[2].currentValue = Mathf.Clamp(player.attributes[2].currentValue += selectedItem.Heal, 0, player.attributes[2].maxValue);
                        if (selectedItem.Amount == 1)
                        {
                            inv.Remove(selectedItem);
                            selectedItem = null;
                            itemSelected.SetActive(false);
                            return;
                        }
                        if (selectedItem.Amount > 1)
                        { selectedItem.Amount--; }
                        break;
                    #endregion
                    #region case ItemType.Scrolls:
                    case ItemType.Scrolls:

                        break;
                    #endregion
                    default:
                        break;
                }
            }
            base.ItemUse();
        }
        public override void ItemDiscard()
        {
            base.ItemDiscard();
            if (otherInv == null)
            {
                discardText.text = "Discard";
                for (int i = 0; i < equipmentSlots.Length; i++)
                {
                    if (equipmentSlots[i].currentItem != null && selectedItem.Name == equipmentSlots[i].currentItem.name)
                    {
                        Destroy(equipmentSlots[i].currentItem);
                    }
                }
                GameObject droppedItem = Instantiate(selectedItem.Mesh, dropLocation.position, Quaternion.identity);
                droppedItem.name = selectedItem.Name;
                droppedItem.AddComponent<Rigidbody>().useGravity = true;
                droppedItem.GetComponent<ItemHandler>().enabled = true;
                if (selectedItem.Amount > 1)
                {
                    selectedItem.Amount--;
                }
                else
                {
                    inv.Remove(selectedItem);
                    selectedItem = null;
                }
                itemSelected.SetActive(false);
            }
            else if (otherInv.gameObject.tag == "Chest")
            {
                if (selectedItem.Type == ItemType.Weapon || selectedItem.Type == ItemType.Apparel || selectedItem.Type == ItemType.Quest)
                {
                    otherInv.inv.Add(selectedItem);
                }
                else
                {
                    int found = 0;
                    int adI = 0;
                    for (int i = 0; i < otherInv.inv.Count; i++)
                    {
                        if (selectedItem.ID == otherInv.inv[i].ID)
                        {
                            found = 1;
                            adI = 1;
                            break;
                        }
                    }
                    if (found == 1)
                    {
                        otherInv.inv[adI].Amount += selectedItem.Amount;
                    }
                    else
                    {
                        otherInv.inv.Add(selectedItem);
                    }
                }
                inv.Remove(selectedItem);
                selectedItem = null;
            }
            base.ItemDiscard();
        }
    }
}