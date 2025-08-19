using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;


[System.Serializable]
public struct Answer
{
    [SerializeField] private string _info;
    public string Info { get { return _info; } }
    [SerializeField] private bool _isCorrect;
    public bool IsCorrect { get { return _isCorrect; }}
}
[CreateAssetMenu(fileName = "Questions", menuName = "Quiz/Questions")] //allows me to create new questions from the unity editor, just click "create" and then look for "quiz"
public class Question : ScriptableObject
{
    [SerializeField] private string _info = string.Empty; //the text of the question, I probably won't need this in the finished version
    public string Info { get { return _info; } }

    //[SerializeField] Image albumCover = null; //put an album cover here to be identified, we can copy this later to do audio files
    //public Image AlbumCover { get { return albumCover; } }

    [SerializeField] Answer[] _answers = null; //list of all potential answers for a given question
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
