using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    Input_Map inputs;
    public bool isPlayerOne;

    public Vector2 moveInput;
    public bool shootInput;
    public bool especialInput;

    private void OnEnable()
    {
        if (inputs == null)
        {
            inputs = new Input_Map();
            if (isPlayerOne)
            {
                inputs.Girl_Map.Movement.performed += i => moveInput = i.ReadValue<Vector2>();
                inputs.Girl_Map.Attack.performed += i => shootInput = true;
                inputs.Girl_Map.Especial.performed += i => especialInput = true;
            }
            else
            {
                inputs.Boy_Map.Movement.performed += i => moveInput = i.ReadValue<Vector2>();
                inputs.Boy_Map.Attack.performed += i => shootInput = true;
                inputs.Boy_Map.Especial.performed += i => especialInput = true;
            }
            inputs.Enable();
        }
    }

    private void OnDisable()
    {
        inputs.Disable();
    }
}
