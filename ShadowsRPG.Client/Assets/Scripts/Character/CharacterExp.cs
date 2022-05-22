using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterExp : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private CharacterStats stats;

    [Header("Config")]
    [SerializeField] private int maxLevel;
    [SerializeField] private int expBase;
    [SerializeField] private int incrementalValue;

    private float currentExp;
    private float requiredExpToNextLevel;
    private float currentExpTmp;

    // Start is called before the first frame update
    void Start()
    {
        stats.Level = 1;
        requiredExpToNextLevel = expBase;
        stats.RequiredExpToNextLevel = requiredExpToNextLevel;
        UpdateExpBar();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            AddExp(10);
        }
    }

    public void AddExp(float exp)
    {
        if (exp > 0f)
        {

            float expLeftToNextLevel = stats.RequiredExpToNextLevel - currentExpTmp;
            if (exp >= expLeftToNextLevel)
            {
                exp -= expLeftToNextLevel;
                currentExp += exp;
                UpdateLevel();
                AddExp(exp);
            }
            else
            {
                currentExp += exp;
                currentExpTmp += exp;
                if(currentExpTmp == requiredExpToNextLevel)
                {
                    UpdateLevel();
                }
            }

        }

        stats.CurrentExp = currentExp;
        UpdateExpBar();
    }

    private void UpdateLevel()
    {
        if (stats.Level >= maxLevel) return;

        stats.Level++;
        currentExpTmp = 0f;
        requiredExpToNextLevel *= incrementalValue;
        stats.RequiredExpToNextLevel = requiredExpToNextLevel;
    }

    private void UpdateExpBar()
    {
        UIManager.Instance.UpdateCharacterExp(currentExpTmp, requiredExpToNextLevel);
    }
}
