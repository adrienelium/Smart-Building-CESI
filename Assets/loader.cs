using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void runMainScene()
    {
        SceneManager.LoadScene("Scene01",LoadSceneMode.Single);
        Debug.Log("Run scene");
    }

    public void exit()
    {
        Application.Quit();
        Debug.Log("Exit scene");
    }
}
