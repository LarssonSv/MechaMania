#pragma warning disable 0414  //Disabled Warning For values not used at the moment
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Weapons/BlasterWeapon")]
public class BlasterWeapon : WeaponSchematic
{
    //Publics

    //Privates

    //Unity
    [Range(0f, 100f)] [SerializeField] float fleshdamage = 5.0f;
    [Range(0f, 100f)] [SerializeField] float armordamage = 5.0f;
    [Range(0f, 100f)] [SerializeField] float weakPointModifier = 2.0f;
    [Range(0f, 300f)] [SerializeField] float projectileSpeed = 10.0f;
    [Range(0f, 10f)]  [SerializeField] float reloadTime = 2.0f;
    [Range(0f, 5f)]   [SerializeField] float fireRate = 10.0f;
    [SerializeField] Sprite uiSprite;
    [SerializeField] string Name;

    public override Sprite GetUiIMage()
    {
        return uiSprite;
    }

    public override string GetName()
    {
        return Name;
    }

    public override void Fire(WeaponHandler x)
    {
            GameObject z = ObjectPooler.Instance.SpawnFromPool("blasterShot", x.firePoint.position, x.firePoint.rotation);
            z.GetComponent<Projectile>().SetDamagePackage(CreatePackage(), projectileSpeed);
    }

    public override void Reload(WeaponHandler x)
    {
        x.StartReload(reloadTime);
    }

    public override void OnEquip(WeaponHandler x)
    {
        throw new NotImplementedException();
    }

    public override void UnEquip(WeaponHandler x)
    {
        throw new NotImplementedException();
    }

    public override float GetFireRate(WeaponHandler x)
    {
        return fireRate;
    }

    private DamagePackage CreatePackage()
    {
        DamagePackage newPackage = new DamagePackage();
        newPackage.armorDamage = armordamage;
        newPackage.fleshDamage = fleshdamage;
        newPackage.weakPointModifier = weakPointModifier;
        return newPackage;
    }

}
