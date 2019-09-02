using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField]
    Vector3 targetPos;
    Rigidbody2D rb2d;
    float speedModifier = 1f;
    float missileLifeSpan = 4f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        rb2d.AddRelativeForce(targetPos*speedModifier, ForceMode2D.Impulse);

        Destroy(this.gameObject, missileLifeSpan);
    }

    public void SetTarget(Vector3 target)
    {
        Debug.Log("Setting Target for " + this.name);
        targetPos = target;
        this.transform.rotation = Quaternion.LookRotation(Vector3.forward, target - this.transform.position);
    }

}
