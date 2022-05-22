using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Character : MonoBehaviour
{
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
        CharacterMana.RestoreMana();
    }

}
