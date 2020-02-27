using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Afiladora : MonoBehaviour
{
   // public GameObject ball1;
   private Rigidbody ballRB;
    public bool starG = false;
    public Transform Position1;
    public GameObject Pre;
    public bool Insta = false;
    private espadoafiladora EspadEscript;
    private float OffsetInst;
    private Arma ArmaScript;
    //private Arma ArmaScript;

    // public Camera camara2;

    // Start is called before the first frame update
    void Start()
    {

        EspadEscript = GameObject.FindObjectOfType<espadoafiladora>();
        ArmaScript = GameObject.FindObjectOfType<Arma>();
    }

    // Update is called once per frame
    void Update()
    {
        OffsetInst = Random.Range(-0.5f, 0.5f);
        if (Insta)
        {
            Instantiate(Pre, Position1.position, Quaternion.identity);
            Insta = false;
            StartCoroutine(TimeToPlay());
        }
        if (starG)
        {
            

            if (Input.GetKeyDown(KeyCode.A))
            {

                ballRB.AddForce(Vector3.left * Random.Range(1, 5), ForceMode.Impulse);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                ballRB.AddForce(Vector3.right * Random.Range(1, 5), ForceMode.Impulse);

            }

            if (transform.position.x < ballRB.position.x)
            {
                // Apply a force to apposite side
                ballRB.AddForce(Vector3.right * 5f, ForceMode.Force);

            }
            if (transform.position.x > ballRB.position.x)
            {
                // Apply a force to apposite side
                ballRB.AddForce(Vector3.left * 5f, ForceMode.Force);

            }

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        ballRB = collision.gameObject.GetComponent<Rigidbody>();
        starG = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        //Stop the force in one direction
        if (starG)
        {
            ballRB.velocity = Vector3.zero;
            ballRB.transform.position = new Vector3 ( Position1.transform.position.x + OffsetInst, Position1.transform.position.y, Position1.transform.position.z); //new Vector3(Position1.transform.position.x , Position1.transform.position.y, Position1.transform.position.z);
            ArmaScript.Filo--;
        }
        
    }
    private IEnumerator TimeToPlay()
    {
        yield return new WaitForSeconds(10);
        endgame();
       
    }
    void endgame()
    {
        
        starG = false;
        EspadEscript.endgame2();
       // StartCoroutine(TimeToReplay());

    }
    /*  private void OnTriggerEnter(Collider other)
      {
          if (other.CompareTag("object"))
          {

              ball1 = other.gameObject;
              ballRB = ball1.GetComponent<Rigidbody>();
              ballRB.isKinematic = false;
              ball1.transform.SetPositionAndRotation(new Vector3( transform.position.x + OffsetX, transform.position.y + OffsetY, transform.position.z + OffsetZ), ball1.transform.rotation); //= new Vector3(transform.position.x + Random.Range(-0.5f, 0.5f), ball1.transform.position.y, transform.position.z);
              active = true;
              StartCoroutine(TimeToPlay());
          }
      }


      }
    

      private IEnumerator TimeToReplay()
      {
          yield return new WaitForSeconds(3);

      }*/

}
