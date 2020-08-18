using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Claire
{
    public class CustomizationSet : MonoBehaviour
    {
        #region Variables
        [Header("Character Name")]
        public string characterName;
        [Header("Character Class")]
        public CharacterClass charClass = CharacterClass.Barbarian;
        public string[] selectedClass = new string[8];
        public int selectedIndex = 0;
        [Header("Dropdown Menu")]
        public bool showDropdown;
        public Vector2 scrollPos;
        public string classButton = "";
        public int statPoints = 10;
        [Header("Texture List")]
        public List<Texture2D> skin = new List<Texture2D>();
        public List<Texture2D> eyes = new List<Texture2D>();
        public List<Texture2D> mouth = new List<Texture2D>();
        public List<Texture2D> hair = new List<Texture2D>();
        public List<Texture2D> clothes = new List<Texture2D>();
        public List<Texture2D> armour = new List<Texture2D>();
        [Header("Index")]
        public int skinIndex;
        public int eyesIndex, mouthIndex, hairIndex, clothesIndex, 
            armourIndex;
        [Header("Renderer")]
        public Renderer characterRenderer;
        [Header("Max Intex")]
        public int skinMax;
        public int eyesMax, mouthMax, hairMax, clothesMax,
            armourMax;
        #endregion
        #region Functions
        private void Start()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            selectedClass = new string[]
            {
                "Barbarian",
                "Bard",
                "Druid",
                "Monk",
                "Paladin",
                "Ranger",
                "Sorcerer",
                "Warlock"
            };
            string[] tempName = new string[]
            {
                "Strength",
                "Dexterity",
                "Constitution",
                "Wisdom",
                "Intelligence",
                "Charisma"
            };
            /*for (int i = 0; i < tempName.Length; i++)
            {
                characterStats[i].name = tempName[i];
            }*/
            #region For loops
            for (int i = 0; i < skinMax; i++)
            {
                Texture2D temp = Resources.Load("Character/Skin_" + i) 
                    as Texture2D;
                skin.Add(temp);
            }
            for (int i = 0; i < eyesMax; i++)
            {
                Texture2D temp = Resources.Load("Character/Eyes_" + i)
                    as Texture2D;
                eyes.Add(temp);
            }
            for (int i = 0; i < mouthMax; i++)
            {
                Texture2D temp = Resources.Load("Character/Mouth_" + i)
                    as Texture2D;
                mouth.Add(temp);
            }
            for (int i = 0; i < hairMax; i++)
            {
                Texture2D temp = Resources.Load("Character/Hair_" + i)
                    as Texture2D;
                hair.Add(temp);
            }
            for (int i = 0; i < clothesMax; i++)
            {
                Texture2D temp = Resources.Load("Character/Clothes_" + i)
                    as Texture2D;
                clothes.Add(temp);
            }
            for (int i = 0; i < armourMax; i++)
            {
                Texture2D temp = Resources.Load("Character/Armour_" + i)
                    as Texture2D;
                armour.Add(temp);
            }
            #endregion
            characterRenderer = GameObject.FindGameObjectWithTag
                ("CharacterMesh").GetComponent<Renderer>();
            #region set textures on start
            SetTexture("Skin", Random.Range(0, 4));
            SetTexture("Eyes", Random.Range(0, 4));
            SetTexture("Mouth", Random.Range(0, 3));
            SetTexture("Hair", Random.Range(0, 5));
            SetTexture("Clothes", Random.Range(0, 11));
            SetTexture("Armour", Random.Range(0, 11));
            #endregion
            ChooseClass(0);
            //pleb
            for (int i = 0; i < pleb.Length; i++)
            {
                pleb[i].statLabel.text = pleb[i].stat.name + ": " + 
                    pleb[i].stat.value;
                pleb[i].buttonNeg.SetActive(false);
            }
        }
        public void SetName(string chara)
        { characterName = chara; }
        public void SetTexture(string type, int dir)
        {
            int index = 0, max = 0, matIndex = 0;
            Texture2D[] textures = new Texture2D[0];
            switch (type)
            {
                case "Skin":
                    index = skinIndex;
                    max = skinMax;
                    textures = skin.ToArray();
                    matIndex = 1;
                    break;
                case "Eyes":
                    index = eyesIndex;
                    max = eyesMax;
                    textures = eyes.ToArray();
                    matIndex = 2;
                    break;
                case "Mouth":
                    index = mouthIndex;
                    max = mouthMax;
                    textures = mouth.ToArray();
                    matIndex = 3;
                    break;
                case "Hair":
                    index = hairIndex;
                    max = hairMax;
                    textures = hair.ToArray();
                    matIndex = 4;
                    break;
                case "Clothes":
                    index = clothesIndex;
                    max = clothesMax;
                    textures = clothes.ToArray();
                    matIndex = 5;
                    break;
                case "Armour":
                    index = armourIndex;
                    max = armourMax;
                    textures = armour.ToArray();
                    matIndex = 6;
                    break;
            }
            index += dir;
            if(index < 0)
            { index = max - 1; }
            if(index > max-1)
            { index = 0; }
            Material[] mat = characterRenderer.materials;
            mat[matIndex].mainTexture = textures[index];
            characterRenderer.materials = mat;
            switch (type)
            {
                case "Skin":
                    skinIndex = index;
                    break;
                case "Eyes":
                    eyesIndex = index;
                    break;
                case "Mouth":
                    mouthIndex = index;
                    break;
                case "Hair":
                    hairIndex = index;
                    break;
                case "Clothes":
                    clothesIndex = index;
                    break;
                case "Armour":
                    armourIndex = index;
                    break;
            }
        }
        public void SetTexturePos(string type)
        { SetTexture(type, 1); }
        public void SetTextureNeg(string type)
        { SetTexture(type, -1); }
        public void ChooseClass(int classIndex)
        {
            switch(classIndex)
            {
                case 0:
                    pleb[0].stat.value = 15;
                    pleb[1].stat.value = 10;
                    pleb[2].stat.value = 10;
                    pleb[3].stat.value = 10;
                    pleb[4].stat.value = 10;
                    pleb[5].stat.value = 10;
                    charClass = CharacterClass.Barbarian;
                    break;
                /*Strength
                  Dexterity
                  Constitution  //15, 14, 13, 12, 10, 8
                  Wisdom
                  Intelligence
                  Charisma*/
                case 1:
                    pleb[0].stat.value = 14;
                    pleb[1].stat.value = 10;
                    pleb[2].stat.value = 10;
                    pleb[3].stat.value = 10;
                    pleb[4].stat.value = 10;
                    pleb[5].stat.value = 10;
                    charClass = CharacterClass.Bard;
                    break;
                case 2:
                    pleb[0].stat.value = 13;
                    pleb[1].stat.value = 10;
                    pleb[2].stat.value = 10;
                    pleb[3].stat.value = 10;
                    pleb[4].stat.value = 10;
                    pleb[5].stat.value = 10;
                    charClass = CharacterClass.Druid;
                    break;
                case 3:
                    pleb[0].stat.value = 999;
                    pleb[1].stat.value = 10;
                    pleb[2].stat.value = 10;
                    pleb[3].stat.value = 10;
                    pleb[4].stat.value = 10;
                    pleb[5].stat.value = 10;
                    charClass = CharacterClass.Monk;
                    break;
                case 4:
                    pleb[0].stat.value = 10;
                    pleb[1].stat.value = 10;
                    pleb[2].stat.value = 10;
                    pleb[3].stat.value = 10;
                    pleb[4].stat.value = 10;
                    pleb[5].stat.value = 10;
                    charClass = CharacterClass.Paladin;
                    break;
                case 5:
                    pleb[0].stat.value = 10;
                    pleb[1].stat.value = 10;
                    pleb[2].stat.value = 10;
                    pleb[3].stat.value = 10;
                    pleb[4].stat.value = 10;
                    pleb[5].stat.value = 10;
                    charClass = CharacterClass.Ranger;
                    break;
                case 6:
                    pleb[0].stat.value = 10;
                    pleb[1].stat.value = 10;
                    pleb[2].stat.value = 10;
                    pleb[3].stat.value = 10;
                    pleb[4].stat.value = 10;
                    pleb[5].stat.value = 10;
                    charClass = CharacterClass.Sorcerer;
                    break;
                case 7:
                    pleb[0].stat.value = 10;
                    pleb[1].stat.value = 10;
                    pleb[2].stat.value = 10;
                    pleb[3].stat.value = 10;
                    pleb[4].stat.value = 10;
                    pleb[5].stat.value = 10;
                    charClass = CharacterClass.Warlock;
                    break;
            }
            for (int i = 0; i < pleb.Length; i++)
            {
                pleb[i].stat.tempValue = 0;
                statPoints = 10;
                pleb[i].statLabel.text = pleb[i].stat.name + ": " +
                    pleb[i].stat.value;
                pleb[i].buttonNeg.SetActive(false);
                pleb[i].buttonPos.SetActive(true);
            }
        }
        public void SaveCharacter()
        {
            PlayerPrefs.SetInt("SkinIndex", skinIndex);
            PlayerPrefs.SetInt("EyesIndex", eyesIndex);
            PlayerPrefs.SetInt("MouthIndex", mouthIndex);
            PlayerPrefs.SetInt("HairIndex", hairIndex);
            PlayerPrefs.SetInt("ClothesIndex", clothesIndex);
            PlayerPrefs.SetInt("ArmourIndex", armourIndex);
            PlayerPrefs.SetString("CharacterName", characterName);
            for (int i = 0; i < pleb.Length; i++)
            {   PlayerPrefs.SetInt(pleb[i].stat.name, 
                (pleb[i].stat.tempValue + pleb[i].stat.value)); }
            PlayerPrefs.SetString("CharacterClass", 
                selectedClass[selectedIndex]);
        }
        #region ahhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh
        public Text pointText;
        [System.Serializable]
        public struct ScreamingMonkey
        {
            public Stats.StatBlock stat;
            public Text statLabel;
            public GameObject buttonPos;
            public GameObject buttonNeg;
        };

        public ScreamingMonkey[] pleb = new ScreamingMonkey[6];

        public void SetPointsPos(int i)
        {
            statPoints--;
            pleb[i].stat.tempValue++;
            if(statPoints <= 0)
            {
                for (int butto = 0; butto < pleb.Length; butto++)
                {
                    pleb[butto].buttonPos.SetActive(false);
                }
            }
            if(pleb[i].buttonNeg.activeSelf == false)
            {
                pleb[i].buttonNeg.SetActive(true);
            }
            pleb[i].statLabel.text = pleb[i].stat.name + ": " + 
                (pleb[i].stat.value + pleb[i].stat.tempValue);
        }
        public void SetPointsNeg(int i)
        {
            statPoints++;
            pleb[i].stat.tempValue--;
            if(pleb[i].stat.tempValue <= 0)
            {
                pleb[i].buttonNeg.SetActive(false);
            }
            if(pleb[i].buttonPos.activeSelf == false)
            {
                for(int arse = 0; arse < pleb.Length; arse++)
                {
                    pleb[arse].buttonPos.SetActive(true);
                }
            }
            pleb[i].statLabel.text = pleb[i].stat.name + ": " +
                (pleb[i].stat.value + pleb[i].stat.tempValue);
        }
        private void Update()
        {
            pointText.text = "Points: " + statPoints.ToString();
            for (int i = 0; i < pleb.Length; i++)
            {
                pleb[i].statLabel.text = pleb[i].stat.name + ": " + (pleb[i].stat.value + pleb[i].stat.tempValue).ToString();
            }
        }
        #endregion
        /*
        private void On
        ()
        {
            Vector2 scr = new Vector2(Screen.width / 16, Screen.height / 9);
            int i = 0;
            #region customisation
            #region Skin
            if (GUI.Button(new Rect(0.25f*scr.x, 0.5f*scr.y + (i*0.5f*scr.y), 0.5f*scr.x, 0.5f*scr.y), "<"))
                        {
                            SetTexture("Skin", -1);
                        }
                        GUI.Box(new Rect(0.75f*scr.x, 0.5f*scr.y + (i*0.5f*scr.y), 1.5f*scr.x, 0.5f*scr.y), "Skin");
                        if(GUI.Button(new Rect(2.25f*scr.x, 0.5f*scr.y + (i*0.5f*scr.y), 0.5f*scr.x, 0.5f*scr.y), ">"))
                        {
                            SetTexture("Skin", 1);
                        }
                        #endregion
            i++;
            #region Eyes
                        if(GUI.Button(new Rect(0.25f*scr.x, 0.5f*scr.y + (i*0.5f*scr.y), 0.5f*scr.x, 0.5f*scr.y), "<"))
                        {
                            SetTexture("Eyes", -1);
                        }
                        GUI.Box(new Rect(0.75f*scr.x, 0.5f*scr.y + (i*0.5f*scr.y), 1.5f*scr.x, 0.5f*scr.y), "Eyes");
                        if(GUI.Button(new Rect(2.25f*scr.x, 0.5f*scr.y + (i*0.5f*scr.y), 0.5f*scr.x, 0.5f*scr.y), ">"))
                        {
                            SetTexture("Eyes", 1);
                        }
                        #endregion
            i++;
            #region Mouth
                        if(GUI.Button(new Rect(0.25f*scr.x, 0.5f*scr.y + (i*0.5f*scr.y), 0.5f*scr.x, 0.5f*scr.y), "<"))
                        {
                            SetTexture("Mouth", -1);
                        }
                        GUI.Box(new Rect(0.75f*scr.x, 0.5f*scr.y + (i*0.5f*scr.y), 1.5f*scr.x, 0.5f*scr.y), "Mouth");
                        if(GUI.Button(new Rect(2.25f*scr.x, 0.5f*scr.y + (i*0.5f*scr.y), 0.5f*scr.x, 0.5f*scr.y), ">"))
                        {
                            SetTexture("Mouth", 1);
                        }
                        #endregion
            i++;
            #region Hair
                        if(GUI.Button(new Rect(0.25f*scr.x, 0.5f*scr.y + (i*0.5f*scr.y), 0.5f*scr.x, 0.5f*scr.y), "<"))
                        {
                            SetTexture("Hair", -1);
                        }
                        GUI.Box(new Rect(0.75f*scr.x, 0.5f*scr.y + (i*0.5f*scr.y), 1.5f*scr.x, 0.5f*scr.y), "Hair");
                        if(GUI.Button(new Rect(2.25f*scr.x, 0.5f*scr.y + (i*0.5f*scr.y), 0.5f*scr.x, 0.5f*scr.y), ">"))
                        {
                            SetTexture("Hair", 1);
                        }
                        #endregion
            i++;
            #region Clothes
                        if(GUI.Button(new Rect(0.25f*scr.x, 0.5f*scr.y + (i*0.5f*scr.y), 0.5f*scr.x, 0.5f*scr.y), "<"))
                        {
                            SetTexture("Clothes", -1);
                        }
                        GUI.Box(new Rect(0.75f*scr.x, 0.5f*scr.y + (i*0.5f*scr.y), 1.5f*scr.x, 0.5f*scr.y), "Clothes");
                        if(GUI.Button(new Rect(2.25f*scr.x, 0.5f*scr.y + (i*0.5f*scr.y), 0.5f*scr.x, 0.5f*scr.y), ">"))
                        {
                            SetTexture("Clothes", 1);
                        }
                        #endregion
            i++;
            #region Armour
                        if(GUI.Button(new Rect(0.25f*scr.x, 0.5f*scr.y + (i*0.5f*scr.y), 0.5f*scr.x, 0.5f*scr.y), "<"))
                        {
                            SetTexture("Armour", -1);
                        }
                        GUI.Box(new Rect(0.75f*scr.x, 0.5f*scr.y + (i*0.5f*scr.y), 1.5f*scr.x, 0.5f*scr.y), "Armour");
                        if(GUI.Button(new Rect(2.25f*scr.x, 0.5f*scr.y + (i*0.5f*scr.y), 0.5f*scr.x, 0.5f*scr.y), ">"))
                        {
                            SetTexture("Armour", 1);
                        }
            #endregion
            #endregion
            i = 0;
            #region class
                        if(GUI.Button(new Rect(13.75f*scr.x, 0.5f*scr.y + (i*0.5f*scr.y), 2*scr.x, 0.5f*scr.y), classButton))
                        {
                            showDropdown = !showDropdown;
                        }
                        i++;
                        if(showDropdown)
                        {
                            scrollPos = GUI.BeginScrollView(new Rect(13.75f*scr.x, 0.5f*scr.y + (i*0.5f*scr.y), 2*scr.x, 2*scr.y), scrollPos, new Rect(0, 0, 0, selectedClass.Length*0.5f*scr.y), false, true);
                            for(int c = 0; c < selectedClass.Length; c++)
                            {
                                if(GUI.Button(new Rect(0, 0.5f*scr.y*c, 1.75f*scr.x, 0.5f*scr.y), selectedClass[c]))
                                {
                                    ChooseClass(c);
                                    classButton = selectedClass[c];
                                    showDropdown = false;
                                }
                            }
                            GUI.EndScrollView();
                        }
            #endregion
            #region points
            GUI.Box(new Rect(12.75f*scr.x, 3.25f*scr.y, 2*scr.x, 0.5f*scr.y), "Points: " + statPoints);
            for(int s = 0; s < characterStats.Length; s++)
            {
                if(statPoints > 0)
                {
                    if(GUI.Button(new Rect(14.75f*scr.x, 3.75f*scr.y + s*0.5f*scr.y, 0.5f*scr.x, 0.5f*scr.y), "+"))
                    {
                        statPoints--;
                        characterStats[s].tempValue++;
                    }
                }
                GUI.Box(new Rect(12.75f*scr.x, 3.75f*scr.y + s*0.5f*scr.y, 2*scr.x, 0.5f*scr.y), characterStats[s].name + ": " + (characterStats[s].value + characterStats[s].tempValue));
                if(statPoints < 10 && characterStats[s].tempValue > 0)
                {
                    if(GUI.Button(new Rect(12.25f*scr.x, 3.75f*scr.y + s*0.5f*scr.y, 0.5f*scr.x, 0.5f*scr.y), "-"))
                    {
                        statPoints++;
                        characterStats[s].tempValue--;
                    }
                }
            }
            if(statPoints < 10)
            {
                if(GUI.Button(new Rect(12.75f*scr.x, 6.75f*scr.y + i*0.5f*scr.y, 2*scr.x, 0.5f*scr.y), "Reset"))
                {
                    statPoints = 10;
                    for(int s = 0; s < characterStats.Length; s++)
                    {
                        characterStats[s].tempValue = 0;
                    }
                }
            }
            #endregion
            #region name
            characterName = GUI.TextField(new Rect(0.25f*scr.x, 0.5f*scr.y + (i*5*scr.y), 2.5f*scr.x, 0.5f*scr.y), characterName, 18);
            #endregion
            i++;
            #region save
            if(GUI.Button(new Rect(0.25f*scr.x, 6*scr.y + (i*0.5f*scr.y), 2.5f*scr.x, 0.5f*scr.y), "Save & Play"))
            {
                SaveCharacter();
                SceneManager.LoadScene(2);
            }
            #endregion
            
        }
        */
        #endregion
    }
    public enum CharacterClass
    {
        Barbarian,
        Bard,
        Druid,
        Monk,
        Paladin,
        Ranger,
        Sorcerer,
        Warlock
    }
    public enum CharacterRace
    {
        Elf,
        Gnome,
        Dwarf,
        Human,
        Tiefling
    }
}