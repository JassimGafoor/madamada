
using UnityEngine;
using UnityEngine.InputSystem;
using Mirror;
using Cinemachine;


public class movement : NetworkBehaviour
{
    PlayerInput playerInput;
    CharacterController characterController;
    Vector2 currentMovementInput;
    Vector3 currentMovement;
    bool isMovementPressed;

    [SerializeField] private CinemachineVirtualCamera playerCamera;

    //rotation speed
    public float rotationFactorPerFrame = 5f;
    //movement speed multiplier
    public float speed = 3.0f;
    void Awake()
    {
        playerInput = new PlayerInput();
        characterController = GetComponent<CharacterController>();

        playerInput.Controls.Move.started += onMovementInput;
        playerInput.Controls.Move.canceled += onMovementInput;
        playerInput.Controls.Move.performed += onMovementInput;
        
    }

    private void Start(){
        if(isLocalPlayer){
            playerCamera = CinemachineVirtualCamera.FindObjectOfType<CinemachineVirtualCamera>();
            playerCamera.Follow = this.gameObject.transform;
        }
    }

    void OnEnable()
    {
        playerInput.Controls.Enable();
    }

    void OnDisable()
    {
        playerInput.Controls.Disable();
    }

    void handleRotation()
    {
        if (isLocalPlayer){
            Vector3 positionToLookAt;
        
            positionToLookAt.x = currentMovement.x;
            positionToLookAt.y = 0.0f;
            positionToLookAt.z = currentMovement.z;

            Quaternion currentRotation = transform.rotation;
            
            if (isMovementPressed){
                Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
                transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime) ;
            }
        }
        
    }

    void onMovementInput (InputAction.CallbackContext context){
        if(isLocalPlayer){
            currentMovementInput = context.ReadValue<Vector2>();
            currentMovement.x = currentMovementInput.x;
            currentMovement.z = currentMovementInput.y;
            isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        handleRotation();
        characterController.Move(currentMovement * Time.deltaTime * speed);
    }
}
