using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamaHunger : MonoBehaviour, IDataPersistance
{
    [SerializeField] private float maxHunger = 100.0f;
    [SerializeField] private float _hunger;
    [SerializeField] private float _hungerRate = 1.0f;

    public float Hunger { get => _hunger; set => _hunger = value; }

    TamaHealth tamaHealth;

    // Start is called before the first frame update
    void Start()
    {
        Hunger = maxHunger;
        InvokeRepeating("MakeHungry", 1.0f, _hungerRate);
        tamaHealth = GetComponent<TamaHealth>();
    }

    public void LoadData(TamaData data)
    {
        this.Hunger = data.hunger;
    }

    public void SaveData(ref TamaData data)
    {
        data.hunger = this.Hunger;
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

    void Update()
    {
        if (Hunger == 0)
        {
            Die();
        }
    }

    //Does a bit of extra damage to tama's health
    private void DamageByHunger()
    {
        if (tamaHealth.Health >= 20)
        {
            tamaHealth.Health = tamaHealth.Health - 20;
        }
        else
        {
            tamaHealth.Health = 0;
        }
    }

    private void Die()
    {
        CancelInvoke("MakeHungry");
    }
}
