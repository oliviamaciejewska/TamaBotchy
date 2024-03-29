using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionButtons : MonoBehaviour
{
    [SerializeField] private GameObject thisTama;
    private TamaHunger tamaHunger;
    private TamaHealth tamaHealth;

    [SerializeField] private float feedAmount = 20;
    [SerializeField] private float healAmount = 20;


    void Start()
    {
        tamaHunger = thisTama.GetComponent<TamaHunger>();
        tamaHealth = thisTama.GetComponent<TamaHealth>();
    }

    public void Feed()
    {
        tamaHunger.Feed(feedAmount);
    }

    public void Heal()
    {
        tamaHealth.Heal(healAmount);
    }

}
