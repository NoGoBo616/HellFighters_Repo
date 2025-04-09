using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Input_Manager : MonoBehaviour
{

    public Vector2 moveInput;
    public bool isAtacking;

    //Variables de autoreferencia

    [SerializeField] PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    #region Input Metods

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnAtack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isAtacking = true;
        }
    }

    #endregion
}
