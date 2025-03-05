using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    #region Setup Values -> Awake
    public static PlayerMovement instance;

    private Rigidbody _rb;
    private Gravity _gravity;
    private Animator _anim;
    #endregion

    #region SerializeField Values
    [Header("Movement Values")]
    [SerializeField] float movementSpeed;
    [SerializeField] float accel;
    [SerializeField] float deccel;
    [SerializeField] float frictionPercentage;

    [Header("Dash")]
    [SerializeField] float dashingTime;
    [SerializeField] float dashingPower;
    [SerializeField] float dashRecoverCooldown;

    [Header("Assigns")]
    [SerializeField] Transform orientation;
    [SerializeField] Transform playerObj;
    [SerializeField] CinemachineFreeLook playerCamera;
    #endregion

    private float lastDashTimer;

    private bool isDashing;

    [DoNotSerialize] public bool canDash;

    public Vector2 moveDir;

    private void Awake()
    {
        instance = this;

        _rb = GetComponent<Rigidbody>();
        _gravity = GetComponent<Gravity>();
        _anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        #region Timers
        lastDashTimer -= Time.fixedDeltaTime;

        if (lastDashTimer <= 0 && isDashing)
        {
            isDashing = false;
        }
        #endregion

        #region Physics
        if (!isDashing)
        {
            if (moveDir == Vector2.zero && ToVector2(_rb.velocity) != Vector2.zero)
            {
                if (ToVector2(_rb.velocity).sqrMagnitude <= 1)
                {
                    _rb.velocity = new Vector3(0, _rb.velocity.y, 0); ;
                }
                Vector2 brakeVector = -ToVector2(_rb.velocity);
                _rb.AddForce(brakeVector * frictionPercentage, ForceMode.Force);
            }
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


    private void OnDash(InputAction.CallbackContext context)
    {
        if (canDash && !isDashing)
        {
            canDash = false;
            isDashing = true;
            lastDashTimer = dashingTime;
            _gravity.gravityScale = 0;
            _rb.velocity = Vector3.zero;
            _rb.AddForce(playerObj.forward * dashingPower, ForceMode.Impulse);
        }
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveDir = context.ReadValue<Vector2>();
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
    public void Vibrate(float lowF, float highF, float t0ime)
    {
        if (Gamepad.current != null)
        {
            Gamepad.current.SetMotorSpeeds(lowF, highF);
        }
    }
    #endregion
}
