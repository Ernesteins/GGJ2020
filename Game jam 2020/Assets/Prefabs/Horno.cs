using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Horno : MonoBehaviour
{
	[SerializeField] int maxCantidadObjetos = 1;
	[SerializeField] float temperaturaPorSegundo = 20;
	[SerializeField] termometro ter; //referencia al temometro
	List<Arma> objetosEnElHorno = new List<Arma>();
	// Start is called before the first frame update
	private void OnTriggerEnter(Collider other) // Cuando entra al horno
	{
		Debug.Log(other.name);
		if (objetosEnElHorno.Count < maxCantidadObjetos)
		{
			objetosEnElHorno.Add(other.transform.GetComponent<Arma>());
			ter.Inicia(other.transform.GetComponent<Arma>());
		}
	}

	private void OnTriggerExit(Collider other) //Cuando sale del horno
	{
		if(objetosEnElHorno.Count>0)
		{
			int index  = objetosEnElHorno.IndexOf(other.GetComponent<Arma>());
			objetosEnElHorno.RemoveAt(index);
			SoundMananger.Pasue();
			ter.Cierra();
		}
	}

	private void Start()
	{
		StartCoroutine(Temperatura());
	}
	
	IEnumerator Temperatura()
	{
		while(0<1)
		{
			foreach (Arma a in objetosEnElHorno)
			{
				SoundMananger.Reproducir("sonidoFuego");
				a.Calienta(temperaturaPorSegundo);
			}
			yield return new WaitForSeconds(1);
		}
	}
}
