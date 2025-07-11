using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Collections;
using System.Threading;

public class Timer : MonoBehaviour
{
    [Header("Timer Length")]
    [SerializeField] public int timerLength;
    [HideInInspector] public bool OutofTime = false;

    [Header("Timer Visuals")]
    [SerializeField] private Image VinylRecord = null;

    //these two values will allow us to alter the fill amount of the timer image without confusion
    //int timerInt;
    float timerFloat;

    IEnumerator coroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //timerInt = timerLength;
        timerFloat = (float)timerLength;

        coroutine = Countdown();
        StartCountdown();
    }
    public void StartCountdown()
    {
        StartCoroutine(coroutine);
    }

    public void StopCountdown()
    {
        StopCoroutine(coroutine);
    }

    IEnumerator Countdown()
    {
        while (timerFloat > 0)
        {
            timerFloat -= Time.deltaTime;
            VinylRecord.fillAmount = timerFloat / timerLength;
            yield return null;
        }
        StopCountdown();
    }
}
