using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Claire
{
    public class KeyBindManager : MonoBehaviour
    {
        public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
        public Text forward, left, right, backwards, jump, sprint, crouch, interact, inventory;
        public GameObject currentKey;
        public Color32 changed = new Color32(39, 171, 249, 255);
        public Color32 selected = new Color32(239, 116, 36, 255);
        public Text axisFaggot;
        public bool getAxisMode = true;
        void Start()
        {
            DontDestroyOnLoad(this.gameObject);
            keys.Add("Forward",   (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Forward",   "W")));
            keys.Add("Left",      (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left",      "A")));
            keys.Add("Right",     (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right",     "D")));
            keys.Add("Backwards", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Backwards", "S")));
            keys.Add("Jump",      (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump",      "Space")));
            keys.Add("Sprint",    (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Sprint",    "C")));
            keys.Add("Crouch",    (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Crouch",    "LeftShift")));
            keys.Add("Interact",  (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Interact",  "E")));
            keys.Add("Inventory", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Inventory", "Q")));
            forward.text   = keys["Forward"].ToString();
            left.text      = keys["Left"].ToString();
            right.text     = keys["Right"].ToString();
            backwards.text = keys["Backwards"].ToString();
            jump.text      = keys["Jump"].ToString();
            sprint.text    = keys["Sprint"].ToString();
            crouch.text    = keys["Crouch"].ToString();
            interact.text  = keys["Interact"].ToString();
            inventory.text = keys["Inventory"].ToString();
        }
        private void OnGUI()
        {
            if (currentKey != null)
            {
                string newKey = "";
                Event e = Event.current;
                if (e.isKey)
                { newKey = e.keyCode.ToString(); }
                if (Input.GetKey(KeyCode.LeftShift))
                { newKey = "LeftShift"; }
                if (Input.GetKey(KeyCode.RightShift))
                { newKey = "RightShift"; }
                if (newKey != "")
                {
                    keys[currentKey.name] = (KeyCode)Enum.Parse(typeof(KeyCode), newKey);
                    currentKey.GetComponentInChildren<Text>().text = newKey;
                    currentKey.GetComponent<Image>().color = changed;
                    currentKey = null;
                }
            }
        }
        public void ToggleWhore()
        {
            getAxisMode = !getAxisMode;
            if (getAxisMode)
            {
                axisFaggot.text = "Axis Mode";
            }
            else if (!getAxisMode)
            {
                axisFaggot.text = "Keybind Mode";
            }
        }
        public void ChangeKey(GameObject clicked)
        {
            currentKey = clicked;
            if (currentKey != null)
            { currentKey.GetComponent<Image>().color = selected; }
        }
        public void SaveKeys()
        {
            foreach (var key in keys)
            { PlayerPrefs.SetString(key.Key, key.Value.ToString()); }
            PlayerPrefs.Save();
        }
    }
}