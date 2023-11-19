using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Story : MonoBehaviour {

	void OnEnable() 
		{
		// Only specifying the scene transation
		SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
	}

}
