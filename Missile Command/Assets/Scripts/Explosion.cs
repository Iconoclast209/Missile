using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    float lifespan = 0;
    float sizeModifier = 1;
    float maxSize = 3;
    Transform transform;
    
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        lifespan += Time.deltaTime;
        Debug.Log("Lifespan " + lifespan);
        float modifier = lifespan * sizeModifier;
        Debug.Log("Modifier " + modifier);
        transform.localScale += new Vector3(modifier, modifier, 0f);
        if(transform.localScale.x > maxSize)
        {
            Destroy(this.gameObject);
        }
    }
}
