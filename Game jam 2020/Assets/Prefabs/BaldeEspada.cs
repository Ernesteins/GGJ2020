using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaldeEspada : MonoBehaviour
{
	[SerializeField] Vector3 offset;
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("object"))
        {
			Debug.Log(other.name);
			GameObject.Find("guia").GetComponent<HoldItems>().UnPick(other.transform);
            other.transform.rotation = new Quaternion(50, 0, 180, 251);
            other.transform.position = transform.position + offset;
        }
    }
}
