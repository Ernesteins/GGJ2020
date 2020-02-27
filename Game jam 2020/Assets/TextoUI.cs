using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextoUI : MonoBehaviour
{
	[SerializeField] Text _text;
	static Text text;
	static GameObject go;
	private void Awake()
	{
		go = gameObject;
		text = _text;
	}

	public static void SetText(string textToDisplay)
	{
		go.SetActive(true);
		text.text = textToDisplay;
		//StartCoroutine(go.GetComponent<TextoUI>().Clear());
	}
	
	public IEnumerator Clear()
	{
		yield return new WaitForSeconds(5);
		go.SetActive(false);
	}
}