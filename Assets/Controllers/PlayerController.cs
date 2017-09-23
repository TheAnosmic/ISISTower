using UnityEngine;

[System.Serializable]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour ,IController
{
    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float slideForce;

    [SerializeField]
    private int playerNumber = 0;

    private Rigidbody rigidBody;

    private bool isJumping = false;

    private string jump_axis;
    private string horizontal_axis;

    private const string GROUND_TAG = "Ground";

    public void Awake()
    {
        jump_axis = string.Format("P{0}_Jump", playerNumber);
        horizontal_axis = string.Format("P{0}_Horizontal", playerNumber);

        rigidBody = GetComponent<Rigidbody>();
    }
    
    private void Jump()
    {
        rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
        isJumping = true;
    }

    public void UpdateMovement()
    {
        if (Input.GetButtonDown(jump_axis))
        {
            if (!isJumping)
            {
                Jump();
            }
        }

        float horizontal = Input.GetAxis(horizontal_axis) * Time.deltaTime;
        Debug.Log("horizontal p1 : " + Input.GetAxis(horizontal_axis) + " horizontal p2: ");
        foreach (string name in Input.GetJoystickNames())
        {
            Debug.Log("joystick : " + name);
        }
        transform.Translate(new Vector3(horizontal * slideForce, 0, 0), Space.World);
    }

    public void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            float normal = Vector2.Dot(contact.normal, Vector3.up);
            if (normal > 0.5)
            {
                isJumping = false;
                break;
            }
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag(GROUND_TAG))
        {
            isJumping = true;
        }
    }
}
