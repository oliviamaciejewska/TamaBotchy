using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TamaAge : MonoBehaviour, IDataPersistance
{
    private int timeTamaBorn;
    public int TimeTamaBorn { get => timeTamaBorn; set => timeTamaBorn = value; }
    public int currentAge;

    public const int TicksPerSecond = 10000000;

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("CalculateTicksFromBirth", 0.0f, 60.0f);
    }

    private void CalculateTicksFromBirth()
    {
        int currentTime = TimeManager.GetCurrentTickSeconds();

        currentAge = currentTime - timeTamaBorn;
    }


    //Interface method
    public void LoadData(TamaData data)
    {
        this.TimeTamaBorn = data.timeTamaBorn;
    }

    //Interface method
    public void SaveData(TamaData data)
    {
        data.timeTamaBorn = this.TimeTamaBorn;
    }
}
