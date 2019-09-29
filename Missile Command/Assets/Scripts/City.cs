using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    [SerializeField]
    string cityName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<EnemyMissile>() != null)
        {
            //Destroy City
            Debug.Log(cityName + " destroyed.");
        }
    }
}
