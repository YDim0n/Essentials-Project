using UnityEngine;

public class MoveAndCollect : MonoBehaviour
{
    public float impulseForce = 3f;  // Force of impulse
    public float speed = 2f;
    private Rigidbody rb;
    private bool isStopped = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Adding forward impulse
        rb.AddForce(transform.forward * impulseForce, ForceMode.Impulse);
    }

    void OnTriggerEnter(UnityEngine.Collider other)
	{
        if (other.gameObject.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);  // Collecting the item
            Debug.Log("Collected: " + other.gameObject.name);
        }

        if (other.gameObject.CompareTag("Stop"))
        {
            rb.linearVelocity = Vector3.zero;  // Stopping object
            Debug.Log(rb.gameObject.name + " stop on: " + other.gameObject.name);
            isStopped = true;
        }
    }

    void Update()
    {
        if (isStopped) return;
        rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
    }
}