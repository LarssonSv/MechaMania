using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WheelSlice : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    //Publics
    public WeaponSchematic newWeapon;

    //Private
    Image sprite;
    string name;

    //Unity
    [SerializeField] WeaponWheel weaponWheel; 

    private void Start()
    {
        sprite = GetComponent<Image>();
        sprite.alphaHitTestMinimumThreshold = 0.5f;
        sprite.sprite = newWeapon.GetUiIMage();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        sprite.color = Color.cyan;

        if(newWeapon != null)
        {
            weaponWheel.ChangeWeapon(this);
        }
        else
        {
            Debug.Log("Weapon Not Assigned to wheel");
        }
        
    }

    public void OnPointerExit (PointerEventData eventData)
    {
        sprite.color = Color.white;
        weaponWheel.ChangeWeapon(null); 
    }

    public void SetNewWeapon(WeaponSchematic x)
    {
        newWeapon = x;
        sprite.sprite = x.GetUiIMage();
        name = x.GetName();
    }

}
