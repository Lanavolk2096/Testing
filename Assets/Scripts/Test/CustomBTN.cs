using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomBTN : MonoBehaviour, IEndDragHandler, IDragHandler, IBeginDragHandler
{
    public Text TextRef;
    public int id;
    public int TextFontSize = 25;
    DataInTest Data;
    RectTransform Transform;
    public event Action<int> OnDragDetected;
    public event Action<int> OnDropDetected;
    private CanvasGroup canvasGroup;
    CustomBTN()
    {
        if (TextRef != null)
            TextRef.fontSize = TextFontSize;
    }
    public void Awake()
    {
        Transform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Data.currentSelectedAnswer = id;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Transform.anchoredPosition += eventData.delta;
        canvasGroup.blocksRaycasts = false;
        OnDragDetected(id);
        Data.isInstalledDraged = Data.currentInstalledAnswer == id;
        
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        OnDropDetected(id);
        canvasGroup.blocksRaycasts = true;
        Data.ReinstalBTNs();
    }
    public void DisableBTN()
    {
        canvasGroup.blocksRaycasts = false;
    }
    public void EnableBTN()
    {
        canvasGroup.blocksRaycasts = true;
    }
    public void UpdateText(string Text)
    {
        TextRef.text = Text;
    }
    public void Setting(int Value, string Text, DataInTest data, int _TextFontSize = -1)
    {
        id = Value;
        TextRef.text = Text;
        if(_TextFontSize < 0)
            TextRef.fontSize = TextFontSize;
        Data = data;
    }

    
}
