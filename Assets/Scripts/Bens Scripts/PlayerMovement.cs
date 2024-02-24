using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class PlayerMovement : NetworkBehaviour {
    //components
    public Rigidbody2D RB { get; private set; }
    public float circleRadius;
    public Vector2 circleCenter;
    public bool IsFacingRight { get; private set; }
    public bool IsJumping { get; private set; }
    public float LastOnGroundTime { get; private set; }
    private Vector2 moveInput;
    public float LastPressedJumpTime { get; private set; }
    [SerializeField] private LayerMask ground;
    //Run
    public float moveSpeed;
    public float accelTime;
    public float deccelTime;
    public float velPower;
    [HideInInspector] public float acceleration;
    [HideInInspector] public float decceleration;
    public float frictionAmount;
    //Jump
    private bool JumpCut;
    private bool JumpFalling;
    public float jumpHeight; 
    public float jumpTimeToApex; 
    [HideInInspector] public float jumpForce;
    public float jumpCutGravityMult;
    [Range(0f, 1)] public float jumpHangGravityMult; 
    public float jumpHangTimeThreshold; 
    public float jumpHangAccelerationMult;
    public float jumpHangMaxSpeedMult;
    //Gravity
    [HideInInspector] public float gravityStrength;
    [HideInInspector] public float gravityScale;
    public float fallGravityMult;
    public float maxFallSpeed;
    public float fastFallGravityMult;
    public float maxFastFallSpeed;
    //Helpful assists
    [Range(0.01f, 0.5f)] public float coyoteTime; //Grace period after falling off a platform, where you can still jump
    [Range(0.01f, 0.5f)] public float jumpInputBufferTime; //Grace period after pressing jump where a jump will be automatically performed

    public override void OnNetworkSpawn() {
        RB = GetComponent<Rigidbody2D>();
        circleRadius = GetComponent<CircleCollider2D>().radius;
        circleCenter = GetComponent<CircleCollider2D>().bounds.center;
    }
    private void FixedUpdate() {
        if (IsLocalPlayer) {
            Run();
        }
    }
    private void Start() {
        IsFacingRight = true;
        SetGravityScale(gravityScale);
    }
    private void Update() {
        LastOnGroundTime -= Time.deltaTime;
        LastPressedJumpTime -= Time.deltaTime;
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        if (moveInput.x != 0)
            CheckDirection(moveInput.x > 0);
        if(Input.GetKeyDown(KeyCode.Space)) {
			OnJumpInput();
        }

		if (Input.GetKeyUp(KeyCode.Space)) {
			OnJumpUpInput();
		}
        //ground checks
        if (!IsJumping) {
            if (groundCheck()==true) {
                LastOnGroundTime = coyoteTime;
            }
        }
        //friction
        if (LastOnGroundTime > 0 && Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow)) {
            float amount = Mathf.Min(Mathf.Abs(RB.velocity.x), Mathf.Abs(frictionAmount));
            amount *= Mathf.Sign(RB.velocity.x);
            RB.AddForce(Vector2.right * -amount, ForceMode2D.Impulse);
        }
        //jump checks
        if (IsJumping && RB.velocity.y < 0) {
            IsJumping = false;
        }
        if (LastOnGroundTime > 0 && !IsJumping) {
            JumpCut = false;

            if (!IsJumping)
                JumpFalling = false;
        }
        if (CanJump() && LastPressedJumpTime > 0) {
            IsJumping = true;
            JumpCut = false;
            JumpFalling = false;
            Jump();
        }
        //gravity checks for jumping
        if (RB.velocity.y < 0) {
            SetGravityScale(gravityScale * jumpCutGravityMult);
            //Caps maximum fall speed, so when falling over large distances we don't accelerate to insanely high speeds
            RB.velocity = new Vector2(RB.velocity.x, Mathf.Max(RB.velocity.y, -maxFastFallSpeed));
        }
        else if (JumpCut) {
            //Higher gravity if jump button released
            SetGravityScale(gravityScale * fastFallGravityMult);
            RB.velocity = new Vector2(RB.velocity.x, Mathf.Max(RB.velocity.y, -maxFallSpeed));
        }
        else if ((IsJumping || JumpFalling) && Mathf.Abs(RB.velocity.y) < jumpHangTimeThreshold) {
            SetGravityScale(gravityScale * jumpHangGravityMult);
        }
        else {
            //Default gravity if standing on a platform or moving upwards
            SetGravityScale(gravityScale);
        }
    }
    private void Run() {
        float targetSpeed = moveInput.x * moveSpeed;
        float accelRate = 0;
        if(LastOnGroundTime > 0) { 
            accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
        }
        if ((IsJumping || JumpFalling) && Mathf.Abs(RB.velocity.y) < jumpHangTimeThreshold) {
            accelRate *= jumpHangAccelerationMult;
            targetSpeed *= jumpHangMaxSpeedMult;
        }
        float speedDif = targetSpeed - RB.velocity.x;
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);

        RB.AddForce(movement * Vector2.right);
    }
    private void Jump() {
        LastPressedJumpTime = 0;
        LastOnGroundTime = 0;
        float force = jumpForce;
        if (RB.velocity.y < 0)
            force -= RB.velocity.y;

        RB.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }
    public void OnJumpInput() {
        LastPressedJumpTime = jumpInputBufferTime;
    }
    public void OnJumpUpInput() {
        if (CanJumpCut()) {
            JumpCut = true;
        }
    }
    public void SetGravityScale(float scale) {
        RB.gravityScale = scale;
    }
    private void Turn() { 
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        IsFacingRight = !IsFacingRight;

    }
    public void CheckDirection(bool isMovingRight) {
        if (isMovingRight != IsFacingRight)
            Turn();
    }
    private bool CanJump() {
        return LastOnGroundTime > 0 && !IsJumping;
    }
    private bool CanJumpCut() {
        return IsJumping && RB.velocity.y > 0;
    }
    private void OnValidate() {
        //running accel
        acceleration = (50 * accelTime) / moveSpeed;
        decceleration = (50 * deccelTime) / moveSpeed;
        accelTime = Mathf.Clamp(accelTime, 0.01f, moveSpeed);
        deccelTime = Mathf.Clamp(deccelTime, 0.01f, moveSpeed);
        //jump calc
        gravityStrength = -(2 * jumpHeight) / (jumpTimeToApex * jumpTimeToApex);
        gravityScale = gravityStrength / Physics2D.gravity.y;
        //jump force
        jumpForce = Mathf.Abs(gravityStrength) * jumpTimeToApex;
    }
    private bool groundCheck() {
        RaycastHit2D result = Physics2D.CircleCast(circleCenter,circleRadius,Vector2.down,1f,ground);
        return result;
    }
}
