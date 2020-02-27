using UnityEngine;

public class Pared : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("PARED");
		if (other.CompareTag("object"))
		{
			GameObject.Find("guia").GetComponent<HoldItems>().UnPick(other.transform);
		}
	}
}
