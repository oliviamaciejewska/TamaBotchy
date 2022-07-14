using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistanceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    [SerializeField] private bool useEncryption;

    [Header("Auto-save Config")]
    [SerializeField] private float autoSaveTimeSeconds = 60.0f;
    private Coroutine autoSaveCoroutine;

    private TamaData tamaData;

    private FileDataHandler dataHandler;

    public TamaGenerator tamaGenerator;

    [Header("Game Objects")]
    [SerializeField] private GameObject eggPrefab;
    [SerializeField] private GameObject tamaPrefab;

    private List<IDataPersistance> dataPersistanceObjects;

    public static DataPersistanceManager instance { get; private set; }

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
        GameObject egg = (GameObject)Instantiate(eggPrefab, new Vector3(0, 0, 0), Quaternion.identity);

    }

    public void LoadGame()
    {
        this.tamaData = dataHandler.Load();

        if(this.tamaData == null)
        {
            Debug.Log("No data was found. Making new game");
            NewGame();
        }
        else
        {
            GameObject tama = Instantiate(tamaPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            this.dataPersistanceObjects = FindAllDataPersistanceObjects();
            foreach (IDataPersistance dataPersistanceObj in dataPersistanceObjects)
            {
                dataPersistanceObj.LoadData(tamaData);
            }
        }

        if (autoSaveCoroutine != null)
        {
            StopCoroutine(autoSaveCoroutine);
        }
        autoSaveCoroutine = StartCoroutine(AutoSave());
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

    private IEnumerator AutoSave()
    {
        while (true)
        {
            //TODO: find a better way to make this save system work after instantiating my tama at runtime. Don't really wanna be doing this in a coroutine...
            this.dataPersistanceObjects = FindAllDataPersistanceObjects();
            yield return new WaitForSeconds(autoSaveTimeSeconds);
            SaveGame();
            Debug.Log("Auto Saved");
        }
    }
    private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
        return new List<IDataPersistance>(dataPersistanceObjects);
    }
}
