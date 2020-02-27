using UnityEngine;
using System.Collections;
using System;


public class HoldItems : MonoBehaviour
{
	
	[SerializeField] Camera cam;
	[SerializeField] LayerMask pickable;
	[SerializeField] float maxDistance = 10f;
	[SerializeField] Vector3 offset = new Vector3(0, 0, 0);

	bool picked = false;
	Transform objetoRecogido;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if(objetoRecogido == null)
				Pick();
			else
				UnPick(objetoRecogido);
		}
	}

	void Pick()
	{
		if (objetoRecogido == null)
		{
			Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
			Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.yellow);
			RaycastHit info;
			if (Physics.Raycast(ray, out info, maxDistance, pickable))
			{
				Debug.Log(info.transform.gameObject.name);
				info.rigidbody.isKinematic = true;
				//info.transform.GetComponent<Collider>().isTrigger = true;
				objetoRecogido = info.transform;
			}
		}
	}
	public void UnPick(Transform t)
	{
		if (t == null) return;
		t.GetComponent<Rigidbody>().isKinematic = false;
		t.GetComponent<Collider>().isTrigger = false;
		objetoRecogido = null;
	}
	private void FixedUpdate()
	{
		if (objetoRecogido == null) return;
		Vector3 pos= transform.position;
		objetoRecogido.position = pos;
		objetoRecogido.rotation = transform.rotation;
		
	}
}