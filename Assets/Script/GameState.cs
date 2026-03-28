using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public int hitCount = 0;
    public Transform ball;
    
    Vector3 startPos;

    void Start()
    {
        startPos = ball.position;

    } 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            BallLifeText.instance.DecreaseLife(-1);
            hitCount++;
            ball.position = startPos;
            ball.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;

            if (hitCount >= 3)
            {
                Debug.Log("Game Over");
                Time.timeScale = 0f;
                SceneManager.LoadScene(3);
            }
        }
    }
}
