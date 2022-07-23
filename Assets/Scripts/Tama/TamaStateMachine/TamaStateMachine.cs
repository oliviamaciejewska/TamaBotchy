using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TamaStateMachine : MonoBehaviour, IDataPersistance
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
    public Rigidbody2D rb;
    public Animator animator;
    public ParticleSystem eggHatch;

    public GameObject nameTamaMenu;
    public GameObject inputField;
    public GameObject textDisplay;
    public bool isNamed;
    public string tamaName;

    public int tamaSpriteIndex;

    void Awake()
    {
        eggState = new EggState(this);
        adultState = new AdultState(this);
    }

    void Start()
    {
        GetComponenets();
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

    void LateUpdate()
    {
        if (currentState != null)
        {
            currentState.UpdatePhysics();
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

    public void EggHatched()
    {
        nameTamaMenu.SetActive(true);
        StartCoroutine("NameTama");
    }

    private IEnumerator NameTama()
    {

        yield return SubmitName();
    }

    private IEnumerator SubmitName()
    {
        while(!isNamed)
        {
            tamaName = inputField.GetComponent<TMP_InputField>().text;
            //textDisplay.GetComponent<TMP_InputField>().text = tamaName;
            yield return null;
        }
        this.ChangeState(this.adultState);
    }

    public void SubmitNameButton()
    {
        tamaAge.tamaName = tamaName;
        tamaGenerator.MakeTama();
        Destroy(nameTamaMenu);
        isNamed = true;
    }

    //Function to call for my own neatness sanity
    void GetComponenets()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        tamaGenerator = GetComponent<TamaGenerator>();
        tamaAge = GetComponent<TamaAge>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        eggHatch = GetComponentInChildren<ParticleSystem>();
    }

    //Interface method for save system
    public void LoadData(TamaData data)
    {
        this.currentStateName = data.currentState;
        this.tamaSpriteIndex = data.tamaSprite;
    }

    //Interface method for save system
    public void SaveData(TamaData data)
    {
        data.currentState = currentState.ToString();
        data.tamaSprite = this.tamaSpriteIndex;
    }

    //private void OnGUI()
    //{
    //    string content = currentState != null ? currentState.name : "(no current state";
    //    //GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
    //}

}
