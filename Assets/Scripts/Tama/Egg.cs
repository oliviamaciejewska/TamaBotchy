using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public GameObject tamaPrefab;
    //public GameObject goTamaGenerator;
    public TamaGenerator tamaGenerator;
    // Start is called before the first frame update
    void Start()
    {
        tamaGenerator = GetComponentInParent<TamaGenerator>();
        StartCoroutine("Hatch");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Hatch()
    {
        yield return new WaitForSecondsRealtime(5);
        Destroy(this.gameObject);
        GameObject tama = Instantiate(tamaPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        tamaGenerator.MakeTama(tama);

    }
}
