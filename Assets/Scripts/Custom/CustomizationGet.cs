using UnityEngine;
using UnityEngine.SceneManagement;
namespace Claire
{
    public class CustomizationGet : MonoBehaviour
    {
        public PlayerHandler player;
        public Renderer characterMesh;
        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHandler>();
            characterMesh = GameObject.FindGameObjectWithTag("CharacterMesh").GetComponent<Renderer>();
            string[] tempName = new string[]
            {
                "Strength",
                "Dexterity",
                "Constitution",
                "Wisdom",
                "Intelligence",
                "Charisma"
            };
            for (int i = 0; i < tempName.Length; i++)
            { player.characterStats[i].name = tempName[i]; }
            Load();
        }
        private void Load()
        {
            if(!PlayerPrefs.HasKey("CharacterName"))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene(1);
            }
            player.name = PlayerPrefs.GetString("CharacterName");
            player.gameObject.name = PlayerPrefs.GetString("CharacterName");
            SetTexture("Skin", PlayerPrefs.GetInt("SkinIndex"));
            SetTexture("Eyes", PlayerPrefs.GetInt("EyesIndex"));
            SetTexture("Mouth", PlayerPrefs.GetInt("MouthIndex"));
            SetTexture("Hair", PlayerPrefs.GetInt("HairIndex"));
            SetTexture("Clothes", PlayerPrefs.GetInt("ClothesIndex"));
            SetTexture("Armour", PlayerPrefs.GetInt("ArmourIndex"));
            for(int i = 0; i < player.characterStats.Length; i++)
            {
                player.characterStats[i].value = 
                    PlayerPrefs.GetInt(player.characterStats[i].name);
            }
        }
        private void SetTexture(string type, int index)
        {
            Texture2D texture = null;
            int matIndex = 0;
            switch(type)
            {
                case "Skin":
                    texture = Resources.Load("Character/Skin_" + index) 
                        as Texture2D;
                    matIndex = 1;
                    break;
                case "Eyes":
                    texture = Resources.Load("Character/Eyes_" + index) 
                        as Texture2D;
                    matIndex = 2;
                    break;
                case "Mouth":
                    texture = Resources.Load("Character/Mouth_" + index) 
                        as Texture2D;
                    matIndex = 3;
                    break;
                case "Hair":
                    texture = Resources.Load("Character/Hair_" + index) 
                        as Texture2D;
                    matIndex = 4;
                    break;
                case "Clothes":
                    texture = Resources.Load("Character/Clothes_" + index) 
                        as Texture2D;
                    matIndex = 5;
                    break;
                case "Armour":
                    texture = Resources.Load("Character/Armour_" + index) 
                        as Texture2D;
                    matIndex = 6;
                    break;
            }
            Material[] mats = characterMesh.materials;
            mats[matIndex].mainTexture = texture;
            characterMesh.materials = mats;
        }
    }
}