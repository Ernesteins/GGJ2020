using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Yunque : MonoBehaviour
{
	[SerializeField] Transform posArma;
	[SerializeField] ZonaMartillable zonaMartillable;
	[SerializeField] Transform imagen;
	[SerializeField] float delay = 5f;
	[SerializeField] Camera cam;
	[SerializeField] Transform martillo;
	[SerializeField] float factorMultiplicador = 1;
	[SerializeField] Slider slider;
	[SerializeField] int cantidadDeGolpes = 5;

	[System.Serializable]
	class ZonaMartillable
	{
		public float minX;
		public float maxX;
		public float minZ;
		public float maxZ;
	}

	Arma arma = null;
	float tiempo = 0;
	Vector2 posObjetivo;
	int contador = 0;
	// Start is called before the first frame update

	private void OnTriggerEnter(Collider other)
	{
		if(arma == null)
		{
			arma = other.GetComponent<Arma>();
			if (!arma.maleable) return;
			arma.Calienta(-300f);
			GameObject.Find("RigidBodyFPSController").GetComponent<MonoBehaviour>().enabled = false;
			GameObject.Find("guia").GetComponent<HoldItems>().UnPick(other.transform);
			GameObject.Find("guia").GetComponent<HoldItems>().enabled = false;
			Cursor.lockState = CursorLockMode.None;
			imagen.gameObject.SetActive(true);
			martillo.gameObject.SetActive(true);
			cam.transform.gameObject.SetActive(true);
			arma.transform.SetPositionAndRotation(posArma.position, posArma.rotation);
		}
	}
	private void OnTriggerExit(Collider other)
	{
		FinDelJuego();
	}

	private void FinDelJuego()
	{
		if (arma != null)
		{
			Cursor.lockState = CursorLockMode.Locked;
			GameObject.Find("RigidBodyFPSController").GetComponent<MonoBehaviour>().enabled = true;
			GameObject.Find("guia").GetComponent<HoldItems>().enabled = true;
			martillo.gameObject.SetActive(false);
			imagen.gameObject.SetActive(false);
			cam.transform.gameObject.SetActive(false);
			contador = 0;
			arma = null;
		}
	}

	void FixedUpdate()
    {
		if (arma == null) return;
		
		if (tiempo <= delay)
		{
			tiempo += Time.deltaTime;
		}
		else
		{
			posObjetivo = RandomPos();
			imagen.localPosition = new Vector3(posObjetivo.x, 0.665f, posObjetivo.y);
			tiempo = 0;
			contador++;
			SoundMananger.Reproducir("sonidoMartillo");
			if (contador >= cantidadDeGolpes)
			{
				FinDelJuego();
				return;
			}
		}
		Vector3 mPos = Input.mousePosition;

		var ray = cam.ScreenPointToRay(mPos);
		RaycastHit info;
		if (Physics.Raycast(ray, out info))
		{
			Vector3 pos = info.point - transform.position;
			pos.y = 0.675f;
			martillo.localPosition = pos;
		}
		if (Input.GetMouseButtonDown(0)) // Click
		{
			
			float distance = Vector3.Distance(martillo.localPosition,imagen.transform.localPosition);
			if (distance < 0.15f)
			{
				tiempo = delay;
				arma.Martillado(distance*factorMultiplicador);
				slider.value = arma.martillado;
			}
		}
		

	}
	Vector2 RandomPos()
	{
		return new Vector2(Random.Range(zonaMartillable.minX, zonaMartillable.maxX),  //x
							Random.Range(zonaMartillable.minZ, zonaMartillable.maxZ));
	}
}
