  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VRGaze : MonoBehaviour
{
    public Image imgGaze;
    public float totalTime = 2;
    bool gvrStatus;
    float gvrTimer;

    public int distanceOfRay = 10;
    private RaycastHit _hit;

    public GameObject coin0;
    public GameObject coin1;
    public GameObject coin2;
    public GameObject coin3;
    public GameObject wall;

    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = gvrTimer / totalTime;

            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            if (Physics.Raycast(ray, out _hit, distanceOfRay))
            {
                if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Teleport"))
                {
                    _hit.transform.gameObject.GetComponent<Teleport>().TeleportPlayer();
                }

                if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Coin"))
                {
                    coin1.SetActive(false);
                    SceneManager.LoadScene(sceneName);
                }
                if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("GoodCoin"))
                {
                    coin0.SetActive(false);
                    GVROff();
                    wall.SetActive(false);
        
                }
                
            }
        }

        

        
    }

    public void GVROn()
    {
        gvrStatus = true;
    }

    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;
    }

}
