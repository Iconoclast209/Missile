using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    [SerializeField]
    Vector3 targetPos;
    [SerializeField]
    Rigidbody2D rb2d;
    [SerializeField]
    float speedModifier = 1f;


    public void SetTarget(Vector3 target)
    {
        targetPos = target;
    }

    public void ApplyForce()
    {
        rb2d.AddRelativeForce((Vector2)(targetPos - this.transform.position).normalized * speedModifier, ForceMode2D.Impulse);

    }
}
