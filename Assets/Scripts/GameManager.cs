using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Question[] _questions = null;
    public Question[] Questions { get { return _questions; } }

    [SerializeField] GameEvents events = null;

    private List<AnswerData> PickedAnswers = new List<AnswerData>();
    private List<int> FinishedQuestions = new List<int>();
    private int currentQuestion = 0;
    //these next three are to update everything in between questions, but should they be in the UI Manager?
    public TMP_Text screenQuestion;
    public Image questionImage;
    public Button[] answerButtons;

    void Start()
    {
        LoadQuestions();
        foreach (var question in Questions)
        {
            Debug.Log(question.Info);
        }
        //Display(); this'll be activated later
    }

    public void EraseAnswers()
    {
        PickedAnswers = new List<AnswerData>();
    }

    void Display()
    {
        EraseAnswers();
        var question = GetRandomQuestion();

        if (events.UpdateQuestionUI != null)
        {
            events.UpdateQuestionUI(question);
        }
        else
        {
            Debug.LogWarning("Something went wrong when trying to display a new question");
        }
    }


    Question GetRandomQuestion() /*selects a random question from a list of questions
    I think this could probably be modified to load in audio files without too much hassle (fingers crossed)*/
    {
        var randomIndex = GetRandomQuestionIndex();
        currentQuestion = randomIndex;

        return Questions[currentQuestion];
    }
    int GetRandomQuestionIndex()
    {
        var random = 0;
        if (FinishedQuestions.Count < Questions.Length) //going to need to change this later to have a set number of rounds
        {
            do
            {
                random = Random.Range(0, Questions.Length);
            } while (FinishedQuestions.Contains(random) || random == currentQuestion);
        }
        return random;
    }

    void LoadQuestions()
    {
        Object[] objs = Resources.LoadAll("Questions", typeof(Question));
        _questions = new Question[objs.Length];
        for (int i = 0; i < objs.Length; i++)
        {
            _questions[i] = (Question)objs[i];
        }
        //questionImage.sprite = Question.questionImage; this is for when each question has its own image
    }

}
/*My idea for the selection of audio and alternate answers is like so: I have all the audio files in one attachment with their names, then in another document I have just a list of 
all the song names. The game randomly selects one of the audio files and puts its name into the hashset (removing the audio file in doing so), then the program selects random names 
from the other list until the hashset has 4 strings in it. The hashset is then converted into a list, which allows the program to assign random names to the buttons. Then find some 
way to check whether the selected name matches the file name to call the correct/incorrect function. We then need to find some way to reset the hashset every time they answer or if
time runs out. We also need to find a way to reset the audio file list every time the game is reloaded so that the list doesn't get continously smaller every time they play*/

/*I want to use a Hashset here since those don't allow for duplicate entries, but they don't allow for indexing either. Meanwhile,
the way to remove duplicates from a list involves running it over and over which is far too memory intensive. Perhaps I could make a middle ground where I first make a hashset and 
then I convert that into a list so I can have random choices with no duplicates. Here's a way to do this through code: List<string> stringList1 = stringSet.ToList();*/
