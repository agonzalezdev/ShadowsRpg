using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private Character character;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (character.CharacterHP.IsDefeated)
            {
                character.transform.localPosition = respawnPoint.position;
                character.ReviveCharacter();
            }
        }
    }
}
