using UnityEngine;
namespace Claire
{
    public class Character : Stats
    {
        #region Variables
        [Header("Character Data")]
        public new string name;
        [Header("Movement Variables")]
        public float walkSpeed = 5f;
        public float crouchSpeed = 2.5f;
        public float sprintSpeed = 10f;
        public float jumpSpeed = 8f;
        #endregion
    }
}