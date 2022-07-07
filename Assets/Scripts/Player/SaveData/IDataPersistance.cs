using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistance
{
    void LoadData(TamaData data);

    void SaveData(ref TamaData data);
}
