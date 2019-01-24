using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Projectile : MonoBehaviour
{

    DamagePackage damagePackage;
    float speed = 10.0f;

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void Start()
    {
        gameObject.hideFlags = HideFlags.HideInHierarchy;

        //gameobject.hideFlags = HideFlags.HideInHierarchy;
    }

    public void SetDamagePackage (DamagePackage x, float z = 5.0f)
    {
        damagePackage = x;
        speed = z;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<HealthComponent>().RecieveDamagePackage(damagePackage);
            gameObject.SetActive(false);
        }
    }

    





}
