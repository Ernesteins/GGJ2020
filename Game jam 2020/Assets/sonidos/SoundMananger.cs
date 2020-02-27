using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMananger : MonoBehaviour
{
	[SerializeField] AudioSource _audioSource;
	[SerializeField] AudioClip _sonidoMartillo;
	[SerializeField] AudioClip _sonidoAguaCaliente;
	[SerializeField] AudioClip _sonidoFuego;
	[SerializeField] AudioClip _sonidoAfilar;
	//[SerializeField] AudioClip _pasos;

	public static AudioSource audioSource;
	public static Dictionary<string, AudioClip> dic = new Dictionary<string, AudioClip>();

	// Update is called once per frame
	void Awake()
	{

		audioSource = _audioSource;
		//dic.Add("musica", _musica);
		dic.Add("sonidoMartillo", _sonidoMartillo);
		dic.Add("sonidoAguaCaliente", _sonidoAguaCaliente);
		dic.Add("sonidoFuego", _sonidoFuego);
		dic.Add("sonidoAfilar", _sonidoAfilar);
		//dic.Add("pasos", _pasos);
	}

	public static void Reproducir(string clipName)
	{
		if (dic.ContainsKey(clipName)&&!audioSource.isPlaying)
		{
			audioSource.clip = dic[clipName];
			if (clipName == "sonidoAguaCaliente")
				audioSource.loop = true;
			audioSource.Play();
		}
		else
		{
			Debug.LogWarning("No hay un audio llamado " + clipName);
		}
	}
	public static void Pasue()
	{
		audioSource.Pause();
		audioSource.loop = false;
	}
}
