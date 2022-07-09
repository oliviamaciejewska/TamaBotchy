using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistanceManager : MonoBehaviour
{
    [Header("File Storage Config")]

    [SerializeField] private string fileName;

    [SerializeField] private bool useEncryption;

    private TamaData tamaData;

    private List<IDataPersistance> dataPersistanceObjects;

    private FileDataHandler dataHandler;

    public static DataPersistanceManager instance { get; private set; }

    public TamaGenerator tamaGenerator;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one DPManager in scene");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
        this.dataPersistanceObjects = FindAllDataPersistanceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.tamaData = new TamaData();
    }

    public void LoadGame()
    {
        this.tamaData = dataHandler.Load();

        if(this.tamaData == null)
        {
            Debug.Log("No data was found. Making new game");
            NewGame();
        }

        foreach(IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.LoadData(tamaData);
        }
    }

    public void SaveGame()
    {
        foreach (IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.SaveData(tamaData);
        }

        dataHandler.Save(tamaData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>(true).OfType<IDataPersistance>();
        return new List<IDataPersistance>(dataPersistanceObjects);
    }
}
