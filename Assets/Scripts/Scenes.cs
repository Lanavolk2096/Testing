﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void StartLoadScene(int _sceneNumber)
    {
        SceneManager.LoadScene(_sceneNumber);
    }
}