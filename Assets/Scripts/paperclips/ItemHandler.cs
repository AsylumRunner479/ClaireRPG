using UnityEngine;
namespace Claire
{
    public class ItemHandler : MonoBehaviour
    {
        public int itemID;
        public ItemType itemType;
        public int amount;
        private void Start()
        {
            
        }
        public void OnCollection(KinInvParent inv)
        {
            if(itemType == ItemType.Money)
            {
                inv.money += amount;
            }
            else if(itemType == ItemType.Weapon || itemType == ItemType.Apparel || itemType == ItemType.Quest)
            {
                inv.inv.Add(ItemData.CreateItem(itemID));
            }
            else
            {
                int found = 0;
                int addIndex = 0;
                for (int i = 0; i < inv.inv.Count; i++)
                {
                    if(itemID == inv.inv[i].ID)
                    {
                        found = 1;
                        addIndex = i;
                        break;
                    }
                }
                if(found == 1)
                { inv.inv[addIndex].Amount += amount; }
                else
                {
                    inv.inv.Add(ItemData.CreateItem(itemID));
                    for (int i = 0; i < inv.inv.Count; i++)
                    {
                        if(itemID == inv.inv[i].ID)
                        { inv.inv[i].Amount = amount; }
                    }
                }
            }
            Destroy(gameObject);
        }
    }
}