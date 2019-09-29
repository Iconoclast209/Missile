using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class City : MonoBehaviour
{
    [SerializeField]
    string cityName;
    GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>(); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<EnemyMissile>() != null)
        {
            //City Destroyed Message
            gm.CityDestroyed(cityName);

            //Destroy City
        }
    }
}
