using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float sidewaysSpeed = 5f;
    public float jumpForce = 5f;

    private float currentForwardSpeed;
    private float currentSidewaysSpeed;

    private Rigidbody rb;
    private bool isGrounded = true;
    private bool jumpRequested = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        currentForwardSpeed = forwardSpeed;
        currentSidewaysSpeed = sidewaysSpeed;
    }

    void Update()
    {
        // Check for jump input in Update for better input responsiveness
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpRequested = true;
        }
    }

    void FixedUpdate()
    {
        // Get input
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move player
        Vector3 movement = transform.forward * currentForwardSpeed + transform.right * horizontalInput * currentSidewaysSpeed;
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);

        // Handle jump
        if (jumpRequested)
        {
            Jump();
            jumpRequested = false;
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts.Length > 0 && collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SlowZone"))
        {
            currentForwardSpeed = forwardSpeed * 0.2f;
            currentSidewaysSpeed = sidewaysSpeed * 0.2f;
            StartCoroutine(ResetSpeedAfterDelay(30f));
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SlowZone"))
        {
            currentForwardSpeed = forwardSpeed;
            currentSidewaysSpeed = sidewaysSpeed;
        }
    }

    private IEnumerator ResetSpeedAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        currentForwardSpeed = forwardSpeed;
        currentSidewaysSpeed = sidewaysSpeed;
    }
}





