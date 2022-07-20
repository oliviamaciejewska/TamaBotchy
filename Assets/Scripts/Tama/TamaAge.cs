using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TamaAge : MonoBehaviour, IDataPersistance
{
    private DateTime dateTimeTamaBorn;
    public DateTime DateTimeTamaBorn { get => dateTimeTamaBorn; set => dateTimeTamaBorn = value; }
    public double currentAgeSeconds;

    void Update()
    {
        InvokeRepeating("CalculateTicksFromBirth", 0.0f, 60.0f);
    }

    //Repeatedly calculates the age- this can be adjusted once we change the time and autosave times to not have unncessary iterations
    private void CalculateTicksFromBirth()
    {
        DateTime currentTime = TimeManager.GetCurrentTime();

        currentAgeSeconds = currentTime.Subtract(dateTimeTamaBorn).TotalSeconds;
    }

    //Interface method
    public void LoadData(TamaData data)
    {
        this.dateTimeTamaBorn = DateTime.Parse(data.timeTamaBorn);
        CalculateTicksFromBirth();
    }

    //Interface method
    public void SaveData(TamaData data)
    {
        data.timeTamaBorn = this.dateTimeTamaBorn.ToString();
    }
}
