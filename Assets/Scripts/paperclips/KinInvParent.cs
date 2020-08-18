using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Claire
{
    public class KinInvParent : MonoBehaviour
    {
        #region variables
        [Serializable]
        public struct Slots
        {
            public Button slot;
            public Image slotIcon;
            public Item slotItem;
        };
        [Header("General")]
        public PlayerHandler player;
        public int money;
        public bool showInv;
        public List<Item> inv = new List<Item>();
        public Item selectedItem;
        public KinInvParent otherInv;
        [Header("Canvas References")]
        public GameObject panel;
        public GameObject slotKing;
        public Slots[] slots;
        [Header("Selected Exclusive")]
        public Sprite blank;
        public GameObject itemSelected;
        public Image iconSelected;
        public Text itemName, itemDes, itemAmount, itemYen, useText, discardText;
        public Button useButton, discardButton;
        public GameObject myUse, myDis, otherUse, otherDis;
        #endregion
        public virtual void Start()
        {
            player = gameObject.GetComponent<PlayerHandler>();
            useButton.interactable = false;
            discardButton.interactable = true;
            itemSelected.SetActive(false);
            panel.SetActive(false);
        }
        public virtual void Update()
        {

        }
        public virtual void Initiate()
        {
            if (!showInv)
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                selectedItem = null;
                otherInv = null;
                itemSelected.SetActive(false);
                panel.SetActive(false);
                return;
            }
            if (showInv)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                panel.SetActive(true);
                Koshin();
            }
        }
        public virtual void Koshin()
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (i < inv.Count)
                {
                    slots[i].slotIcon.sprite = Sprite.Create(inv[i].Icon, new Rect(0, 0, inv[i].Icon.width, inv[i].Icon.height), Vector2.zero);
                    slots[i].slot.interactable = true;
                }
                else
                {
                    slots[i].slot.interactable = false;
                    slots[i].slotIcon.sprite = blank;
                }
            }
        }
        public virtual void ItemSelect(int slotID)
        {
            selectedItem = inv[slotID];
            if (slotID < inv.Count && inv.Count > 0)
            {
                iconSelected.sprite = slots[slotID].slotIcon.sprite;
                itemName.text = inv[slotID].Name;
                itemDes.text = inv[slotID].Description;
                itemYen.text = "¥" + inv[slotID].Value.ToString();
                itemAmount.text = "#" + inv[slotID].Amount.ToString();
                myUse.SetActive(true);
                myDis.SetActive(true);
                otherUse.SetActive(false);
                otherDis.SetActive(false);
                itemSelected.SetActive(true);
            }
        }
        public virtual void ItemUse()
        {
            Koshin();
        }
        public virtual void ItemDiscard()
        {
            Koshin();
        }
    }
}