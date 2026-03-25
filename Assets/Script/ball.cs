using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallPhysics : MonoBehaviour
{
    public float speed = 10f;
    public float minYDirection = 0.3f;
    public GameObject powerUp;
    public int scoreValue = 10;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        LaunchBall();
    }

    void LaunchBall()
    {
        Vector3 dir = new Vector3(
            Random.Range(-1f, 1f),
            0,
            Random.Range(0.5f, 1f)
        ).normalized;

        rb.linearVelocity = dir * speed;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = rb.linearVelocity.normalized * speed;

        Vector3 dir = rb.linearVelocity.normalized;

        if (Mathf.Abs(dir.z) < minYDirection)
        {
            dir.z = Mathf.Sign(dir.z) * minYDirection;
            rb.linearVelocity = dir.normalized * speed;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Or")
        {
            if (Random.value < 0.2f)
            {
                Instantiate(powerUp, transform.position, Quaternion.identity);
            }
            ScoreManager.instance.AddScore(scoreValue);
            Debug.Log(scoreValue);
            Object.FindFirstObjectByType<LevelManager>().BrickDestroyed();
            Destroy(other.gameObject);
        }
    }
}