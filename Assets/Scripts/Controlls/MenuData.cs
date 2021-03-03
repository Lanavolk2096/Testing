using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
public class MenuData : MonoBehaviour
{
    public InputField IFRef;
    public InputField IFRef_Class;
    public Text Text;
    string LastInClass = "";
    public void _Input(string input)
    {
        string a = IFRef.text;
        string result = "";
        List<char> temp = a.ToList();

        for (int i = 0; i < temp.Count; i++)
        {
            string temp1 = temp[i].ToString();
            Regex regex = new Regex("[А-яЁё]", RegexOptions.IgnoreCase);
            Match match = regex.Match(temp1);
            result += match.Value;
        }
        IFRef.text = result;
    }
    public void End_Input(string input)
    {
        string a = IFRef.text;
        string result = "";
        List<char> temp = a.ToList();
        for (int i = 0; i < temp.Count; i++)
        {
            string temp1 = temp[i].ToString();
            Regex regex = new Regex(".*[А-яЁё].*", RegexOptions.IgnoreCase);
            Match match = regex.Match(temp1);
            result += match.Value;
        }
        IFRef.text = result;
    }
    public void Class_Input(string input)
    { 
        string a = IFRef_Class.text;
        string result = "";
        if (a.Length == 1)
        {
            string temp1 = a;
            Regex regex = new Regex("[0-9]", RegexOptions.IgnoreCase);
            Match match = regex.Match(temp1);
            result += match.Value;
        }
        else
        {
            if (a.Length == 2)
            {
                
                string temp1 = a;
                Regex regex = new Regex("([0-9][0-9])", RegexOptions.IgnoreCase);
                Match match = regex.Match(temp1);
                if (match.Value.Length == 2)
                {
                    int res;
                    int.TryParse(match.Value, out res);
                    if (res < 12)
                    {                        
                        result = res.ToString();
                    }
                    else
                    {
                        res = 11;
                        result = res.ToString();
                    }
                }
                else
                {
                    regex = new Regex("([0-9][А-яЁё])", RegexOptions.IgnoreCase);
                    match = regex.Match(temp1);
                    result = match.Value;
                }
            }
            if (a.Length == 3)
            {
                string temp1 = a;
                Regex regex = new Regex("[0-9][0-9][А-яЁё]", RegexOptions.IgnoreCase);
                Match match = regex.Match(temp1);
                result += match.Value;

            }
        }
        if (result == "" && a != "")
            result = LastInClass;
        else
        {
            LastInClass = result;
        }
        IFRef_Class.text = result;
    }
    public void Class_End_Input(string input)
    {
        string a = IFRef_Class.text;
        string result = "";
        if (a.Length == 1)
        {
            string temp1 = a;
            Regex regex = new Regex("[0-9]", RegexOptions.IgnoreCase);
            Match match = regex.Match(temp1);
            result += match.Value;
        }
        else
        {
            if (a.Length == 2)
            {

                string temp1 = a;
                Regex regex = new Regex("([0-9][0-9])", RegexOptions.IgnoreCase);
                Match match = regex.Match(temp1);
                if (match.Value.Length == 2)
                {
                    int res;
                    int.TryParse(match.Value, out res);
                    if (res < 12)
                    {
                        result = res.ToString();
                    }
                    else
                    {
                        res = 11;
                        result = res.ToString();
                    }
                }
                else
                {
                    regex = new Regex("([0-9][А-яЁё])", RegexOptions.IgnoreCase);
                    match = regex.Match(temp1);
                    result = match.Value;
                }
            }
            if (a.Length == 3)
            {
                string temp1 = a;
                Regex regex = new Regex("[0-9][0-9][А-яЁё]", RegexOptions.IgnoreCase);
                Match match = regex.Match(temp1);
                result += match.Value;

            }
        }
        if (result == "" && a != "")
            result = LastInClass;
        else
        {
            LastInClass = result;
        }
        IFRef_Class.text = result;
    }
}
