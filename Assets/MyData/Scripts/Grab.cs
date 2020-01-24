using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Grab : MonoBehaviour
{
    public GameObject ball;
    public GameObject Hand;
    public GameObject player;
    public GameObject Trophy;

    Collider ballCol;
    Rigidbody ballRb;
    Vector3 betweenHands = new Vector3(0f, 0.3f, -1.60f);

    //public Vector3 move = new Vector3(Hand.x, Hand.y, Hand.z);

    private void Start()
    {
        ballCol = ball.GetComponent<SphereCollider>();
        ballRb = ball.GetComponent<Rigidbody>();
    }
    public void GrabBall()
    {
        ball.transform.SetParent(Hand.transform);
        ballRb.useGravity = false;
        ball.transform.localPosition = Hand.transform.localPosition + betweenHands;
        player.transform.gameObject.GetComponent<VRGaze>().GVROff();
    }

    public void throwBall(float power)
    {
        Debug.Log("tira");
        ballCol.isTrigger = false;
        ballRb.useGravity = true;
        ball.transform.SetParent(null);
        ballRb.AddForce(Hand.transform.forward * power);
        OnTriggerEnter(ballCol);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Win"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
    //public bool canGrab = false;

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Ball"))
    //    {
    //        Debug.Log("I can grab");
    //        canGrab = true;
    //    }
    //}

    //public void OnTriggerExit(Collider other)
    //{
    //    Debug.Log("I can not grab");
    //    canGrab = false;
    //}

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
