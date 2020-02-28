using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int lifes;
    public float energy;
    public int score;


    void Start()
    {
        lifes = 3;
        energy = 100;
        score = 0;
    }
}
