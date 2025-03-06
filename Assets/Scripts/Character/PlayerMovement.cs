using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    #region Setup Values -> Awake
    public static PlayerMovement instance;

    private Rigidbody _rb;
    #endregion

    #region SerializeField Values
    [Header("Movement Values")]
    [SerializeField] float movementSpeed;
    [SerializeField] float accel;
    [SerializeField] float deccel;
    [SerializeField] float rotationSpeed;

    [Header("Dash")]
    [SerializeField] float dashingTime;
    [SerializeField] float dashingPower;
    [SerializeField] float dashRecoverCooldown;

    [Header("Assigns")]
    [SerializeField] Transform orientation;
    [SerializeField] Transform direction;
    [SerializeField] Transform playerObj;
    #endregion

    private float lastDashTimer;

    private bool isDashing;

    [DoNotSerialize] public bool canDash;

    public Vector2 moveDir;

    private void Awake()
    {
        instance = this;

        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 inputDir = ToVector3(moveDir);
        Vector3 orientedInputDir = orientation.forward * inputDir.z + orientation.right * inputDir.x;

        if (inputDir != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, orientedInputDir.normalized, rotationSpeed * Time.deltaTime);

            direction.forward = orientedInputDir.normalized;
        }
    }

    private void FixedUpdate()
    {
        #region Timers
        lastDashTimer -= Time.fixedDeltaTime;

        if (lastDashTimer <= 0 && isDashing)
        {
            isDashing = false;
        }

        if (lastDashTimer <= -dashRecoverCooldown)
        {
            canDash = true;
        }
        #endregion

        #region Movements
        if (!isDashing)
        {
            Vector2 targetMovement = OrientVector2(moveDir, orientation) * movementSpeed;
            Vector2 movementDiff = targetMovement - ToVector2(_rb.velocity);
            float accelRate = (Mathf.Abs(targetMovement.sqrMagnitude) > 0.1f) ? accel : deccel;

            Vector2 movement = movementDiff * accelRate;

            _rb.AddForce(ToVector3(movement), ForceMode.Force);
        }
        #endregion
    }


    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (canDash && !isDashing)
            {
                canDash = false;
                isDashing = true;
                lastDashTimer = dashingTime;
                _rb.velocity = Vector3.zero;
                _rb.AddForce(direction.forward * dashingPower, ForceMode.Impulse);
            }
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveDir = context.ReadValue<Vector2>().normalized;

        if (moveDir.sqrMagnitude <= 0.1f)
        {
            moveDir = Vector2.zero;
        }
    }

    #region Maths
    public Vector3 ToVector3(Vector2 vector)
    {
        return new Vector3(vector.x, 0, vector.y);
    }

    public Vector2 ToVector2(Vector3 vector)
    {
        return new Vector2(vector.x, vector.z);
    }

    public Vector2 OrientVector2(Vector2 vector, Transform orientation)
    {
        return ToVector2(orientation.forward * vector.y + orientation.right * vector.x);
    }
    #endregion

    #region Utils
    public void Vibrate(float lowF, float highF, float time)
    {
        if (Gamepad.current != null)
        {
            Gamepad.current.SetMotorSpeeds(lowF, highF);
        }
    }
    #endregion
}
