using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public NavMeshAgent agent;
    [SerializeField] private Rigidbody _rg;
    [SerializeField] private FloatingJoystick _joystick;
    public float _moveSpeed;
    Animator animator;

    public Transform GroundCheck;
    public LayerMask groundSwimMask;
    [SerializeField] float GroundCheckDistance = 0.4f;

    public bool isMove;
    bool isGrounded;
    public Camera mainCamera;
    [SerializeField] GameObject CanvasJoyStick;
    private float currentMoveSpeed;
    private void Awake()
    {
        instance = this;
        if (mainCamera == null)
            mainCamera = Camera.main;

       
 
    }
    private void Start()
    {
        currentMoveSpeed = 2.5f;
        animator = GetComponentInChildren<Animator>();
      
    }

    void Update()
    {

        
        if (GameManager.instance.isPlayGame ==true)
        {
            StartCoroutine(TimeCountDownPlayGame());
        }    
        //chạm vào để hiển thị nút di chuyển
        Touch();

        CheckGroundToSwim();

        //kiểm tra thử về anim mở cử lồng nhốt
        prisonAnim();

        //kiểm tra thử về anim win
        WinAnim();

        //kiểm tra thử về anim close
        CloseAnim();



    }

    public void WinGame()
    {
        
    }   


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PaintsGlue")
        {

            StartCoroutine(changeMoveSpeedSlow());

        }

        if (other.gameObject.tag == "Speed")
        {

            StartCoroutine(changeMoveSpeedFast());
            Destroy(other.gameObject);

        }
    }

    IEnumerator changeMoveSpeedSlow()
    {
        _moveSpeed = _moveSpeed / 2 + 0.2f;
        yield return new WaitForSeconds(5f);
        _moveSpeed = currentMoveSpeed;
    }


    IEnumerator changeMoveSpeedFast()
    {
       _moveSpeed = _moveSpeed + 0.75f;
        yield return new WaitForSeconds(5f);
        _moveSpeed = currentMoveSpeed;
    }

    public void Touch()
    {

        if (Input.GetMouseButton(0))
        {
            isMove = true;
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            PlayerMove();
            animator.SetFloat("MoveAnim", 1);
        }
        else
        {
            _rg.velocity = new Vector3(_joystick.Horizontal, _rg.velocity.y, _joystick.Vertical);
            animator.SetFloat("MoveAnim", 0);
            animator.SetFloat("IdleAnim", 1);
            isMove = false;
        }

    }

    public void PlayerMove()
    {
        // di chuyển nhân vật
        _rg.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rg.velocity.y, _joystick.Vertical * _moveSpeed);

        //Kiểm tra xem nhân vật có di chuyển hay không?
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            //code khả năng xoay người của nhân vật
            transform.rotation = Quaternion.LookRotation(_rg.velocity);

        }
   
   
    }

    public void CheckGroundToSwim()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundCheckDistance, groundSwimMask);
        if(isGrounded)
        {
            animator.SetBool("isGroundSwim", true);
        }
        else
        {
            animator.SetBool("isGroundSwim", false);

        }    
        
        if(isGrounded && isMove ==false)
        {
            animator.SetBool("isGroundSwimIdle", true);
        }

        if (isGrounded && isMove == true)
        {
            animator.SetBool("isGroundSwimIdle", false);
        }
    }  
    
    public void prisonAnim()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isPrison", true);
        }
        else
        {
            animator.SetBool("isPrison", false);
        }    
    }


    public void WinAnim()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("isWin", true);
        }

    }

    public void CloseAnim()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            animator.SetBool("isClose", true);
        }

    }

    IEnumerator TimeCountDownPlayGame()
    {
        yield return new WaitForSeconds(3f);
        CanvasJoyStick.SetActive(true);
        
    }
   
}
