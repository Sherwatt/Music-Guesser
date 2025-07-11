using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*My idea for the selection of audio and alternate answers is like so: I have all the audio files in one attachment with their names, then in another document I have just a list of 
all the song names. The game randomly selects one of the audio files and puts its name into the hashset (removing the audio file in doing so), then the program selects random names 
from the other list until the hashset has 4 strings in it. The hashset is then converted into a list, which allows the program to assign random names to the buttons. Then find some 
way to check whether the selected name matches the file name to call the correct/incorrect function. We then need to find some way to reset the hashset every time they answer or if
time runs out. We also need to find a way to reset the audio file list every time the game is reloaded so that the list doesn't get continously smaller every time they play*/

public class QandADisplay : MonoBehaviour
{
    public TMP_Text screenQuestion;
    public TMP_Text option0;
    public TMP_Text option1;
    public TMP_Text option2;
    public TMP_Text option3;


    int randomIndex;
    public List<string> answers = new List<string>(); /*I want to use a Hashset here since those don't allow for duplicate entries, but they don't allow for indexing either. Meanwhile,
    the way to remove duplicates from a list involves running it over and over which is far too memory intensive. Perhaps I could make a middle ground where I first make a hashset and 
    then I convert that into a list so I can have random choices with no duplicates. Here's a way to do this through code: List<string> stringList1 = stringSet.ToList();*/

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        answers.Add(new string("CD"));
        answers.Add(new string("Cassette Tape"));
        answers.Add(new string("Vinyl LP"));
        answers.Add(new string("Spinny Thing"));
        answers.Add(new string("Some other answer"));

        randomIndex = UnityEngine.Random.Range(0, answers.Count);

        screenQuestion.text = "What is this?";
        option0.text = PickRandomAnswer(randomIndex);
        option1.text = PickRandomAnswer(randomIndex);
        option2.text = PickRandomAnswer(randomIndex);
        option3.text = PickRandomAnswer(randomIndex);

    }

    //Update is called once per frame
    void Update()
    {

    }

    /* A function that can take a random element from a list and assign it to one of the button slots
    NOTE: not sure if this sort of thing works on a larger scale, I'll have to review it later*/
    string PickRandomAnswer(int index)
    {
        string randomAnswer = answers[index];
        answers.RemoveAt(index);
        return randomAnswer;
    }
}
