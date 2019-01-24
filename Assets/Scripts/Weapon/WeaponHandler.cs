using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{

    //Publics
    public bool equiped = true;
    public WeaponSchematic currentWeapon;
    public Transform firePoint;
    public bool inMenu = false;

    //Privates
    float readyFire = 0;
    bool fireRateCd = false;
    bool reloading = false;
    

    //UnityEditor
    [Range(0f, 5f)] [SerializeField] float equipTime = 3.0f;

    //TODO STATEMACHINE FOR WEAPON
    void Start()
    {
        if (currentWeapon == null)
        {
            Debug.Log("No Weapon selected");
            equiped = false;
        }
    }

    void Update()
    {
        if (equiped && !reloading && !inMenu)  ///TODO STATEMACHINE
        {
            if (Input.GetButton("Reload"))
            {

                currentWeapon.Reload(this);
            }

            else if (Input.GetButton("Fire1") && !fireRateCd)
            {
                currentWeapon.Fire(this);
                readyFire = currentWeapon.GetFireRate(this);
            }

            if (readyFire > 0)
            {
                readyFire -= Time.deltaTime;
                fireRateCd = true;
            }
            else
            {
                fireRateCd = false;
            }

        }
    }

    public bool isEquiped()
    {
        return equiped;
    }

    public void StartReload(float x)
    {
        StartCoroutine(ReloadTimer(x));
    }

    public void StartEquip(WeaponSchematic x)
    {
        StartCoroutine(Equip(x));
    }

    public IEnumerator ReloadTimer(float reloadTime)
    {
        float ReloadTimerValue = reloadTime;
        reloading = true;

        while (ReloadTimerValue > 0)
        {
            yield return new WaitForSeconds(0.1f);
            ReloadTimerValue -= 0.1f;
        }

        reloading = false;
    }

    public IEnumerator Equip(WeaponSchematic newWeapon)
    {
        equiped = false;
        //currentWeapon.UnEquip(this);
        currentWeapon = newWeapon;

        float currentTime = equipTime;

        while (currentTime > 0)
        {
            yield return new WaitForSeconds(0.1f);
            currentTime -= 0.1f;
        }

        equiped = true;
        //currentWeapon.OnEquip(this);
    }
}
