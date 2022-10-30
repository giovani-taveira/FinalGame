using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Obj./Clue")]

public class Clues : ScriptableObject
{
    [SerializeField]
    [TextArea(1, 7)]
    private string text;

    public string Text
    {
        get { return text; }
    }
}
