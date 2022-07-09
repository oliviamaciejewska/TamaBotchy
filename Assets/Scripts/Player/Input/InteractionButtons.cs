using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionButtons : MonoBehaviour
{
    [SerializeField] private TamaHunger tamaHunger;

    void Start()
    {
    }

    public void Feed()
    {
        tamaHunger.FillVoid(20.0f);
    }

}
