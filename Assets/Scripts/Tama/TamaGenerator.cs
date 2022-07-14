using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//Generates new tama with randomized attributes.
public class TamaGenerator : MonoBehaviour
{
    public static TamaGenerator instance = null;

    [Header("Data")]
    [SerializeField] private TamaStats tamaStats;

    //[SerializeField] private GameObject thisTama;
    private TamaAttributes tamaAttributes;
    private TamaAge tamaAge;
    
    public int amountOfStats = 5;
    public static TamaGenerator Instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one TamaGenerator in scene");
        }
        instance = this;


        //MakeTama();
    }

    public void MakeTama(GameObject thisTama)
    {
        tamaAttributes = thisTama.GetComponent<TamaAttributes>();
        tamaAge = thisTama.GetComponent<TamaAge>();
        int socIndex = Random.Range(0, tamaStats.sociability.Length);
        int friendIndex = Random.Range(0, tamaStats.friendliness.Length);
        int hygIndex = Random.Range(0, tamaStats.hygeine.Length);
        int likeIndex = Random.Range(0, tamaStats.likesDislikes.Length);
        int disIndex = Random.Range(0, tamaStats.likesDislikes.Length);
        while (disIndex == likeIndex)
        {
            disIndex = Random.Range(0, tamaStats.likesDislikes.Length);
        }

        this.tamaAttributes.SetTamaStats(tamaStats.sociability[socIndex], tamaStats.friendliness[friendIndex], tamaStats.hygeine[hygIndex], tamaStats.likesDislikes[likeIndex], tamaStats.likesDislikes[disIndex]);

        this.tamaAge.DateTimeTamaBorn = System.DateTime.UtcNow;
    }

}
