using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorManager : MonoBehaviour
{
    GlobalData DataRef = null;
    public GameObject ContentRef = null;
    public GameObject ObjectToSpawn;
    Vector3 DefPos = new Vector3(0, 80, 0);
    void Start()
    {
        DataRef = GameObject.Find("GlobalData").GetComponent<GlobalData>();
        if (DataRef.Data != null)
            for (int i = 0; i < DataRef.Data.Data.testData.Count; i++)
            {
                GameObject L_Spawned;
                L_Spawned = Instantiate(ObjectToSpawn, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0)) as GameObject;
                L_Spawned.GetComponent<SelectorTask>().Setting(i, DataRef.Data.Data.testData[i].NameOfTask);
                L_Spawned.GetComponent<SelectorTask>().OnSwitchScene += EventToSwitch;
                L_Spawned.transform.SetParent(ContentRef.transform);
                L_Spawned.transform.localPosition = new Vector3(0, -80 - (100 * i), 0);
            }

    }
    void EventToSwitch(int id)
    {
        DataRef.SwitchScene(id, E_Scenes.E_Test);
    }
}
