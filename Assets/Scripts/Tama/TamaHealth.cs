using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamaHealth : MonoBehaviour, IDataPersistance
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float _health;
    
    [SerializeField] private float _healthDegenRate = 5.0f; //Rate at which health degenerates in seconds TODO: balance rate

    [SerializeField] private TimeManager timeManager;

    public float Health { get => _health; set => _health = value; }

    // Start is called before the first frame update
    void Start()
    {
        _health = maxHealth;
        InvokeRepeating("MakeUnhealthy", 1.0f, _healthDegenRate);
    }

    void Update()
    {
        if (Health <= 0)
        {
            Die();
        }
    }

    private void MakeUnhealthy()
    {
        Health--;
    }

    public void Heal(float healAmount)
    {
        Health += healAmount; 
        Health = Mathf.Clamp(Health, 0, maxHealth);
    }

    private void Die()
    {
        CancelInvoke("MakeUnhealthy");
    }

    //Saving interface functions
    public void LoadData(TamaData data)
    {
        this.Health = data.health - ((int)(TimeManager.SecondsSinceLastLogin) * (_healthDegenRate));

        Health = Mathf.Clamp(Health, 0, maxHealth);
    }

    public void SaveData(TamaData data)
    {
        data.health = this.Health;
    }
}
