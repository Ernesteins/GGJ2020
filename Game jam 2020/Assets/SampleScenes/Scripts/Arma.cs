using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
	[SerializeField] string nombre;
	public float temperaturaMaleable = 1350f;
	public float FiloMaximo = 10;
	public int Filo = 5;
	//[SerializeField] private float  temperatura = 0;
	public float Temperatura { get; set;} 
			
	public bool maleable { get; private set; } = false;
	public float martillado { get; private set; } = 0f;

	private void Awake() => Temperatura = 0;
	public void Calienta(float valor)
	{
		Temperatura += valor;
		if (Temperatura < 0) Temperatura = 0;
		else if (Temperatura > temperaturaMaleable * 1.5f) Temperatura = temperaturaMaleable * 1.5f;

		if (temperaturaMaleable + 150 > Temperatura && temperaturaMaleable - 150 < Temperatura)
		{
			maleable = true;
		}
		else maleable = false;
	}
	public void Martillado(float value)
	{
		if (martillado <= 1) martillado += value;
	}
    public void Afilado (float filo)
    {

    }
}
