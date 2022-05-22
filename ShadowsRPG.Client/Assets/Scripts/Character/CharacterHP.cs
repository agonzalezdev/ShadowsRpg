using System;
using UnityEngine;

public class CharacterHP : BaseHP
{

    public static Action EventPlayerDefeated;

    public bool CanBeHealed => HP < maxHP;
    public bool IsDefeated { get; private set; }

    private BoxCollider2D _boxCollider2D;


    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    protected override void Start()
    {
        base.Start();
        UpdateHPBar(HP, maxHP);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            GetDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            HealHP(10);
        }
    }

    public void HealHP(float amount)
    {
        if (IsDefeated || !CanBeHealed)
            return;

        HP += amount;
        if (HP > maxHP)        
            HP = maxHP;        

        UpdateHPBar(HP, maxHP);
    }

    protected override void UpdateHPBar(float currentHP, float maxHP)
    {
        UIManager.Instance.UpdateCharacterHP(currentHP, maxHP);
    }

    public void ReviveCharacter()
    {
        _boxCollider2D.enabled = true;
        IsDefeated = false;
        HP = initialHP;
        UpdateHPBar(HP, initialHP);
    }

    protected override void CharacterHasDefeated()
    {
        IsDefeated = true;
        _boxCollider2D.enabled = false;
        EventPlayerDefeated?.Invoke();
    }
}
