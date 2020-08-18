using UnityEngine;
using UnityEngine.UI;
namespace Claire
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerHandler : Character
    {
        #region variables
        [Header("Controls")]
        public KeyBindManager kbm;
        public KeyCode keyForward, keyLeft, keyRight, keyBackwards, keyJump, keySprint, keyCrouch, keyInteract, keyInventory;
        [Header("Physics")]
        public CharacterController controller;
        public float gravity = 20f;
        public Vector3 moveDirection;
        [Header("Level Data")]
        public int level = 0;
        public float currentExp, neededExp, maxExp;
        public Quest currentQuest;
        [Header("Damage Flash and Death")]
        public Image damageImage;
        public Image deathImage;
        public Text deathText;
        public AudioClip deathClip;
        public AudioSource playersAudio;
        public Transform currentCheckPoint;
        public Color flashColour = new Color(1, 0, 0, 0.2f);
        public float flashSpeed = 5f;
        public static bool isDead;
        public bool isDamaged, canHeal;
        public float healDelayTimer;
        #endregion
        private void Start()
        {
            kbm = GameObject.FindGameObjectWithTag("ItBen").GetComponent<KeyBindManager>();
            controller = this.gameObject.GetComponent<CharacterController>();
            keyForward   = KeyBindManager.keys["Forward"];
            keyLeft      = KeyBindManager.keys["Left"];
            keyRight     = KeyBindManager.keys["Right"];
            keyBackwards = KeyBindManager.keys["Backwards"];
            keyJump      = KeyBindManager.keys["Jump"];
            keySprint    = KeyBindManager.keys["Sprint"];
            keyCrouch    = KeyBindManager.keys["Crouch"];
            keyInteract  = KeyBindManager.keys["Interact"];
            keyInventory = KeyBindManager.keys["Inventory"];
        }
        public void Update()
        {
            Movement();
            for (int i = 0; i < attributes.Length; i++)
            {
                attributes[i].displayImage.fillAmount = Mathf.Clamp01(attributes[i].currentValue / attributes[i].maxValue);
            }
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.O))
            { DamagePlayer(5); }
            if (Input.GetKeyDown(KeyCode.L))
            { DamagePlayer(1); }
#endif
            if (isDamaged && !isDead)
            {
                damageImage.color = flashColour;
                isDamaged = false;
            }
            else if (damageImage.color.a > 0)
            {
                damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }
            if (!canHeal)
            {
                healDelayTimer += Time.deltaTime;
                if (healDelayTimer >= 5)
                {
                    canHeal = true;
                }
            }
            if (canHeal && attributes[0].currentValue < attributes[0].maxValue && attributes[0].currentValue > 0)
            {
                HealOverTime(0);
            }
            if (!Input.GetKey(KeyBindManager.keys["Sprint"]) && attributes[1].currentValue < attributes[1].maxValue)
            {
                HealOverTime(1);
            }
        }
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("CheckPoint"))
            {
                currentCheckPoint = other.transform;
                for (int i = 0; i < attributes.Length; i++)
                {
                    attributes[i].regenValue += 7;
                }
                PlayerSaveAndLoad.Save();
            }
        }
        public void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "CheckPoint")
            {
                for (int i = 0; i < attributes.Length; i++)
                {
                    attributes[i].regenValue -= 7;
                }
                PlayerSaveAndLoad.Save();
            }
        }
        public void KilledCreature(string enemyTag)
        {
            if(currentQuest.goal.questState == QuestState.Active)
            {
                currentQuest.goal.EnemyKilled(enemyTag);
            }
        }
        public void ItemCollected(int id)
        {
            if(currentQuest.goal.questState == QuestState.Active)
            {
                currentQuest.goal.ItemCollected(id);
            }
        }
        public void Movement()
        {
            if (!isDead)
            {
                if (kbm.getAxisMode)
                {
                    moveDirection = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
                    if (controller.isGrounded)
                    {
                        moveDirection *= walkSpeed;
                        if (Input.GetButton("Jump"))
                        { moveDirection.y = jumpSpeed; }
                    }
                    moveDirection.y -= gravity * Time.deltaTime;
                    controller.Move(moveDirection * Time.deltaTime);
                }
                else if (!kbm.getAxisMode)
                {
                    float h = 0;
                    float v = 0;
                    if (Input.GetKey(KeyBindManager.keys["Forward"]))
                    { v++; }
                    if (Input.GetKey(KeyBindManager.keys["Left"]))
                    { h--; }
                    if (Input.GetKey(KeyBindManager.keys["Right"]))
                    { h++; }
                    if (Input.GetKey(KeyBindManager.keys["Backwards"]))
                    { v--; }
                    //moveDirection = transform.TransformDirection(new Vector3(((Input.GetKey(KeyBindManager.keys["Left"]) ? -1 : 0) + (Input.GetKey(KeyBindManager.keys["Right"]) ? 1 : 0)), 0, (Input.GetKey(KeyBindManager.keys["Back"]) ? -1 : 0) + (Input.GetKey(KeyBindManager.keys["Forward"]) ? 1 : 0)));
                    moveDirection = transform.TransformDirection(new Vector3(h, 0, v));
                    if (controller.isGrounded)
                    {
                        if (Input.GetKey(KeyBindManager.keys["Jump"]))
                        {
                            moveDirection.y = jumpSpeed;
                        }
                        if (Input.GetKey(KeyBindManager.keys["Sprint"]))
                        {
                            attributes[1].currentValue--;
                            if (attributes[1].currentValue > 0)
                            {
                                moveDirection.z *= (characterStats[2].value / 8);
                            }
                        }
                        if (Input.GetKey(KeyBindManager.keys["Crouch"]))
                        {
                            moveDirection.x *= crouchSpeed;
                            moveDirection.z *= crouchSpeed;
                        }
                        else
                        {
                            moveDirection.x *= walkSpeed;
                            moveDirection.z *= walkSpeed;
                        }
                    }
                    moveDirection.y -= gravity * Time.deltaTime;
                    controller.Move(moveDirection * Time.deltaTime);
                }
            }
        }
        public void DamagePlayer(float damage)
        {
            isDamaged = true;
            attributes[0].currentValue -= damage;
            canHeal = false;
            healDelayTimer = 0;
            if (attributes[0].currentValue <= 0 && !isDead)
            { Death(); }
        }
        public void HealOverTime(int e)
        {
            attributes[e].currentValue += Time.deltaTime * (attributes[e].regenValue * characterStats[1].value);
        }
        void Death()
        {
            isDead = true;
            deathText.text = "";
            playersAudio.clip = deathClip;
            playersAudio.Play();
            deathImage.GetComponent<Animator>().SetTrigger("isDead");
            Invoke("DeathText", 2f);
            Invoke("RespawnText", 6f);
            Invoke("Respawn", 9f);
        }
        void DeathText()
        {
            deathText.text = "You've f*cked up!";//You've Fallen in Battle...
        }
        void RespawnText()
        {
            deathText.text = "...don't just sit there; try again.";//...But the Gods have decided it is not your time...
        }
        void Respawn()
        {
            deathText.text = "";
            for (int i = 0; i < attributes.Length; i++)
            {
                attributes[i].currentValue = attributes[i].maxValue;
            }
            isDead = false;
            transform.position = currentCheckPoint.position;
            transform.rotation = currentCheckPoint.rotation;
            deathImage.GetComponent<Animator>().SetTrigger("Respawn");
        }
    }
}