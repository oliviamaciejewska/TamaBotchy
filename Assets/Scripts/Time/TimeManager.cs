using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[Serializable]
public class TimeManager: MonoBehaviour, IDataPersistance
{
    public TextMeshProUGUI timeText;
    private DateTime currentTime;
    private DateTime startTime;

    //Records the time on saving, which will return the last time we have recorded for comparison to next time we log on
    [SerializeField] private DateTime _lastTimeRecorded;

    //Records the time in ticks/10000000 when we log on, allowing us to compare the time between now and when we last saved
    [SerializeField] private DateTime timeNow;

    [SerializeField] private static double secondsSinceLastLogin;

    public DateTime LastTimeRecorded { get => _lastTimeRecorded; set => _lastTimeRecorded = value; }
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

    public static DateTime GetCurrentTickSeconds()
    {
        return DateTime.UtcNow;
    }

    public void GetTimeSinceLastLogin()
    {
        secondsSinceLastLogin = timeNow.Subtract(LastTimeRecorded).TotalSeconds;
    }


    public void LoadData(TamaData data)
    {
        this.LastTimeRecorded = DateTime.Parse(data.lastTime);

        timeNow = GetCurrentTickSeconds();

        GetTimeSinceLastLogin();
    }

    public void SaveData(TamaData data)
    {
        data.lastTime = DateTime.UtcNow.ToString();
    }

}
