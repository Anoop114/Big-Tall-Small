using UnityEngine;

public class PlayerMovnment : MonoBehaviour
{
    [Header("Refrance")]
    public GameObject big;
    public GameObject tall;
    public GameObject small;
    public GameObject WinUi;
    public float playerSpeed = 5;
    public float jumpSpeed = 5;
    public bool bigBool = false;
    public bool tallBool = true;
    public bool smallBool = false;
    public int winCount = 3;

    //private
    private Rigidbody bigRigidBody;
    private Rigidbody tallRigidBody;
    private Rigidbody smallRigidBody;
    private bool moveLeft;
    private bool moveRight;
    private float horizontalMove;
    private bool isWin;

    void Awake()
    {
        Time.timeScale = 1;
    }
    void Start()
    {
        bigRigidBody = big.GetComponent<Rigidbody>();
        tallRigidBody = tall.GetComponent<Rigidbody>();
        smallRigidBody = small.GetComponent<Rigidbody>();

        moveLeft = false;
        moveRight = false;
        isWin = false;

    }

    public void BigActive()
    {
        bigBool = true;
        tallBool = false;
        smallBool = false;
    }
    public void TallActive()
    {
        bigBool = false;
        tallBool = true;
        smallBool = false;
    }
    public void SmallActive()
    {
        bigBool = false;
        tallBool = false;
        smallBool = true;
    }
    public void PointerDownMoveLeft()
    {
        moveLeft = true;
    }

    public void PointerUpMoveLeft()
    {
        moveLeft = false;
    }
    public void PointerDownMoveRight()
    {
        moveRight = true;
    }
    public void PointerUpMoveRight()
    {
        moveRight = false;
    }

    private void MovePlayer()
    {
        if(moveLeft)
        {
            horizontalMove = -playerSpeed;
        }
        else if(moveRight)
        {
            horizontalMove = playerSpeed;
        }
        else
        {
            horizontalMove = 0;
        }
    }

    public void JumpButton()
    {
        if(bigRigidBody.velocity.y == 0 && bigBool)
        {
            bigRigidBody.velocity = Vector2.up * jumpSpeed;
        }
        if(tallRigidBody.velocity.y == 0 && tallBool)
        {
            tallRigidBody.velocity = Vector2.up * jumpSpeed;
        }
        if(smallRigidBody.velocity.y == 0 && smallBool)
        {
            smallRigidBody.velocity = Vector2.up * jumpSpeed;
        }
    }
    private void FixedUpdate()
    {
        if(bigBool)
        {
            bigRigidBody.velocity = new Vector2(horizontalMove,bigRigidBody.velocity.y);
        }
        if(tallBool)
        {
            tallRigidBody.velocity = new Vector2(horizontalMove,tallRigidBody.velocity.y);
        }
        if(smallBool)
        {
            smallRigidBody.velocity = new Vector2(horizontalMove,smallRigidBody.velocity.y);
        }
        if(winCount == 0)
        {
            Time.timeScale = 0;
            WinUi.SetActive(true);
        }
    }
    void Update()
    {
        MovePlayer();
        
    }
}
