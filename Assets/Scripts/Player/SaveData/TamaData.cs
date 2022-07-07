using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TamaData
{
    public float health;
    public float hunger;
    public float lastTime;

    public TamaData ()
    {
        this.health = 100.0f;
        this.hunger = 100.0f;
        this.lastTime = 0.0f;
    }

}
