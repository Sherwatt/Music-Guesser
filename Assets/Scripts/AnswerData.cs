using TMPro;
using UnityEngine;

public class AnswerData : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] TextMeshProUGUI infoTextObject;

    [Header("References")]
    [SerializeField] GameEvents events;

    private RectTransform _rect;
    public RectTransform Rect
    {
        get
        {
            if (_rect == null)
            { //?? means that if something returns null, then we do what is after the characters
                _rect = GetComponent<RectTransform>() ?? gameObject.AddComponent<RectTransform>();
            }
            return _rect;
        }
    }

    private int _answerIndex = -1;
    public int AnswerIndex { get { return _answerIndex; } }

    public void UpdateData(string info, int index)
    {
        infoTextObject.text = info;
        _answerIndex = index;
    }
    public void SwitchState()
    {
        if (events.UpdateQuestionAnswer != null)
        {
            events.UpdateQuestionAnswer(this); //"this" refers to the pickedAnswer parameter in the same class, "this" always refers to something within the same class
        }
    }
}
