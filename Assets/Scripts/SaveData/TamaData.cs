using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

//Class holding data to be saved.
public class TamaData
{
    public float health;
    public float hunger;

    public string mySociability;
    public string myFriendliness;
    public string myHygeine;
    public string myLikes;
    public string myDislikes;

    public string lastTime;

    public string timeTamaBorn;

    public string currentState;

    public int tamaSprite;

    public string tamaName;

    public TamaData ()
    {
        this.health = 100;
        this.hunger = 100;
        this.lastTime = "";

        //This should only be initialized once for the save file
    }

}
