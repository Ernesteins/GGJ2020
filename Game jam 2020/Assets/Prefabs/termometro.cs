using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Slider))]
public class termometro : MonoBehaviour
{
	[SerializeField] Gradient[] tresColores;
	[SerializeField] Slider slider;
	[SerializeField] Image fill;  
	Arma objetoEstudiado;
    // Start is called before the first frame update
    void Awake()
    {
		slider = GetComponent<Slider>();
    }
	public void Inicia(Arma arma)
	{
		objetoEstudiado = arma;
		slider.minValue = 0;
		slider.maxValue = arma.temperaturaMaleable * 1.5f;
		this.gameObject.SetActive(true);
	}
	public void Cierra()
	{
		objetoEstudiado = null;
		this.gameObject.SetActive(false);
	}
	void Update()
	{
		slider.value = objetoEstudiado.Temperatura;
		float v = slider.value;
		if (v < objetoEstudiado.temperaturaMaleable - 150)
		{
			float eval = Remap(objetoEstudiado.Temperatura, slider.minValue, objetoEstudiado.temperaturaMaleable - 150, 0, 1);
			fill.color = tresColores[0].Evaluate(eval);
		}
		else if(v>objetoEstudiado.temperaturaMaleable + 150)
		{
			float eval = Remap(objetoEstudiado.Temperatura, objetoEstudiado.temperaturaMaleable + 150, slider.maxValue, 0, 1);
			fill.color = tresColores[2].Evaluate(eval);
		}
		else
		{
			fill.color = Color.green;
		}
	}
	float Remap(float value, float from1, float to1, float from2, float to2)
	{
		return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
	}
}
