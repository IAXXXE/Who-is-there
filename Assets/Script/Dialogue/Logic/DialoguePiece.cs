using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialoguePiece
{
    public string ID;
    public Sprite Image;
    public string text;
    public bool hsaOption;
    public List<DialogueOption> opition = new List<DialogueOption>();
    public DialogueData_SO dialogueData;
}
