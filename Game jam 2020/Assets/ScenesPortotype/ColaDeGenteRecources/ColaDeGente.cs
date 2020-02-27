using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Busca crear una fila de los objetos que esten en el array de prefabs
 * Cuando se llama a la funcion publica SiguientePersona() adelanta la 
 * persona y anima el avance del resto
 * B608
 */
public class ColaDeGente : MonoBehaviour
{
	
	[SerializeField] private GameObject[] personasDeLaFilaPrefab; //Array de objetos que reprecentan las personas en la fila
	[SerializeField] private float separacion = 0.5f; // separacion entre personas 
	[SerializeField] private float pasos = 1;
	[SerializeField] private float speed = 10f;
	private Queue<Transform> fila = new Queue<Transform>();

	private void Awake()
	{

		int i = 0;
		foreach(GameObject persona in personasDeLaFilaPrefab)
		{
			Transform createdOb = Instantiate(persona, transform).transform;
			createdOb.localPosition = new Vector3(0, 0, (pasos +separacion) * i);
			fila.Enqueue(createdOb);
			i++;
		}
	}

	public void SiguientePersona()
	{
		if (fila.Count <= 0) return; // ya se acabo la fila
		Transform personaFila = fila.Dequeue();
		personaFila.GetComponent<Persona>().FinalDeLaFila();
		personaFila.gameObject.SetActive(false);
		foreach (Transform p in fila)
		{
			StartCoroutine(Avanza(p));
		}
	}
	IEnumerator Avanza(Transform ob)
	{
		float target = ob.localPosition.z - pasos - separacion;

		while (ob.localPosition.z >= target ) {
			Vector3 pos = ob.localPosition;
			ob.localPosition -= new Vector3(pos.x, pos.y, speed*Time.fixedDeltaTime); // avanza en el eje z
			yield return new WaitForFixedUpdate();
		}
	}
}
