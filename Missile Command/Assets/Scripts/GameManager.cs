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
    [SerializeField]
    GameObject gameOverPanel;
    [SerializeField]
    Text gameOverPanelText;
    [SerializeField]
    GameObject EnemySpawnerObject;

    int missilesDestroyed = 0;
    float cityDestroyedMessageViewLength = 3.0f;
    bool sanFranciscoDestroyed = false;
    bool newYorkCityDestroyed = false;


    private void Awake()
    {
        ScreenUtils.Initialize();
        Debug.Log("Left" + ScreenUtils.ScreenLeft);
        Debug.Log("Right" + ScreenUtils.ScreenRight);
        Debug.Log("Top" + ScreenUtils.ScreenTop);
        Debug.Log("Bottom" + ScreenUtils.ScreenBottom);
    }

    public void MissileDestroyed()
    {
        missilesDestroyed++;
        textMissilesDestroyed.text = missilesDestroyed.ToString();
    }

    public void CityDestroyed(string city)
    {
        if(city == "San Francisco" && !sanFranciscoDestroyed)
        {
            sanFranciscoDestroyed = true;
            cityDestroyedMessage.GetComponent<Text>().text = city + " has been destroyed!";
            cityDestroyedMessage.SetActive(true);
            Invoke("HideCityDestroyedMessage", cityDestroyedMessageViewLength);
        }
        else if(!newYorkCityDestroyed)
        {
            newYorkCityDestroyed = true;
            cityDestroyedMessage.GetComponent<Text>().text = city + " has been destroyed!";
            cityDestroyedMessage.SetActive(true);
            Invoke("HideCityDestroyedMessage", cityDestroyedMessageViewLength);
        }
        else
        {
            Debug.Log(city + " has already been destroyed...");
        }

        //Check for Lose Condition
        if(sanFranciscoDestroyed && newYorkCityDestroyed)
        {
            Invoke("GameOver", cityDestroyedMessageViewLength);
        }
    }

    private void HideCityDestroyedMessage()
    {
        cityDestroyedMessage.SetActive(false);
        cityDestroyedMessage.GetComponent<Text>().text = "";
    }

    private void GameOver()
    {
        gameOverPanelText.text = "YOU DESTROYED " + missilesDestroyed.ToString() + " MISSILES";
        gameOverPanel.SetActive(true);
        EnemySpawnerObject.SetActive(false);
    }

}
