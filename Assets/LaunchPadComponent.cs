using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPadComponent : MonoBehaviour
{

    [Range(0f, 1000f)] [SerializeField] float launchpower = 500f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            /*other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);*/
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, launchpower, 0f));
        }
    }
     

}
