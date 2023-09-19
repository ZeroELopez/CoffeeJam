using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerEntity : MonoBehaviour, InputController.IPlayerControllerActions
{
    private bool isMoving = false;
    private Vector3 direction;
    private InputController controls;

    [SerializeField]
    private float moveSpeed;

    public void OnAttackInteract(InputAction.CallbackContext context)
    {
        if(context.canceled)
        {
            //TODO: Contextual interaction and attack


        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        isMoving = context.started || context.performed;
        Vector2 readVector = context.ReadValue<Vector2>();
        direction = IsoVectorConvert(new Vector3(readVector.x, 0, readVector.y));
    }

    // Start is called before the first frame update
    void Start()
    {
        RegisterInputs();
    }

    private void RegisterInputs()
    {
        controls = new InputController();
        controls.Enable();

        controls.PlayerController.Move.started += OnMove;
        controls.PlayerController.Move.performed += OnMove;
        controls.PlayerController.Move.canceled += OnMove;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            transform.position += new Vector3(direction.x, direction.z, 0) * moveSpeed * Time.deltaTime;
        }
    }

    private Vector3 IsoVectorConvert(Vector3 vector)
    {
        Quaternion rotation = Quaternion.Euler(0, 0f, 0);
        Matrix4x4 matrix = Matrix4x4.Rotate(rotation);
        Vector3 result = matrix.MultiplyPoint3x4(vector);

        return result;
    }

}
