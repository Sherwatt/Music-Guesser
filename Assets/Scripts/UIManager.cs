using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using System.Collections.Generic;

[Serializable()]
public struct UIManagerParameters
{
   [Header("Answers Options")]
   [SerializeField] float margins;
   public float Margins { get { return margins; } }
}
[Serializable()]
public struct UIElements
{
   [SerializeField] RectTransform imageContentArea; //for being used when playing the album cover guessing game
   public RectTransform ImageContentArea { get { return imageContentArea; } }

   [SerializeField] TextMeshProUGUI scoreText; //will be used to update the score
   public TextMeshProUGUI ScoreText { get { return scoreText; } }

   [Space]
   [SerializeField] Image resultsBackground; //Will be used to change the background depending on whether the answer was wrong or right, or if the game is done
   public Image ResultsBackground { get { return resultsBackground; } }

   [SerializeField] TextMeshProUGUI statusText; //Tells us if the answer was right or wrong, or that the game is over
   public TextMeshProUGUI StatusText { get { return statusText; } }

   [SerializeField] TextMeshProUGUI resultScoreText; //how many points the player got for that answer
   public TextMeshProUGUI ResultScoreText { get { return resultScoreText; } }

   [Space]
   //the following only get called at the end of the game
   [SerializeField] TextMeshProUGUI highScoreText;
   public TextMeshProUGUI HighScoreText { get { return highScoreText; } }

   [SerializeField] CanvasGroup mainCanvasGroup; //this will be used to deactivate everything on the main page of the quiz
   public CanvasGroup MainCanvasGroup { get { return mainCanvasGroup; } }

   [SerializeField] RectTransform endGameUIElements; //call when we want to show the highscore and replay/main menu buttons
   public RectTransform EndGameUIElements { get { return endGameUIElements; } }
}
public class UIManager : MonoBehaviour
{
   public enum ResolutionScreenType { correct, incorrect, finished }

   [Header("References")]
   [SerializeField] GameEvents events;

   [Header("UI Elements (Prefabs)")]
   [SerializeField] AnswerData answerPrefab;

   [SerializeField] UIElements uIElements;

   [Space]
   [SerializeField] UIManagerParameters parameters;

   List<AnswerData> currentAnswers = new List<AnswerData>(); //allows us to display new answers each round

   void OnEnable()
   {

   }

   void OnDisable()
   {

   }

   void UpdateQuestionUI(Question question)
   {
      uIElements.
   }

   void CreateAnswers(Question question) {
      EraseAnswers();

      float offset = 0 - parameters.Margins;
      for (int i = 0; i < question.Answers.Length; i++)
      {
         AnswerData newAnswer = (AnswerData)Instantiate(answerPrefab, uIElements.); //this doesn't really work for the setup I have
      }
   }

   void EraseAnswers() {
      foreach (var answer in currentAnswers)
      {
         Destroy(answer.gameObject);
      }
   }
}
