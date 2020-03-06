using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvDestrctible : MonoBehaviour, Hitable
{
    public enum Hardness { Soft, Hard}
    public Hardness state;

    public void Break()
    {
        Destroy(gameObject);
    }

    public void Execute(Style style)
    {
        if (state == Hardness.Soft)
        {
            Break();
        } 
        else if (style == Style.Charged && state == Hardness.Hard)
        {
            Break();
        }
        
    }
}
