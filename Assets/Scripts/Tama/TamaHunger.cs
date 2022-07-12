using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamaHunger : MonoBehaviour, IDataPersistance
{
    [SerializeField] private float maxHunger = 100.0f;
    [SerializeField] private float _hunger;
    [SerializeField] private float _hungerDegenRate = 1.0f; //Rate at which hunger decreases in seconds TODO: balance rate
    [SerializeField] private float _healthDamageByHunger = 20.0f;

    [SerializeField] private TimeManager timeManager;

    private TamaHealth tamaHealth;

    public float Hunger { get => _hunger; set => _hunger = value; }


    // Start is called before the first frame update
    void Start()
    {
        Hunger = maxHunger;
        InvokeRepeating("MakeHungry", 1.0f, _hungerDegenRate);
        tamaHealth = GetComponent<TamaHealth>();
    }

    void Update()
    {
        if (Hunger == 0)
        {
            Die();
        }
    }

    //Invoke repeating hunger
    private void MakeHungry()
    {
        Hunger--;

        if (Hunger % 5 == 0)
        {
            DamageByHunger();
        }
    }

    //Does a bit of extra damage to tama's health
    private void DamageByHunger()
    {
        if (tamaHealth.Health >= 20)
        {
            tamaHealth.Health = tamaHealth.Health - _healthDamageByHunger;
        }
        else
        {
            tamaHealth.Health = 0;
        }
    }

    public void Feed(float amountFed)
    {
        Hunger = Hunger + amountFed;
        Hunger = Mathf.Clamp(Hunger, 0, maxHunger);
    }

    private void Die()
    {
        CancelInvoke("MakeHungry");
    }    
    
    //Saving interface functions
    public void LoadData(TamaData data)
    {
        this.Hunger = data.hunger - ((int)(TimeManager.SecondsSinceLastLogin) * (_hungerDegenRate));

        Hunger = Mathf.Clamp(Hunger, 0, maxHunger);
    }

    public void SaveData(TamaData data)
    {
        data.hunger = this.Hunger;
    }
}
