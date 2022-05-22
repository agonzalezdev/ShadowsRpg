using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    [SerializeField] private string layerIdle;
    [SerializeField] private string layerMovement;


    private Animator _animator;
    private CharacterMovement _characterMovement;

    private readonly int directionX = Animator.StringToHash("X");
    private readonly int directionY = Animator.StringToHash("Y");
    private readonly int defeated = Animator.StringToHash("Defeated");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _characterMovement = GetComponent<CharacterMovement>();
    }

    void Update()
    {
        UpdateLayers();

        if (!_characterMovement.IsInMovement)
            return;

        _animator.SetFloat(directionX, _characterMovement.MovementDirection.x);
        _animator.SetFloat(directionY, _characterMovement.MovementDirection.y);
    }

    private void EnableLayer(string layerName)
    {
        for (int i = 0; i < _animator.layerCount; i++)
        {
            _animator.SetLayerWeight(i, 0);
        }

        _animator.SetLayerWeight(_animator.GetLayerIndex(layerName), 1);
    }

    private void UpdateLayers()
    {
        if (_characterMovement.IsInMovement)
        {
            EnableLayer(layerMovement);
        }
        else
        {
            EnableLayer(layerIdle);
        }
    }

    public void ReviveCharacter()
    {
        EnableLayer(layerIdle);
        _animator.SetBool(defeated, false);
    }

    private void PlayerDefeatedResponse()
    {
        if(_animator.GetLayerWeight(_animator.GetLayerIndex(layerIdle)) == 1)
        {
            _animator.SetBool(defeated, true);
        }
    }

    private void OnEnable()
    {
        CharacterHP.EventPlayerDefeated += PlayerDefeatedResponse;
    }

    private void OnDisable()
    {
        CharacterHP.EventPlayerDefeated -= PlayerDefeatedResponse;

    }
}
