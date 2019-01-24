using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour {

    public float Health = 100.0f;
    public float maxHealth = 100.0f;
    public float weakPointModifier = 2.0f;


    public bool RecieveDamagePackage(DamagePackage x) {
        //ToAdd Weakpoint


        Health -= x.fleshDamage;

        if (Health <= 0) {
            return true;
        }
        else {
            return false;
        }

    }

}
