using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Jugar()
	{
		SceneManager.LoadScene(1);
	}
	public void Salir()
	{
		Application.Quit();
	}
}
