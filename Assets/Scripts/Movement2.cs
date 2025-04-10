using UnityEngine;


//script for animating the character walk
[RequireComponent(typeof(Rigidbody2D))]
public class Movement2 : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 2f;
    Vector2 motionVector;
    public Vector2 lastMotionVector;
    Animator animator;
    public bool moving;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    //for moving and animating the walk
    //also for storing last direction of motion for the idle in diff directions
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        motionVector = new Vector2(
            Input.GetAxisRaw("Horizontal"), 
            Input.GetAxisRaw("Vertical"));

        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);

        moving = horizontal != 0 || vertical != 0;
        animator.SetBool("moving", moving);

        if(horizontal != 0 || vertical != 0)
        {
            lastMotionVector = new Vector2(
                horizontal,
                vertical).normalized;

            animator.SetFloat("lastHorizontal", horizontal);
            animator.SetFloat("lastVertical", vertical);
        }
    }
    //updates to call each frame
    void FixedUpdate()
    {
        Move();
    }

    //equation for movement and velocity
    private void Move()
    {
        rb.linearVelocity = motionVector * speed;
    }
}
