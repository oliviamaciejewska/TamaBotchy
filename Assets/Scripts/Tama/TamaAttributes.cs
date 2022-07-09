using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tama attributes class contains the randomized attributes assigned to tama on birth
public class TamaAttributes : MonoBehaviour, IDataPersistance
{
    [SerializeField] private string mySociability;
    [SerializeField] private string myFriendliness;
    [SerializeField] private string myHygeine;
    [SerializeField] private string myLikes;
    [SerializeField] private string myDislikes;

    public string MySociability { get => mySociability; set => mySociability = value; }
    public string MyFriendliness { get => myFriendliness; set => myFriendliness = value; }
    public string MyHygeine { get => myHygeine; set => myHygeine = value; }
    public string MyLikes { get => myLikes; set => myLikes = value; }
    public string MyDislikes { get => myDislikes; set => myDislikes = value; }


    public void SetTamaStats(string sociability, string friendliness, string hygeine, string likes, string dislikes)
    {
        MySociability = sociability;
        MyFriendliness = friendliness;
        MyHygeine = hygeine;
        MyLikes = likes;
        MyDislikes = dislikes;

        Debug.Log("mySoc: " + MySociability);
    }

    //Interface method
    public void LoadData(TamaData data)
    {
        this.MySociability = data.mySociability;
        this.MyFriendliness = data.myFriendliness;
        this.MyHygeine = data.myHygeine;
        this.MyLikes = data.myLikes;
        this.MyDislikes = data.myDislikes;
    }

    //Interface method
    public void SaveData(TamaData data)
    {
        data.mySociability = this.MySociability;
        data.myFriendliness = this.MyFriendliness;
        data.myHygeine = this.MyHygeine;
        data.myLikes = this.MyLikes;
        data.myDislikes = this.MyDislikes;
    }
}
