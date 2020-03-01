using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int lifes;
    public int score;

    public TextMeshProUGUI scoreText;
    public Image bullet;
    public Image laser;

    void Start()
    {
        lifes = 3;
        score = 0;
        scoreText.text = "" + score;

        bullet.enabled = true;
        laser.enabled = false;
    }

    public void ChangeShotImage(Style style)
    {
        if (style == Style.Normal)
        {
            bullet.enabled = true;
            laser.enabled = false;
        }
        else
        {
            bullet.enabled = false;
            laser.enabled = true;
        }
    }

    public void IncreaseScore(int type)
    {
        if (type == 0) score += 100;
        else score += 50;

        scoreText.text = "" + score;
    }

}
