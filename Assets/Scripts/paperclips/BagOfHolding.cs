using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Claire
{
    public class BagOfHolding
    {
        /*public Item selectedItem;
        public string sortType = "";
        public static int money;
        public static List<Item> inv = new List<Item>();
        public static bool showInv;
        public static Breast currentChest;
        public static Shop currentShop;
        public GameObject panel;
        public Sprite blank;
        public GameObject itemSelected;
        public Image iconSelected;
        public Text itemName, itemDes, itemYen, itemAmount, useText, discardText;
        public Button useButton, discardButton;
        public void UseItem()
        {
            if (currentChest == null)
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
                            useText.text = "Equip";
                        }
                        else
                        {
                            useText.text = "Unequipt";
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
        }*/
    }
}