using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silo : MonoBehaviour
{

    public GameObject missilePrefab;
    private Vector3 launchPosition = new Vector3(0f, 0.4f, 0f);
    Camera camera;


    // Start is called before the first frame update
    void Start()
    {
        camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Launch();
        }
    }

    private void Launch()
    {
        //Get Mouse Position
        Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        
        if(mousePos.y > 1.9)
        {
            //Spawn a missle 
            GameObject newMissile = Instantiate(missilePrefab, launchPosition, Quaternion.identity);
            //Set Target
            newMissile.GetComponent<Missile>().SetTarget(mousePos);
        }
        else
        {
            Debug.Log("Cannot fire into ground.  Launch aborted.");
        }
   
    }
}