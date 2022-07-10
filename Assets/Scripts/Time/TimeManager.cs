using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager: MonoBehaviour, IDataPersistance
{
    public TextMeshProUGUI timeText;
    private DateTime currentTime;
    private DateTime startTime;

    //Records the time on saving, which will return the last time we have recorded for comparison to next time we log on
    [SerializeField] private int _lastTimeRecorded;

    //Records the time in ticks/10000000 when we log on, allowing us to compare the time between now and when we last saved
    [SerializeField] private int tickSecondsAtLogin;

    [SerializeField] private int secondsSinceLastLogin;

    public int LastTimeRecorded { get => _lastTimeRecorded; set => _lastTimeRecorded = value; }

    // Start is called before the first frame update
    void Start()
    {
        currentTime = DateTime.Now;
        startTime = currentTime;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();        
    }

    private void UpdateTime()
    {
        //Utilizing DateTime class during update for now (can't find a reason why I shouldn't especially for this scope.)
        currentTime = DateTime.Now;

        timeText.text = currentTime.ToString("HH:mm");
    }

    public static int GetCurrentTickSeconds()
    {
        int currentTickSeconds = ((int)DateTime.Now.Ticks)/10000000;

        return currentTickSeconds;
    }

    public void GetTimeSinceLastLogin()
    {
        secondsSinceLastLogin = (tickSecondsAtLogin - _lastTimeRecorded);
    }


    public void LoadData(TamaData data)
    {
        this.LastTimeRecorded = data.lastTime;

        tickSecondsAtLogin = GetCurrentTickSeconds();

        GetTimeSinceLastLogin();
    }

    public void SaveData(TamaData data)
    {
        data.lastTime = GetCurrentTickSeconds();
    }

}
