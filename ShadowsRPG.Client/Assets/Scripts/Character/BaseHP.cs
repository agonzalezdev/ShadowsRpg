using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHP : MonoBehaviour
{
    [SerializeField] protected float initialHP;
    [SerializeField] protected float maxHP;

    public float HP { get; protected set; }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        HP = initialHP;
    }

    public void GetDamage(float damage)
    {
        if (damage <= 0)
            return;

        if(HP > 0f)
        {
            HP -= damage;
            UpdateHPBar(HP, maxHP);
            if(HP <= 0f)
            {
                UpdateHPBar(HP, maxHP);
                CharacterHasDefeated();
            }
        }
    }

    protected virtual void UpdateHPBar(float currentHP, float maxHP)
    {

    }

    protected virtual void CharacterHasDefeated()
    {

    }

}
