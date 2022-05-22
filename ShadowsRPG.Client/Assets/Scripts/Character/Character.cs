using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterStats stats;

    public CharacterHP CharacterHP { get; private set; }
    public CharacterMana CharacterMana { get; private set; }
    public CharacterAnimations CharacterAnimations { get; private set; }

    private void Awake()
    {
        CharacterHP = GetComponent<CharacterHP>();
        CharacterAnimations = GetComponent<CharacterAnimations>();
        CharacterMana = GetComponent<CharacterMana>();
    }

    public void ReviveCharacter()
    {
        CharacterHP.ReviveCharacter();
        CharacterAnimations.ReviveCharacter();
        CharacterMana.ReviveCharacterRestoreMana();
    }

    private void OnEnable()
    {
        AttributeButton.EventUpgradeAttribute += AttributeResponse;
    }

    private void OnDisable()
    {
        AttributeButton.EventUpgradeAttribute -= AttributeResponse;
    }
    private void AttributeResponse(AttributeType attributeType)
    {
        if (stats.AvailableAttributePoints <= 0) return;
        
        switch (attributeType)
        {
            case AttributeType.Strenght:
                stats.Strenght++;
                stats.AddBonusStrenght();
                break;
            case AttributeType.Intelligence:
                stats.Intelligence++;
                stats.AddBonusIntelligence();
                break;
            case AttributeType.Dexterity:
                stats.Dexterity++;
                stats.AddBonusDexterity();
                break;
        }
        stats.AvailableAttributePoints -= 1;
    }

}
