using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class ExitToMainMenu : MonoBehaviour {

	public Canvas quitMenu;
	public Button startText;
	public Button exitText;

	// Use this for initialization
	void Start () 
	{

		quitMenu = quitMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		quitMenu.enabled = false;  
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

	}

	public void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			quitMenu.enabled = true;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;

		} 
	
	
	}


	public void ExitPress()
	{
		quitMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;

	}

	public void NoPress()
	{
		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void StartLevel ()
	{
		SceneManager.LoadScene ("Scene1");
	}

	public void ExitToUI()
	{
		SceneManager.LoadScene ("SceneUI");
	}
}