using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField]
    Vector3 targetPos;
    [SerializeField]
    GameObject explosionPrefab;
    Rigidbody2D rb2d;
    float speedModifier = 1f;
    float missileLifeSpan = 4f;
    float explosionOffset = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddRelativeForce(targetPos*speedModifier, ForceMode2D.Impulse);
        Destroy(this.gameObject, missileLifeSpan);
    }

    private void Update()
    {
        MissileHasReachedTarget();
    }

    public void SetTarget(Vector3 target)
    {
        targetPos = target;
        this.transform.rotation = Quaternion.LookRotation(Vector3.forward, target - this.transform.position);
    }

    private void MissileHasReachedTarget()
    {
        float xDifference = Mathf.Abs(transform.position.x - targetPos.x);
        float yDifference = Mathf.Abs(transform.position.y - targetPos.y);
        //Debug.Log("xDiff " + xDifference.ToString() + " yDiff " + yDifference.ToString());
        if(xDifference < explosionOffset && yDifference < explosionOffset)
        {
            Explode();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<EnemyMissile>() != null)
        {
            Explode();
        }
    }

    public void Explode()
    {
        //Instantiate the explosion
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        
        //Destroy this missile
        Destroy(this.gameObject);
    }

}
