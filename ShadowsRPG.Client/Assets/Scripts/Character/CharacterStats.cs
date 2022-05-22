using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats")]
public class CharacterStats : ScriptableObject
{
    public float Dmg = 5f;
    public float Defense = 2f;
    public float Speed = 5f;
    public float Level;
    public float CurrentExp;
    public float RequiredExpToNextLevel;
    [Range(0f, 100f)] public float CriticalChance;
    [Range(0f, 100f)] public float BlockChance;


    public void ResetStats()
    {
        Dmg = 5f;
        Defense = 2f;
        Speed = 5f;
        Level = 1;
        CurrentExp = 0f;
        RequiredExpToNextLevel = 0f;
        BlockChance = 0f;
        CriticalChance = 0f;
    }
}
