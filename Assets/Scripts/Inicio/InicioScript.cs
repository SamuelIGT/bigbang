using UnityEngine;
using UnityEngine.SceneManagement;

public class InicioScript : MonoBehaviour
{

	public GameObject apresentacaoPanel;
	public GameObject tituloPanel;
	public GameObject menuPanel;
	public float limiteApresentacaoFrame;
	int estado = 0;
	//0 apresentacao, 1 titulo, 2 menu
	public float limiteTituloFrame;
	float frames;

	public void Start ()
	{
		frames = Time.frameCount;
		apresentacaoPanel.SetActive (true);
		tituloPanel.SetActive (false);
		menuPanel.SetActive (false);
	}

	public void Update ()
	{
		if (estado == 0 && Time.frameCount - frames > limiteApresentacaoFrame) {
			apresentacaoPanel.SetActive (false);
			tituloPanel.SetActive (true);
			estado = 1;
		} else if (estado == 1 & Time.frameCount - frames > limiteTituloFrame) {
			tituloPanel.SetActive (false);
			menuPanel.SetActive (true);
		}
	}

	public void iniciarJogo ()
	{
		ControllerScene.getInstance ().runCutscene (0, "LevelOneScene", "Iniciar Jogo");
	}

	public void chamarCreditos ()
	{
		SceneManager.LoadScene ("Creditos");
	}

	public void quit ()
	{
		Application.Quit ();
	}
}
