using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrintCurrentScene : MonoBehaviour {

    Text t;
    string SceneName;

    private void Start()
    {
        t = GetComponent<Text>();
        SceneName = SceneManager.GetActiveScene().name;
        t.text += SceneName;
        
    }

}
