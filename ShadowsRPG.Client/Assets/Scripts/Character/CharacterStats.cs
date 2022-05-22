using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats")]
public class CharacterStats : ScriptableObject
{
    [Header("Stats")]
    public float Dmg = 5f;
    public float Defense = 2f;
    public float Speed = 5f;
    public float Level;
    public float CurrentExp;
    public float RequiredExpToNextLevel;
    [Range(0f, 100f)] public float CriticalChance;
    [Range(0f, 100f)] public float BlockChance;

    [Header("Attributes")]
    public int Strenght;
    public int Intelligence;
    public int Dexterity;

    [HideInInspector] public int AvailableAttributePoints;

    public void AddBonusStrenght()
    {
        Dmg += 2f;
        Defense += 1f;
        BlockChance += 0.03f;
        Speed += 0.1f;
    }

    public void AddBonusIntelligence()
    {
        Dmg += 4f;
    }

    public void AddBonusDexterity()
    {
        Dmg += 3f;
        Speed += 0.3f;
        CriticalChance += 0.1f;
        BlockChance += 0.02f;
    }

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

        Strenght = 0;
        Intelligence = 0;
        Dexterity = 0;

        AvailableAttributePoints = 0;
    }
}
