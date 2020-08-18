using UnityEngine;
namespace Claire
{
    public class KinChest : KinInvParent
    {
        public override void Start()
        {
            base.Start();
            inv.Add(ItemData.CreateItem(Random.Range(0, 2)));
            slotKing.SetActive(false);
        }
        public override void Update()
        {
            base.Update();
            if (showInv)
            {
                if (Input.GetKeyDown(KeyBindManager.keys["Inventory"]) && !PauseMenu.isPaused)
                {
                    showInv = !showInv;
                    Initiate();
                }
            }
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
        }
        public override void ItemSelect(int slotID)
        {
            base.ItemSelect(slotID);
        }
        public override void ItemUse()
        {
            base.ItemUse();
            otherInv.inv.Add(selectedItem);
            inv.Remove(selectedItem);
            selectedItem = null;
            itemSelected.SetActive(false);
            base.ItemUse();
        }
        public override void ItemDiscard()
        {
            base.ItemDiscard();
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
                        adI = i;
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
            base.ItemDiscard();
        }
    }
}