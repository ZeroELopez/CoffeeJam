using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerEntity : MonoBehaviour, InputController.IPlayerControllerActions
{
    private bool isMoving = false;
    private Vector3 direction;
    private Vector2 lastDirection;
    private InputController controls;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private BoxCollider2D attackHitbox;

    [SerializeField]
    private int attackStartUpFrames;

    [SerializeField]
    private int attackActiveFrames;

    [SerializeField]
    private int attackRecoveryFrames;

    private bool isAttacking;

    public void OnAttackInteract(InputAction.CallbackContext context)
    {
        if(context.canceled)
        {
            //TODO: Contextual interaction and attack
            if(!isAttacking)
            {
                StartCoroutine(AttackCoroutine());
            }
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        isMoving = context.started || context.performed;

        if (isMoving)
        {
            Vector2 readVector = context.ReadValue<Vector2>();
            direction = IsoVectorConvert(new Vector3(readVector.x, 0, readVector.y));

            if(direction.x != 0)
            {
                lastDirection.x = Mathf.Sign(direction.x);
            }

            if(direction.z != 0)
            {
                lastDirection.y = Mathf.Sign(direction.z);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        RegisterInputs();
        lastDirection = -Vector2.one;
    }

    private void RegisterInputs()
    {
        controls = new InputController();
        controls.Enable();

        controls.PlayerController.Move.started += OnMove;
        controls.PlayerController.Move.performed += OnMove;
        controls.PlayerController.Move.canceled += OnMove;
        controls.PlayerController.AttackInteract.started += OnAttackInteract;
        controls.PlayerController.AttackInteract.performed += OnAttackInteract;
        controls.PlayerController.AttackInteract.canceled += OnAttackInteract;
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

    private IEnumerator AttackCoroutine()
    {
        isAttacking = true;

        //Wait for start up frames
        yield return new WaitForSeconds(attackStartUpFrames / 60f);
        
        attackHitbox.transform.localPosition = new Vector3(lastDirection.x * attackHitbox.size.x/2, lastDirection.y * attackHitbox.size.y/2, 0);
        attackHitbox.enabled = true;
        
        //Active Frames
        yield return new WaitForSeconds(attackActiveFrames / 60f);
        attackHitbox.enabled = false;

        //Recovery Frames
        yield return new WaitForSeconds(attackRecoveryFrames / 60f);
        isAttacking = false;
    }
}
