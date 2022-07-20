using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TamaGenerator : MonoBehaviour
{
    public static TamaGenerator instance = null;

    [Header("Data")]
    [SerializeField] private TamaStats tamaStats;

    private TamaAttributes tamaAttributes;
    private TamaAge tamaAge;
    private int tamaSpriteIndex;

    private TamaStateMachine tamaStateMachine;
    
    public int amountOfStats = 5;
    public static TamaGenerator Instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one TamaGenerator in scene");
        }
        instance = this;
    }

    //Generates new tama with randomized attributes when the state changes from egg to adult. Records the current time born at this moment to pass into the tamaAge class
    public void MakeTama()
    {
        tamaAttributes = GetComponent<TamaAttributes>();
        tamaStateMachine = GetComponent<TamaStateMachine>();
        tamaAge = GetComponent<TamaAge>();

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

        this.tamaSpriteIndex = Random.Range(1, 13);

        tamaStateMachine.tamaSpriteIndex = this.tamaSpriteIndex;
    }

}
