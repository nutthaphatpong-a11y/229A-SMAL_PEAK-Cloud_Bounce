using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject[] brickPrefabs;
    public Transform parent;

    public int rows;
    public int cols;
    public float spacing = 10f;

    public int brickCount;

    void Start()
    {
        GenerateLevel();
    }

    public void GenerateLevel()
    {
        int score = ScoreManager.instance.score;
        if (score < 1000)
        {
            brickCount = 0;
            float offsetX = (cols - 1) * spacing / 2;
            float offsetZ = (rows - 1) * spacing / 2;

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    // สุ่มว่าจะมี Brick หรือไม่
                    if (Random.value > 0.3f)
                    {
                        Vector3 pos = new Vector3(
                            x * spacing - offsetX,
                            0,
                            y * spacing - offsetZ
                        );


                        GameObject brick = Instantiate(
                            brickPrefabs[Random.Range(0, brickPrefabs.Length)],
                            pos,
                            Quaternion.identity,
                            parent
                        );

                        brickCount++;
                    }
                }
            }
        }
        else if (score >= 1000)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void BrickDestroyed()
    {
        brickCount--;

        if (brickCount <= 0)
        {
            GenerateLevel();
        }
    }

    public void GoToCredit()
    {
        
    }
}