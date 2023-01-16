using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager Instance { get; private set; }

    public event Action onBallHitPaddle;
    public event Action onGameFailed;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void BallHitPaddle()
    {
        if (onBallHitPaddle != null)
        {
            onBallHitPaddle();
        }
    }

    public void GameFailed()
    {
        if (onGameFailed != null)
        {
            onGameFailed();
        }
    }
}
