using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public GameObject ball;
    public GameObject myHand;
    public float handPower;
    public bool inHands = false;
    public Vector3 ballOriginalPosition;
    Collider ballCol;
    Rigidbody ballRb;
    Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        //ballOriginalPosition = ball.transform.position;
        ballCol = ball.GetComponent<SphereCollider>();
        ballRb = ball.GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            
            if (!inHands && myHand.GetComponent<Grab>().canGrab )
            {
                ballCol.isTrigger = true; 
                ball.transform.SetParent(myHand.transform);
                ball.transform.localPosition = new Vector3(0, -.672f, 0f);
                ballRb.velocity = Vector3.zero;
                ballRb.useGravity = false;
                inHands = true;
            }
            else if(inHands)
            {
                ballCol.isTrigger = false ;
                ballRb.useGravity = true; 
                this.GetComponent<PlayerGrab>().enabled = false;
                ball.transform.SetParent(null);
                //ball.transform.localPosition = ballOriginalPosition;
                ballRb.velocity = cam.transform.rotation * Vector3.forward * handPower;
                inHands = false;

            }
            

        }
        
    }
}
