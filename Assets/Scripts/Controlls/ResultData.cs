using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultData : MonoBehaviour
{
    GlobalData Data;
    public Text TextRef;
    void Start()
    {
        Data = GameObject.Find("GlobalData").GetComponent<GlobalData>();        
        if (Data != null)
        {
            int count = 0;
            int allAnswers = Data.Data.Data.testData[Data.Data.currentNumberTask].Questions.Count;
            for (int i = 0; i < Data.Data.Data.testData[Data.Data.currentNumberTask].Questions.Count; i++)
                if (Data.Data.Data.testData[Data.Data.currentNumberTask].Questions[i].isCorrectAnswer)
                    count++;
            TextRef.text = "Правильных - " + count.ToString() + "/" + allAnswers.ToString();
        }

    }
}
