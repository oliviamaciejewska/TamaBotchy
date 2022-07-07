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

    [SerializeField] private float _timeNow;
    [SerializeField] private float timeRecordInterval = 30.0f;
    [SerializeField] private float _lastTimeRecorded;

    public float LastTimeRecorded { get => _lastTimeRecorded; set => _lastTimeRecorded = value; }

    // Start is called before the first frame update
    void Start()
    {
        currentTime = DateTime.Now;
        startTime = currentTime;
        LastTimeRecorded = Time.realtimeSinceStartup;
    }

    public void LoadData(TamaData data)
    {
        this.LastTimeRecorded = data.lastTime;
    }

    public void SaveData(ref TamaData data)
    {
        data.lastTime = this.LastTimeRecorded;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();        
    }

    //Utilizing DateTime class during update for now (can't find a reason why I shouldn't especially for this scope.)
    private void UpdateTime()
    {
        _timeNow = Time.realtimeSinceStartup;
        if (_timeNow > LastTimeRecorded + timeRecordInterval)
        {
            LastTimeRecorded = _timeNow;
        }
        currentTime = DateTime.Now;
        //if (secondsToNextMinute > 0)
        //{
        //    secondsToNextMinute --;
        //}
        //else
        //{
        //    currentTime = currentTime.AddSeconds(Time.deltaTime);
        //}

        timeText.text = currentTime.ToString("HH:mm");
    }
}
