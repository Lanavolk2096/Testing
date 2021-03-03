using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*struct TestInfo
{
    string Name;
    List<bool> answers;
}
class SchoolСlass
{
    int number = -1;
    string prefix = "";
}
struct User
{
    bool isAdministration;
    string Name;

}*/
public enum E_Scenes
{
    E_Registration,
    E_Selector,
    E_Test,
    E_Result,
    E_NonSelected
}
public class GlobalData : MonoBehaviour
{
    public DataWorker Data;
    public TextAsset JSONFile;//ссылка на джисон файл 
    //List<TestInfo> AllList;

    protected void Start()
    {
        DontDestroyOnLoad(this); //Не удалять объект при смене сцены
        Data = gameObject.AddComponent(typeof(DataWorker)) as DataWorker;
        Data.setup(JSONFile, 0, 0);
    }
    public void SwitchScene(int number)
    {
        SceneManager.LoadScene(number);
    }
    public void SwitchScene(int number, E_Scenes nextScene = E_Scenes.E_NonSelected)
    {
    
        switch(nextScene)
        {
            case E_Scenes.E_Registration:
                {
                    SceneManager.LoadScene(1);
                    break;
                }
            case E_Scenes.E_Selector:
                {
                    SceneManager.LoadScene(0);
                    break;
                }
            case E_Scenes.E_Test:
                {
                    Data.setNumberTask(number);
                    SceneManager.LoadScene(3);
                    break;
                }
            case E_Scenes.E_Result:
                {
                    SceneManager.LoadScene(2);
                    break;
                }
            case E_Scenes.E_NonSelected:
                {
                    SceneManager.LoadScene(number);
                    break;
                }
            default:
                {
                    break;
                }
        }
        
    }
   
}
