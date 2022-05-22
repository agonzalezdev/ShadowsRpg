using System;
using UnityEngine;

public enum AttributeType
{
    Strenght,
    Intelligence,
    Dexterity
}

public class AttributeButton : MonoBehaviour
{
    public static Action<AttributeType> EventUpgradeAttribute;

    [SerializeField] private AttributeType attributeType;

    public void UpgradeAttribute()
    {
        EventUpgradeAttribute?.Invoke(attributeType);
    }

}
