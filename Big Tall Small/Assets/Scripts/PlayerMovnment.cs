using UnityEngine;

public class PlayerMovnment : MonoBehaviour
{
    [Header("Refrance")]
    public GameObject big;
    public GameObject tall;
    public GameObject small;
    public GameObject WinUi;
    public GameObject mainUi;
    public float playerSpeed = 5;
    public float jumpSpeed = 5;
    public bool bigBool = false;
    public bool tallBool = true;
    public bool smallBool = false;
    public int winCount = 3;

    [Header("Player Rotation Refrance")]
    public GameObject bigRotate;
    public GameObject tallRotate;
    public GameObject smallRotate;

    [Header("Player Animations")]
    public Animator bigAnimator;
    public Animator tallAnimator;
    public Animator smallAnimator;

    [Header("UI/Player Refrance")]
    public GameObject bigUIArrow;
    public GameObject tallUIArrow;
    public GameObject smallUIArrow;

    //private
    private Rigidbody bigRigidBody;
    private Rigidbody tallRigidBody;
    private Rigidbody smallRigidBody;
    private bool moveLeft;
    private bool moveRight;
    private float horizontalMove;
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
        bigUIArrow.SetActive(false);
        tallUIArrow.SetActive(true);
        smallUIArrow.SetActive(false);

    }

    // UI Button Actions
    public void BigActive()
    {
        bigBool = true;
        tallBool = false;
        smallBool = false;
        bigUIArrow.SetActive(true);
        tallUIArrow.SetActive(false);
        smallUIArrow.SetActive(false);
    }
    public void TallActive()
    {
        bigBool = false;
        tallBool = true;
        smallBool = false;
        bigUIArrow.SetActive(false);
        tallUIArrow.SetActive(true);
        smallUIArrow.SetActive(false);
    }
    public void SmallActive()
    {
        bigBool = false;
        tallBool = false;
        smallBool = true;
        bigUIArrow.SetActive(false);
        tallUIArrow.SetActive(false);
        smallUIArrow.SetActive(true);
    }


    // UI Event Trigger
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

    // UI Function to rotate Player
    public void PointerDownRotateLeft()
    {
        if(bigBool)
        {
            bigRotate.transform.Rotate (new Vector3 (0, 90, 0));
            bigAnimator.SetBool("walk",true);
        }
        if(tallBool)
        {
            tallRotate.transform.Rotate (new Vector3 (0, 90, 0));
            tallAnimator.SetBool("walk",true);
        }
        if(smallBool)
        {
            smallRotate.transform.Rotate (new Vector3 (0, 90, 0));
            smallAnimator.SetBool("walk",true);
        }

    }
    public void PointerUpRotateLeft()
    {
        if(bigBool)
        {
            bigRotate.transform.Rotate (new Vector3 (0, -90, 0));
            bigAnimator.SetBool("walk",false);
        }
        if(tallBool)
        {
            tallRotate.transform.Rotate (new Vector3 (0, -90, 0));
            tallAnimator.SetBool("walk",false);
        }
        if(smallBool)
        {
            smallRotate.transform.Rotate (new Vector3 (0, -90, 0));
            smallAnimator.SetBool("walk",false);
        }

    }
    public void PointerDownRotateRight()
    {
        if(bigBool)
        {
            bigRotate.transform.Rotate (new Vector3 (0, -90, 0));
            bigAnimator.SetBool("walk",true);
        }
        if(tallBool)
        {
            tallRotate.transform.Rotate (new Vector3 (0, -90, 0));
            tallAnimator.SetBool("walk",true);
        }
        if(smallBool)
        {
            smallRotate.transform.Rotate (new Vector3 (0, -90, 0));
            smallAnimator.SetBool("walk",true);
        }

    }
    public void PointerUpRotateRight()
    {
        if(bigBool)
        {
            bigRotate.transform.Rotate (new Vector3 (0, 90, 0));
            bigAnimator.SetBool("walk",false);
        }
        if(tallBool)
        {
            tallRotate.transform.Rotate (new Vector3 (0, 90, 0));
            tallAnimator.SetBool("walk",false);
        }
        if(smallBool)
        {
            smallRotate.transform.Rotate (new Vector3 (0, 90, 0));
            smallAnimator.SetBool("walk",false);
        }
    }


    // Player Move Function
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
        // if(bigRigidBody.velocity.y == 0 && bigBool)
        if(bigBool)
        {
            bigRigidBody.velocity = Vector2.up * jumpSpeed;
            // bigAnimator.SetBool("jump",false);
        }
        if(tallBool)
        // if(tallRigidBody.velocity.y == 0 && tallBool)
        {
            tallRigidBody.velocity = Vector2.up * jumpSpeed;
        }
        // if(smallRigidBody.velocity.y == 0 && smallBool)
        if(smallBool)
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
            mainUi.SetActive(false);
        }
    }
    void Update()
    {
        MovePlayer();
    }

}
