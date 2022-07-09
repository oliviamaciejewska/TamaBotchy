using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tama
{
    public string mySociability;
    public string myFriendliness;
    public string myHygeine;
    public string myLikes;
    public string myDislikes;

    public void SetTamaStats(string sociability, string friendliness, string hygeine, string likes, string dislikes)
    {
        this.mySociability = sociability;
        this.myFriendliness = friendliness;
        this.myHygeine = hygeine;
        this.myLikes = likes;
        this.myDislikes = dislikes;

        Debug.Log("mySoc: " + mySociability);
    }

}
