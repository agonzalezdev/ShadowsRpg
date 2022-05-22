using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPCInteractionType
{
    Dialog,
    OpenQuests,
    OpenStore,
    OpenCrafting
}

[CreateAssetMenu]
public class NPCDialog : ScriptableObject
{
    // Start is called before the first frame update
    [Header("Info")]
    public string Name;
    public Sprite Icon;
    public NPCInteractionType Type;

    [Header("Salute")]
    [TextArea] public string Salute;

    [Header("Conversation")]
    public TextDialog[] Conversation;

    [Header("Leave")]
    [TextArea] public string Leave;

}

[Serializable]
public class TextDialog
{
    [TextArea] public string Phrase;
}
