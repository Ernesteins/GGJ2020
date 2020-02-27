using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class espadoafiladora : MonoBehaviour
{ 
    public GameObject ball1;
    public Rigidbody ballRB;
    bool active = false;
    float inicio;
    public GameObject[] camara;
    Vector3 playerpos;
    public float OffsetX;
    public float OffsetY;
    public float OffsetZ;
    private Afiladora AfilaScript;
    private Animator AfilAnim;
    public Canvas CanvasB;

    // public Camera camara2;

    // Start is called before the first frame update
    void Start()
    {
        CanvasB.enabled = false;
        camara[0].gameObject.SetActive(false);
        camara[1].gameObject.SetActive(false);
        AfilaScript = GameObject.FindObjectOfType<Afiladora>();
        AfilAnim = gameObject.GetComponent<Animator>();
        AfilAnim.enabled = false;
        playerpos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("object"))
        {
           AfilaScript.Insta = true;
          //  AfilaScript.starG = true;
             camara[0].gameObject.SetActive(true);
            camara[1].gameObject.SetActive(true);
            AfilAnim.enabled = true;
            ball1 = other.gameObject;
            CanvasB.enabled = true;
            //ball1.transform.position = new Vector3

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        //Stop the force in one direction
        
    }
    public void endgame2()
    {
        camara[1].gameObject.SetActive(false);
        camara[0].gameObject.SetActive(false);
        AfilAnim.enabled = false;
        GameObject.FindGameObjectWithTag("Player").transform.position = playerpos;
        active = false;
       CanvasB.enabled = false;


    }
    

}