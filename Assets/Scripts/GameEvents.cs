using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvents", menuName = "Quiz/GameEvents")]
public class GameEvents : ScriptableObject
{
    //stands for UpdateQuestionCallback, UpdateAnswerCallback, DisplayResultsScreenCallback, and ScoreUpdatedCallback respectively
    public delegate void UQC(Question question);
    public UQC UpdateQuestionUI;

    public delegate void UAC(AnswerData pickedAnswer);
    public UAC UpdateQuestionAnswer;
//I don't like this script, it's just setting stuff up, it's annoying
    public delegate void DRSC(UIManager.ResolutionScreenType type, int score);
    public DRSC DisplayResultsScreen;

    public delegate void SUC();
    public SUC ScoreUpdated;

    public int CurrentFinalScore;

}
