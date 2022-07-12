using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TamaAge : MonoBehaviour, IDataPersistance
{
    private DateTime timeTamaBorn;
    public DateTime TimeTamaBorn { get => timeTamaBorn; set => timeTamaBorn = value; }
    public double currentAge;

    public const int TicksPerSecond = 10000000;

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("CalculateTicksFromBirth", 0.0f, 60.0f);
    }

    private void CalculateTicksFromBirth()
    {
        DateTime currentTime = TimeManager.GetCurrentTickSeconds();

        currentAge = currentTime.Subtract(timeTamaBorn).TotalSeconds;
    }


    //Interface method
    public void LoadData(TamaData data)
    {
        this.TimeTamaBorn = DateTime.Parse(data.timeTamaBorn);
    }

    //Interface method
    public void SaveData(TamaData data)
    {
        data.timeTamaBorn = timeTamaBorn.ToString();
    }
}
