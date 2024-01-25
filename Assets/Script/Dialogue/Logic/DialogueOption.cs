using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueOption
{
    public string text;
    public string narrationText;
    public Sprite Image;
    public Vector3 ImagePos;
    public Sprite closeUp;
    public DialogueData_SO nextDialogue;
}
