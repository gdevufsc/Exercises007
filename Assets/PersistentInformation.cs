using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentInformation : MonoBehaviour {

    public float value;

	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
}
