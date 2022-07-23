using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[Serializable]
public class TimeManager: MonoBehaviour, IDataPersistance
{
    public TextMeshProUGUI timeText;
    //Current local system time for display
    private DateTime currentTime;

    //Records the time on saving, which will return the last time we have recorded for comparison to next time we log on
    [SerializeField] private DateTime lastTimeRecorded;
    [SerializeField] private DateTime timeNow;

    [SerializeField] private static double secondsSinceLastLogin;

    public DateTime LastTimeRecorded { get => lastTimeRecorded; set => lastTimeRecorded = value; }
    public static double SecondsSinceLastLogin { get => secondsSinceLastLogin; set => secondsSinceLastLogin = value; }

    public static TimeManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one DPManager in scene");
        }
        instance = this;
    }

    void Start()
    {
        currentTime = DateTime.Now;
    }

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

    public static DateTime GetCurrentTime()
    {
        return DateTime.UtcNow;
    }

    public void GetSecondsSinceLastLogin()
    {
        secondsSinceLastLogin = timeNow.Subtract(LastTimeRecorded).TotalSeconds;
    }


    public void LoadData(TamaData data)
    {
        timeNow = GetCurrentTime();

        if (data.lastTime == "")
        {
            this.LastTimeRecorded = timeNow;
        }

        else
        {
            this.LastTimeRecorded = DateTime.Parse(data.lastTime);

            GetSecondsSinceLastLogin();
        }
    }

    public void SaveData(TamaData data)
    {
        data.lastTime = DateTime.UtcNow.ToString();
    }

}
