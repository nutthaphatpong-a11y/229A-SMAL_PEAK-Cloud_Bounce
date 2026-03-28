using Unity.VisualScripting;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public AudioClip PowerUpSouud;
    public enum PowerType
    {
        MultiBall,
        ExpandPaddle
    }

    public PowerType type;

    public GameObject ballPrefab;

    static bool IsExpandPaddle = false;

    private void Start()
    {
        type = (PowerType)Random.Range(0, 2);
        SetColor();
    }

    void SetColor()
    {
        Renderer r = GetComponent<Renderer>();

        if (type == PowerType.MultiBall)
            r.material.color = Color.blue;

        if (type == PowerType.ExpandPaddle)
            r.material.color = Color.green;

    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Paddle")) return;

        if (type == PowerType.MultiBall)
        {
            Instantiate(ballPrefab, transform.position, Quaternion.identity);
            Instantiate(ballPrefab, transform.position, Quaternion.identity);
        }


        if (type == PowerType.ExpandPaddle && !IsExpandPaddle)
        {
            other.transform.localScale += new Vector3(1, 0, 0);
            IsExpandPaddle = true;
        }
        PlaySound(PowerUpSouud);



        Destroy(gameObject);
    }
    private void Update()
    {
        transform.Translate(Vector3.back * 7 * Time.deltaTime);
    }
    void PlaySound(AudioClip clip)
    {
        AudioSource source = new GameObject().AddComponent<AudioSource>();
        source.clip = clip;
        source.pitch = Random.Range(0.9f, 1.1f);
        source.Play();

        Destroy(source.gameObject, clip.length);
    }
}
