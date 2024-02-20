using UnityEngine;
    class InputManager2D : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        private IMovement2D movement;
        private void Start()
        {
            movement = player.GetComponent<IMovement2D>();
        }
        private void Update()
        {
            var horizontal = Input.GetAxisRaw("Horizontal");
            var jumpDownBtn = Input.GetButtonDown("Jump");
            var jumpUpBtn = Input.GetButtonUp("Jump");
            movement.Move(horizontal, jumpDownBtn, jumpUpBtn);
        }
    }
    
