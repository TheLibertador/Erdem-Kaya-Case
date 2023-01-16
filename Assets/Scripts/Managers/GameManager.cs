using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance { get; private set; }

   [HideInInspector] public int score = 0;
   public int level = 1;
   [SerializeField] private int nextLevelTreshouldScore = 20;
   
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

   private void Start()
   {
      EventsManager.Instance.onBallHitPaddle += IncreaseScore;
   }

   private void Update()
   {
      IncreaseLevel();
   }

   private void IncreaseScore()
   {
      score++;
   }

   private void IncreaseLevel()
   {
      if (score == nextLevelTreshouldScore)
      {
         level++;
         nextLevelTreshouldScore += 20;
      }
   }
}
