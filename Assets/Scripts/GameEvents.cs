using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvents", menuName = "Quiz/GameEvents")]
public class GameEvents : ScriptableObject
{
    //stands for UpdateQuestionCallback: displays the new question
    public delegate void UQC(Question question);
    public UQC UpdateQuestionUI;

    //stands for UpdateAnswerCallback: updates the question's answer
    public delegate void UAC(AnswerData pickedAnswer);
    public UAC UpdateQuestionAnswer;

    //stands for DisplayResultsScreenCallback: Allows us to display the resolution screen that we want to show
    public delegate void DRSC(UIManager.ResolutionScreenType type, int score);
    public DRSC DisplayResultsScreen;

    //stands for ScoreUpdatedCallback: updates the score
    public delegate void SUC();
    public SUC ScoreUpdated;

    public int CurrentFinalScore;

}
