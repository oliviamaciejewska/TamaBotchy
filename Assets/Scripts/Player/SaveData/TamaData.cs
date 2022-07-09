using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

//Class holding data to be saved.
public class TamaData
{
    public float health;
    public float hunger;
    public float lastTime;

    public Tama tama;

    public TamaData ()
    {
        this.health = 100.0f;
        this.hunger = 100.0f;
        this.lastTime = 0.0f;

        tama = new Tama();
    }

}
