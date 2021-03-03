using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DataInTest : MonoBehaviour
{
    public Canvas CanvasRef;
    public Button BTNNextRef;
    public Text QuestTextRef;
    public Text TimerTextRef;
    public TextAsset JSONFile;//ссылка на джисон файл
    GlobalData DataRef;
    public bool isInstalledDraged;
    public List<bool> corrects = new List<bool>(); // Массив правильного или неправильного ответа в вопросах
    public GameObject ObjectToSpawn;
    public int currentTask;
    public bool CanGoNextQuest = false;
    public int currentSelectedAnswer = -1;
    public int currentInstalledAnswer = -2;
    string QuestText;
    List<Answers> CurrentListAnswers = new List<Answers>();
    List<GameObject> BTNRef = new List<GameObject>();
    Vector3 DefaultPosition = new Vector3(-120, 50, 0);
    void OnDragDetected(int value) //Вызывается при начале переноса любой кнопки
    {
        if (!(currentInstalledAnswer < 0)) //Есть установленная кнопка? Если да, то выключаем РЕЙКАСТ установленной
                BTNRef[currentInstalledAnswer].GetComponent<CustomBTN>().DisableBTN();
    }
    void OnDropDetected(int value) //Вызывается при сбросе любой кнопки
    {
        if (isInstalledDraged) //Перетаскиваем установленную кнопку?
            ReinstalBTNs(true);
        else if (currentInstalledAnswer > -1) //Если нет и есть ли установленная кнопка?
            BTNRef[currentInstalledAnswer].GetComponent<CustomBTN>().EnableBTN(); //Если да, то включаем РЕЙКАСТ установленной
    }
    Vector3 getPosition(int NumberPos)
    {
        int flip = 0;
        Vector3 Return = DefaultPosition;
        for (int i = 0; i <= NumberPos; i++)
        {
            switch (flip)
            {
                case 0:
                    {
                        Return.x = DefaultPosition.x; //Слева
                        break;
                    }
                case 1:
                    {
                        Return.x += 240; //Справа
                        break;
                    }
                case 2:
                    {
                        Return.x = DefaultPosition.x; //Слева
                        Return.y -= 50; //Опускаемся ниже
                        break;
                    }
                case 3:
                    {
                        Return.x += 240; //Справа
                        break;
                    }
                default:
                    {
                        Return.x = DefaultPosition.x; //Слева
                        flip = 0;
                        break;
                    }
            }
            flip++;
        }
        return Return;
    }


    public void EventDrop()
    {
        Debug.Log("Drop");
        if (currentSelectedAnswer > -1 && currentSelectedAnswer != currentInstalledAnswer)
        {
            currentInstalledAnswer = currentSelectedAnswer;
            CanGoNextQuest = true;
            QuestTextRef.text = QuestText + " " + CurrentListAnswers[currentSelectedAnswer].answerText;
            ReinstalBTNs();
            BTNNextRef.interactable = true;
        }
    }
    public void ReinstalBTNs(bool isFull = false)
    {
        for (int i = 0; i < BTNRef.Count; i++)
        {
            if (i != currentInstalledAnswer || isFull )
            {
                BTNRef[i].GetComponent<CustomBTN>().EnableBTN();
                BTNRef[i].transform.localPosition = getPosition(i);
            }
        }
        if (isFull)
        {
            currentInstalledAnswer = -2;
            QuestTextRef.text = QuestText;
            CanGoNextQuest = false;
            BTNNextRef.interactable = false;
        }
    }
    public void press()
    {
        if (CanGoNextQuest)
        {
            if (currentSelectedAnswer > -1)
            {
                DataRef.Data.Data.testData[DataRef.Data.currentNumberTask].Questions[DataRef.Data.currentNumberAnswers].isAnswered = true;
                bool L_isCorrect = DataRef.Data.isCorrect(BTNRef[currentSelectedAnswer].GetComponent<CustomBTN>().TextRef.text);
                DataRef.Data.Data.testData[DataRef.Data.currentNumberTask].Questions[DataRef.Data.currentNumberAnswers].isCorrectAnswer = L_isCorrect;

                DataRef.Data.currentNumberAnswers++;
                NextAnswer();
            }
        }
    }

    private void Start()
    {
        DataRef = GameObject.Find("GlobalData").GetComponent<GlobalData>();


        DataRef.Data.currentNumberAnswers = 0;
        //Создание кнопок на сцене
        for (int i = 0; i < DataRef.Data.getNextAnswers(DataRef.Data.currentNumberAnswers).Count; i++)
        {
            GameObject L_Spawned;
            L_Spawned = Instantiate(ObjectToSpawn, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0)) as GameObject;
            L_Spawned.GetComponent<CustomBTN>().Setting(i, "", this);
            L_Spawned.GetComponent<CustomBTN>().OnDragDetected += OnDragDetected;
            L_Spawned.GetComponent<CustomBTN>().OnDropDetected += OnDropDetected;
            L_Spawned.transform.SetParent(CanvasRef.transform);
            
            BTNRef.Add(L_Spawned);
        }
        
        //TimerTextRef.text = "Время: " + System.TimeSpan.FromSeconds(30).ToString();

        NextAnswer();
    }

    private void NextAnswer()
    {
        CurrentListAnswers = DataRef.Data.getNextAnswers(DataRef.Data.currentNumberAnswers);
        CanGoNextQuest = false;
        currentSelectedAnswer = -1;
        currentInstalledAnswer = -2;
        if (CurrentListAnswers != null)
        {
            for (int i = 0; i < CurrentListAnswers.Count; i++)
            {
                Debug.Log(CurrentListAnswers[i].answerText);
                BTNRef[i].GetComponent<CustomBTN>().UpdateText(CurrentListAnswers[i].answerText);
                BTNRef[i].transform.localPosition = getPosition(i);
            }
            QuestText = DataRef.Data.getQuestText();
            ReinstalBTNs(true);
            QuestTextRef.text = QuestText;
        }
        else
        {
            
            SceneManager.LoadScene(2);
        }
    }
}
