using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BallLifeText : MonoBehaviour
{
    public static BallLifeText instance;

    public int health = 3;

    public TMP_Text lifeText;

    private void Awake()
    {
        lifeText.text = "Life: " + health;
        instance = this;
    }

    public void DecreaseLife(int amount)
    {
        health += amount;
        lifeText.text = "Life: " + health;
    }
}
