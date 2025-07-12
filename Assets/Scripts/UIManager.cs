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
   [SerializeField] RectTransform imageContentArea; //for use when playing the album cover guessing game
   public RectTransform ImageContentArea { get { return imageContentArea; } }

   [SerializeField] RectTransform answersContentArea; //hopefully I'll be able to get all 4 buttons to change through this code, otherwise I'll have to run it 4 different times
   public RectTransform AnswersContentArea { get { return answersContentArea; } }

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
      CreateAnswers(question);
   }

   void CreateAnswers(Question question) {
      EraseAnswers();

      float offset = 0 - parameters.Margins;
      //I think maybe I should just delete this confusing shit and try to find a way to do this myself
      /*for (int i = 0; i < question.Answers.Length; i++)
      {
         AnswerData newAnswer = (AnswerData)Instantiate(answerPrefab, uIElements.AnswersContentArea); //want to rewrite this later, also I have no idea what it actually does
         newAnswer.UpdateData(question.Answers[i].Info, i);

         newAnswer.Rect.anchoredPosition = new Vector2(0, offset)
      }
      */
   }

   void EraseAnswers() {
      foreach (var answer in currentAnswers)
      {
         Destroy(answer.gameObject);
      }
   }
}
