using System.Runtime.CompilerServices;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public InputActionAsset inputAsset;
    public float speed = 3;
    public float sprintSpeed = 6;
    public float jumpForce = 5f;

    private float _axis;
    private bool _isUsingSecondary = false;
    private Rigidbody2D _rigidbody;

    private void OnEnable()
    {
        //inputAsset.FindAction("Gameplay/Jump").started += HandleJump;

        inputAsset.FindAction("Gameplay/Move").performed += HandleMove;
        inputAsset.FindAction("Gameplay/Move").canceled += HandleMove;

        inputAsset.FindAction("Gameplay/Secondary").started += HandleSecondary;
        inputAsset.FindAction("Gameplay/Secondary").canceled += HandleSecondary;

        inputAsset.Enable();
    }

    private void OnDisable()
    {
        //inputAsset.FindAction("Gameplay/Jump").started -= HandleJump;

        inputAsset.FindAction("Gameplay/Move").performed -= HandleMove;
        inputAsset.FindAction("Gameplay/Move").canceled -= HandleMove;

        inputAsset.FindAction("Gameplay/Secondary").started -= HandleSecondary;
        inputAsset.FindAction("Gameplay/Secondary").canceled -= HandleSecondary;

        inputAsset.Disable();

    }
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        UpdateJump();

        if (_isUsingSecondary)
        {
            transform.position += Vector3.right * _axis * sprintSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.right * _axis * speed * Time.deltaTime;
        }


    }

    //private void HandleJump(InputAction.CallbackContext ctx)
    //{
    //    Debug.Log($"JUMP: Phase = {ctx.phase} ");
    //}

    private void HandleMove(InputAction.CallbackContext ctx)
    {
        _axis = ctx.ReadValue<float>();
        Debug.Log($"MOVE: Phase = {ctx.phase} Axis = {_axis}");
    }

    private void HandleSecondary(InputAction.CallbackContext ctx)
    {
        _isUsingSecondary = !ctx.canceled;
    }

    private void UpdateJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }

}