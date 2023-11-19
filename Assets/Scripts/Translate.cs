using UnityEngine;
using System.Collections;

public class Translate : MonoBehaviour {

    [Tooltip("This is the object that the script's game object will translate on")]
	public Transform target; // the object to rotate around
    [Tooltip("This is the speed at which the object translates")]
	public int speed; // the speed of translation
	
	void Start() {
		if (target == null) 
		{
			target = this.gameObject.transform;
			Debug.Log ("Translate on target not specified. Defaulting to this GameObject");
		}
	}

	void Update () {
        // Move the object forward along its z axis 1 unit/second.
        transform.Translate(target.transform.forward * Time.deltaTime);
    }
}
