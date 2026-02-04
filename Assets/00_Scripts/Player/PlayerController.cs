using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float rotationSpeed = 10f;

    [Header("Jump Settings")]
    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private float gravityValue = -9.81f;

    [Header("References")]
    [SerializeField] private Transform cameraTransform;

    public CharacterController controller;
    private Player playerInput;
    private Animator anim;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private void Awake()
    {
        playerInput = new Player();
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        // 카메라 자동 할당
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Read input
        Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        if (playerInput.PlayerMain.Attack.triggered)
        {
            Debug.Log("클릭완료");
            anim.SetBool("isAttack", true);
        }
        else
        {
            anim.SetBool("isAttack", false);
        }
        // 카메라 방향 가져오기
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;

        // 수평면에서만 이동 (Y축 제거)
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // 카메라 기준 이동 방향 계산
        Vector3 moveDirection = cameraForward * movementInput.y + cameraRight * movementInput.x;
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1f);

        // 이동 및 회전 처리
        if (moveDirection.magnitude > 0.1f)
        {
            // 부드러운 회전
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            anim.SetBool("isMove", true);
        }
        else
        {
            anim.SetBool("isMove", false);
        }

        // Jump
        if (groundedPlayer && playerInput.PlayerMain.Jump.triggered)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue);
        }

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Move
        Vector3 finalMove = moveDirection * playerSpeed + Vector3.up * playerVelocity.y;
        controller.Move(finalMove * Time.deltaTime);
    }
}