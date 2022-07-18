using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamaStateManager : MonoBehaviour, IDataPersistance
{

    public TamaBaseState currentState;
    public EggState eggState;
    public AdultState adultState;

    public string currentStateName;

    [SerializeField]
    private Sprite[] tamaSprites;
    private SpriteRenderer spriteRenderer;
    public TamaGenerator tamaGenerator;
    private TamaAge tamaAge;

    void Awake()
    {
        eggState = new EggState(this);
        adultState = new AdultState(this);
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        tamaGenerator = GetComponent<TamaGenerator>();
        tamaAge = GetComponent<TamaAge>();
        currentState = GetInitialState();

        currentState.Enter();
    }

    TamaBaseState GetInitialState()
    {
        if (tamaAge.currentAgeSeconds > 0 && tamaAge.currentAgeSeconds <= 500)
        {
            currentState = adultState;
        }
        else
        {
            currentState = eggState;
        }

        return currentState;
    }

    void Update()
    {
        if (currentState != null)
        {
            currentState.Update();
        }
    }

    public void ChangeState(TamaBaseState newState)
    {
        currentState.Exit();
        currentState = newState;
        newState.Enter();
    }

    public void ChangeSprite(int spriteNum)
    {
        spriteRenderer.sprite = tamaSprites[spriteNum];
    }

    //Interface method
    public void LoadData(TamaData data)
    {
        this.currentStateName = data.currentState;
    }

    //Interface method
    public void SaveData(TamaData data)
    {
        data.currentState = currentState.ToString();
    }

    private void OnGUI()
    {
        string content = currentState != null ? currentState.name : "(no current state";
        GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
    }

}
