using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] brickPrefabs;
    public Transform parent;

    public int rows = 5;
    public int cols = 8;
    public float spacing = 1.2f;

    public int brickCount;

    void Start()
    {
        GenerateLevel();
    }

    public void GenerateLevel()
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

    public void BrickDestroyed()
    {
        brickCount--;

        if (brickCount <= 0)
        {
            GenerateLevel();
        }
    }
}