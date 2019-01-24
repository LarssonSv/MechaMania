using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DamagePackage
{

    public DamagePackage()
    {
        armorDamage = 0;
        fleshDamage = 0;
        weakPointModifier = 0;
    }

        public float armorDamage;
        public float fleshDamage;
        public float weakPointModifier;

}
