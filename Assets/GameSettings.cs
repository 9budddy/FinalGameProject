using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private int fps = 60;

    void Start()
    {
        Application.targetFrameRate = fps;
    }
}
