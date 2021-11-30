using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.Events;
using GameMode;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float jumpForce;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float lookSpeed;
    [SerializeField] private float lookLimitX;
    [SerializeField] private float groundedMargin;
    [SerializeField] private KeyCode runKey;


    private Rigidbody rb;
    private Vector3 movement;
    private Vector3 forward;
    private Vector3 right;
    private Vector2 walkingInput;
    private float xRotation = 0f;
    private float speed;

    private RaycastHit hit;

    private Animator animator;

    public bool isJozin = true;

    public UnityEvent OnPositionUpdate = new UnityEvent();

    public AttackCollision attackCollider;

    public GameObject jozin;

    void TurnIntoJozin()
    {
        if (isJozin) { return; }

        //var jozin = GameObject.FindGameObjectWithTag("Jozin");
        if (jozin == null) { Debug.Log("Wtf"); }
        gameObject.SetActive(false);
        jozin.gameObject.SetActive(true);
        jozin.transform.position = transform.position;
        //GameObject.Find("FBeast").GetComponent<MusicManager>().SetChaseParemeter(3);
        //jozin.GetComponent<Camera>().enabled = true;
    }
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        if (isJozin) { attackCollider = gameObject.AddComponent<AttackCollision>(); }
        
        forward = transform.forward;
        right = transform.right;
    }

    private void Start()
    {
        var mode = GameObject.FindGameObjectWithTag("GameMode").GetComponent<GameMode.GameMode>();
        mode.OnPhaseTwoBegin.AddListener(TurnIntoJozin);
        if (jozin != null && !isJozin) { jozin.SetActive(false); }
    }

    void Update()
    {
        ManageInput();

        if(IsGrounded())
        {
            forward = transform.forward;
            right = transform.right;
        }
        movement = forward * walkingInput.y + right * walkingInput.x;

        rb.MovePosition(rb.position + movement * Time.deltaTime);
        
        OnPositionUpdate.Invoke();
    }

    private void ManageInput()
    {

        // walking
        walkingInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;
        if (Input.GetMouseButton(0) && isJozin)
        {
            animator.SetBool("IsAttacking", true);
        }
        
        // walking
        walkingInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * walkSpeed;
        animator.SetFloat("Speed", walkingInput.magnitude);

        // jumping
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(transform.up * jumpForce);
        }

        //rotating
        ManageRotating();
    }

    private bool IsGrounded()
    {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, groundedMargin))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void ManageRotating()
    {
        xRotation += -Input.GetAxis("Mouse Y") * lookSpeed;
        xRotation = Mathf.Clamp(xRotation, -lookLimitX, lookLimitX);
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        rb.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        
        animator.SetFloat("RotateSpeed", Mathf.Abs(Input.GetAxis("Mouse X")));
    }

    public virtual void OnAttackStarted()
    {
        attackCollider.isEnabled = true;
    }

    public virtual void OnAttackFinished()
    {
        animator.SetBool("IsAttacking", false);
        attackCollider.isEnabled = false;
    }
}
