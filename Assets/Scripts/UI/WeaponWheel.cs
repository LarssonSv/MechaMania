using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponWheel : MonoBehaviour
{

    [SerializeField] Canvas weaponWheelGroup;

    public WeaponHandler weaponHandler;
    public WheelSlice wheelSlice;
    WeaponSchematic newWeapon;

    private void Start()
    {
        weaponWheelGroup.enabled = false;
        weaponHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponHandler>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            weaponWheelGroup.enabled = true;
            GameManager.GM.SetUiState(1);
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            weaponWheelGroup.enabled = false;

            if (newWeapon != null && newWeapon != weaponHandler.currentWeapon && wheelSlice != null)
            {
                WeaponSchematic temp = weaponHandler.currentWeapon;
                weaponHandler.StartEquip(newWeapon);


                wheelSlice.SetNewWeapon(temp);

            }

            GameManager.GM.SetUiState(0);
        }

    }

    public void ChangeWeapon (WheelSlice x)
    {
        if(x != null)
        {
            if (x.newWeapon != weaponHandler.currentWeapon)
            {

                newWeapon = x.newWeapon;
                wheelSlice = x;
            }
        }
        else
        {
            wheelSlice = null;
        }
       


    }

}
