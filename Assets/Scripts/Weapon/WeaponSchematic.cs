using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class WeaponSchematic : ScriptableObject
{
    public abstract Sprite GetUiIMage();

    public abstract string GetName();

    public abstract void Fire(WeaponHandler x);

    public abstract void Reload(WeaponHandler x);

    public abstract void OnEquip(WeaponHandler x);

    public abstract void UnEquip(WeaponHandler x);

    public abstract float GetFireRate(WeaponHandler x);

}



