using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        float playerHeight = 2f;

        [SerializeField] private Transform orientation;
    
        [Header("Movement")] 
        public float moveSpeed = 6f;
        public float moveMultiplier = 10f;
        [SerializeField] float airMultiplier = 0.4f;

        [Header("Sprinting")]
        [SerializeField] float walkSpeed = 4f;
        [SerializeField] float sprintSpeed = 6f;
        [SerializeField] float acceleration = 10f;
        
        [Header("Jumping")] 
        public float jumpForce = 8f;

        [Header("KeyBinds")] 
        [SerializeField] private KeyCode jumpKey = KeyCode.Space;
        [SerializeField] private KeyCode sprintKey = KeyCode.LeftShift;

        [Header("Drag")] 
        private float groundDrag = 8f;
        private float airDrag = 2f;

        private float horizontalMovement;
        private float verticalMovement;

        [Header("Ground Detection")] 
        [SerializeField] Transform groundCheck;
        [SerializeField] private LayerMask groundMask;
        [SerializeField] float groundDistance = 0.5f;
        bool isGrounded;
    
        Vector3 moveDirection;
        Vector3 slopeMoveDirection;
    
        Rigidbody rb;

        RaycastHit slopeHit;

        private bool OnSlope()
        {
            if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight / 2 + 0.5f))
            {
                if (slopeHit.normal != Vector3.up)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        
        private void Start()
        {
            rb = GetComponent<Rigidbody>();

            rb.freezeRotation = true;
        }
    
        private void Update()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
            MyInput();
            ControlDrag();
            ControlSpeed();

            if (Input.GetKeyDown(jumpKey) && isGrounded)
            {
                Jump();
            }
            
            slopeMoveDirection = Vector3.ProjectOnPlane(moveDirection, slopeHit.normal);
        
        }

        void MyInput()
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal");
            verticalMovement = Input.GetAxisRaw("Vertical");

            moveDirection = orientation.forward * verticalMovement + orientation.right * horizontalMovement;
        }

        void Jump()
        {
            if (isGrounded)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            }
        }
        
        void ControlSpeed()
        {
            if (Input.GetKey(sprintKey) && isGrounded)
            {
                moveSpeed = Mathf.Lerp(moveSpeed, sprintSpeed, acceleration * Time.deltaTime);
            }
            else
            {
                moveSpeed = Mathf.Lerp(moveSpeed, walkSpeed, acceleration * Time.deltaTime);
            }
        }

        void ControlDrag()
        {
            if (isGrounded)
            {
                rb.drag = groundDrag;
            }
            else
            {
                rb.drag = airDrag;
            }
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        void MovePlayer()
        {
            if (isGrounded && !OnSlope())
            {
                rb.AddForce(moveDirection.normalized * (moveSpeed * moveMultiplier), ForceMode.Acceleration);
            }
            else if (isGrounded && OnSlope())
            {
                rb.AddForce(slopeMoveDirection.normalized * (moveSpeed * moveMultiplier), ForceMode.Acceleration);
            }
            
            else if (!isGrounded)
            {
                rb.AddForce(moveDirection.normalized * (moveSpeed * airMultiplier), ForceMode.Acceleration);
            }
        
        }
    
    
    }
}
