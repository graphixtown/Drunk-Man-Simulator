using System;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player_Inputs : MonoBehaviour
{
    [Header("INPUT ACTION ASSET")]
    [SerializeField] private InputActionAsset _inputAsset;
    
    [Header("INPUT ACTION MAP")]
    [SerializeField] private string _actionMap = "Player Input";

    [Header("INPUT ACTIONS")]
    [SerializeField] private string _move;
    [SerializeField] private string _jump;
    [SerializeField] private string _sprint;

    private InputAction _moveAction;
    private InputAction _jumpAction;
    private InputAction _sprintAction;

    public Vector2 MoveInput { get; private set; }
    public bool JumpInput { get; private set; }
    public bool SprintInput { get; private set; }

    public static Player_Inputs instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(instance);

        _moveAction = _inputAsset.FindActionMap(_actionMap).FindAction(_move);
        _jumpAction = _inputAsset.FindActionMap(_actionMap).FindAction(_jump);
        _sprintAction = _inputAsset.FindActionMap(_actionMap).FindAction(_sprint);

        RegisterInput();
    }

    void RegisterInput()
    {
        _moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        _moveAction.canceled += context => MoveInput = Vector2.zero;
        _jumpAction.performed += context => JumpInput = true;
        _jumpAction.canceled += context => JumpInput = false;
    }

    private void OnEnable()
    {
        _moveAction.Enable();
        _jumpAction.Enable();
        _sprintAction.Enable();
    }
    private void OnDisable()
    {
        _moveAction.Disable();
        _jumpAction.Disable();
        _sprintAction.Disable();
    }

}
