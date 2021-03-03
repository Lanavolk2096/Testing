using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class CorrectAnswer
{
    public string correctAnswerText;
}

[System.Serializable]
public class Answers 
{
    public string answerText;
}

[System.Serializable]
public class Quest 
{
    public float TimeToEnd = 0.0f;
    public string QuestText;
    public bool isAnswered;
    public bool isCorrectAnswer;
    public List<Answers> answers;
    public List<CorrectAnswer> correctAnswer;
    public Quest()
    {
        answers = new List<Answers>(); //Вызов инициализации при создании объекта
        correctAnswer = new List<CorrectAnswer>();
    }
}


[System.Serializable]
public class _Task 
{
    public string NameOfTask;
    public List<Quest> Questions = new List<Quest>();    //Вызов инициализации при компилировании
}


[System.Serializable]
public class TestData 
{
    public List<_Task> testData;//Массив тем(задач)
    public TestData()//конструктор
    {
        testData = new List<_Task>(); //инициализация массива (выделение памяти в оперативной памяти для массива)
    }
}

[System.Serializable]
public class DataWorker : MonoBehaviour
{
    public TestData Data = new TestData(); //Создаем и записываем объект
    public int currentNumberAnswers = 0;
    public int currentNumberTask = 0;
    public void setup(TextAsset JSONFile, int CNA, int CNT)//CNA - currentNumberAnswers; CNT - currentNumberTask;
    {
        Data = parse(JSONFile);
        currentNumberAnswers = CNA;
        currentNumberTask = CNT;
    }

    public static TestData parse(TextAsset JSONFile = null)
    {
        if (JSONFile != null)
            return JsonUtility.FromJson<TestData>(JSONFile.text);//парсим джисон файл
        return null;
    }
    void setCurrentQuest(int currentQuest)
    {
        int currentNumberTask = currentQuest;

    }
    public void setNumberTask(int value)
    {
        currentNumberTask = value;
    }
    public string getQuestText()
    {
        return Data.testData[currentNumberTask].Questions[currentNumberAnswers].QuestText;
    }
    public List<Answers> getNextAnswers(int value)
    {
        currentNumberAnswers = value;
        if (Data.testData[currentNumberTask].Questions.Count > currentNumberAnswers)
            return Data.testData[currentNumberTask].Questions[currentNumberAnswers].answers;
        else
            return null;
    }
    public bool isCorrect(string answer)
    {
        return answer == Data.testData[currentNumberTask].Questions[currentNumberAnswers].correctAnswer[0].correctAnswerText;
    }
    public bool isCorrect(List<string> answer)
    {
        return true;
    }
}




