using UnityEngine;

public class ButtonControler : MonoBehaviour {
	public void Help()
	{
		Application.LoadLevel ("Help");
	}

	public void Play()
	{
		Application.LoadLevel ("Play");
	}

	public void Exit()
	{

		Application.Quit();
	}
}
