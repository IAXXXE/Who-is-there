using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData_SO", menuName = "Dialogue/Dialogue Data")]
public class DialogueData_SO : ScriptableObject 
{
    public List<DialoguePiece> dialoguePieces = new List<DialoguePiece>();
}
