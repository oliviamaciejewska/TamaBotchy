using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        MySociability = "";
        MyFriendliness = "";
        MyHygeine = "";
        MyLikes = "";
        MyDislikes = "";
    }

    public void SetTamaStats(string sociability, string friendliness, string hygeine, string likes, string dislikes)
    {
        mySociability = sociability;
        myFriendliness = friendliness;
        myHygeine = hygeine;
        myLikes = likes;
        myDislikes = dislikes;

        Debug.Log("mySoc: " + MySociability);
    }
    //Interface method
    public void LoadData(TamaData data)
    {
        data.mySociability = this.MySociability;
        data.myFriendliness = this.MyFriendliness;
        data.myHygeine = this.MyHygeine;
        data.myLikes = this.MyLikes;
        data.myDislikes = this.MyDislikes;
    }

    //Interface method
    public void SaveData(TamaData data)
    {
        this.MySociability = data.mySociability;
        this.MyFriendliness = data.myFriendliness;
        this.MyHygeine = data.myHygeine;
        this.MyLikes = data.myLikes;
        this.MyDislikes = data.myDislikes;
    }
}
