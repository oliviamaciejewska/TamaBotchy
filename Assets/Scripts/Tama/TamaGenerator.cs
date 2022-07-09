using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamaGenerator : MonoBehaviour, IDataPersistance
{
    public static TamaGenerator instance = null;

    [Header("Data")]
    [SerializeField] private TamaStats tamaStats;

    [SerializeField] private Tama tama;
    public int amountOfStats = 5;
    public static TamaGenerator Instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one TamaGenerator in scene");
        }
        instance = this;

        MakeTama();
    }

    public void MakeTama()
    {
        int socIndex = Random.Range(0, tamaStats.sociability.Length);
        int friendIndex = Random.Range(0, tamaStats.friendliness.Length);
        int hygIndex = Random.Range(0, tamaStats.hygeine.Length);
        int likeIndex = Random.Range(0, tamaStats.likesDislikes.Length);
        int disIndex = Random.Range(0, tamaStats.likesDislikes.Length);

        this.tama.SetTamaStats(tamaStats.sociability[socIndex], tamaStats.friendliness[friendIndex], tamaStats.hygeine[hygIndex], tamaStats.likesDislikes[likeIndex], tamaStats.likesDislikes[disIndex]);
    }

    //Interface method
    public void LoadData(TamaData data)
    { 
        this.tama.SetTamaStats(data.tama.mySociability, data.tama.myFriendliness, data.tama.myHygeine, data.tama.myLikes, data.tama.myDislikes);
    }

    //Interface method
    public void SaveData(TamaData data)
    {
        tama.mySociability = data.tama.mySociability;
        tama.myFriendliness = data.tama.myFriendliness;
        tama.myHygeine = data.tama.myHygeine;
        tama.myLikes = data.tama.myLikes;
        tama.myDislikes = data.tama.myDislikes;
    }

}
