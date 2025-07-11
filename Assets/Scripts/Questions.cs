using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Answer
{
    [SerializeField] private string _info;
    public string Info { get { return _info; } }
    [SerializeField] private bool _isCorrect;
    public bool IsCorrect { get { return _isCorrect; }}
}
[CreateAssetMenu(fileName = "Questions", menuName = "Quiz/Questions")]
public class Question : ScriptableObject
{
    [SerializeField] private string _info = string.Empty;
    public string Info { get { return _info; } }

    [SerializeField] Answer[] _answers = null;
    public Answer[] Answers { get { return _answers; } }

    //This is not how I wanted to set up these questions, but I think I need to make sure the whole points/timer/buttons system is working before I attempt to have a completely random quiz
    public List<int> GetCorrectAnswers()
    {
        List<int> CorrectAnswers = new List<int>();
        for (int i = 0; i < Answers.Length; i++)
        {
            if (Answers[i].IsCorrect)
            {
                CorrectAnswers.Add(i);
            }
        }
        return CorrectAnswers;
    }
}
