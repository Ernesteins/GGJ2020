
using UnityEngine.SceneManagement;
using UnityEngine;

public class Caja : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Arma a = other.GetComponent<Arma>();
		if (a!=null)
		{
			if (a.Temperatura < 40f && a.martillado >= 0.9)
			{
				SceneManager.LoadScene(2);
			}
			else
			{
				Debug.Log("FALTA MARTILLAR O BAJAR LA TEMPERATURA");
			}
		}
	}
}
