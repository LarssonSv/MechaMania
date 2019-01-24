using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager GM;

    FreeLookCam freeLockCamera;
    WeaponHandler weaponHandler;
    public uiState currentState;


    public enum uiState
    {
        NONE, WEAPONWHEEL, DIALOUGE, INVENTORY, SHOP, MAINMENU
    }

    void Start()
    {
        if (GM == null)
        {
            GM = this;
        }
        else
        {
            Debug.LogError("Multiple GameManagers present!");
        }


        freeLockCamera = GameObject.FindGameObjectWithTag("FreeLockCam").GetComponent<FreeLookCam>();
        weaponHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponHandler>();

        currentState = uiState.NONE;


    }

    private void Update()
    {
        CursorManager();
    }

    void CursorManager()
    {
        if (currentState == uiState.NONE)
        {
            freeLockCamera.enabled = true;
            weaponHandler.inMenu = false;
            Time.timeScale = 1;
        }
        else
        {
            freeLockCamera.enabled = false;
            weaponHandler.inMenu = true;
            Time.timeScale = 0;
        }

    }

    public void SetUiState(int x)
    {

        currentState = (uiState)x;

    }

}
