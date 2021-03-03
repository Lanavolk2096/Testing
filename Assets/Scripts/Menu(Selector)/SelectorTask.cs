using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorTask : MonoBehaviour
{
    public Text NameTask;
    public Button BTNRef;
    public int Id;
    public event Action<int> OnSwitchScene;

    public void Setting(int id, string text)
    {
        Id = id;
        BTNRef.onClick.AddListener(EventToSwitch);
        NameTask.text = text;
    }
    void EventToSwitch()
    {
        OnSwitchScene(Id);
    }
    void Start()
    {
        
    }
}
