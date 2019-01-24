using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapComponent : MonoBehaviour
{

    float Scrap = 0.0f;

    public void AddScrap (float x) {
        Scrap += x;
    }

    public void SetScrap(float x) {
        Scrap = x;
    }

    public float GetScrap() {
        return Scrap;
    }



}
