using UnityEngine;

public class Persona : MonoBehaviour
{
	[SerializeField] GameObject prefabObjetoQueLleva;
	[SerializeField] Vector3 offset;

    public void FinalDeLaFila()
	{
		Instantiate(prefabObjetoQueLleva, transform.position + offset, Quaternion.identity);
	}
}
