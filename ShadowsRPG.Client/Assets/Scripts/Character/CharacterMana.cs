using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMana : MonoBehaviour
{
    [SerializeField] private float initialMana;
    [SerializeField] private float maxMana;
    [SerializeField] private float manaRegenPerSecond;

    public float CurrentMana { get; private set; }
    public bool CanBeHealed => CurrentMana < maxMana;

    private CharacterHP _characterHP;

    private void Awake()
    {
        _characterHP = GetComponent<CharacterHP>();
    }


    void Start()
    {
        CurrentMana = initialMana;
        UpdateManaBar();

        InvokeRepeating(nameof(ManaRegen), 1, 0.5f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ConsumeMana(10);
        }
    }

    public void ConsumeMana(float amount)
    {
        if(CurrentMana >= amount)
        {
            CurrentMana -= amount;
            UpdateManaBar();
        }
    }

    public void RestoreMana(float quantity)
    {
        if (CurrentMana >= maxMana)
            return;

        CurrentMana += quantity;
        
        if(CurrentMana > maxMana)        
            CurrentMana = maxMana;

        UpdateManaBar();

    }

    public void ReviveCharacterRestoreMana()
    {
        CurrentMana = initialMana;
        UpdateManaBar();
    }

    private void ManaRegen()
    {
        if(_characterHP.HP > 0f && CurrentMana < maxMana)
        {
            CurrentMana += manaRegenPerSecond;
            UpdateManaBar();
        }
    }

    private void UpdateManaBar()
    {
        UIManager.Instance.UpdateCharacterMana(CurrentMana, maxMana);
    }
}
