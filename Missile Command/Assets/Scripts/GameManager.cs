using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        ScreenUtils.Initialize();
        Debug.Log("Left" + ScreenUtils.ScreenLeft);
        Debug.Log("Right" + ScreenUtils.ScreenRight);
        Debug.Log("Top" + ScreenUtils.ScreenTop);
        Debug.Log("Bottom" + ScreenUtils.ScreenBottom);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
