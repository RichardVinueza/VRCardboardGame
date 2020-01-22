using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Image imgGaze;
    public float totalTime = 2;
    bool gvrStatus;
    float gvrTimer;

    public int distanceOfRay = 1000;
    private RaycastHit _hit;

    public string goToLevelOne;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        print("Enter in Update");
        if (gvrStatus)
        {
            print("First IF");
            gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = gvrTimer / totalTime;
        }

        print("Ray work");
        if (imgGaze.fillAmount >= 1)
        {
            SceneManager.LoadScene(goToLevelOne);

        }

    }

    public void Go()
    {
        print("Enter");
        gvrStatus = true;
    }

    public void Exit()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;
    }
}
