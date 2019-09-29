using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Text textMissilesDestroyed;
    [SerializeField]
    GameObject cityDestroyedMessage;
    int missilesDestroyed = 0;
    float cityDestroyedMessageViewLength = 3.0f;


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
        //textMissilesDestroyed.text = missilesDestroyed.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MissileDestroyed()
    {
        missilesDestroyed++;
        textMissilesDestroyed.text = missilesDestroyed.ToString();
    }

    public void CityDestroyed(string city)
    {
        cityDestroyedMessage.GetComponent<Text>().text = city + " has been destroyed!";
        cityDestroyedMessage.SetActive(true);
        Invoke("HideCityDestroyedMessage", cityDestroyedMessageViewLength);
    }

    private void HideCityDestroyedMessage()
    {
        cityDestroyedMessage.SetActive(false);
        cityDestroyedMessage.GetComponent<Text>().text = "";
    }
}
