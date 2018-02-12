using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public void LoadTheScene01()
    {
        SceneManager.LoadScene("Scene01");
    }

    public void LoadTheScene02()
    {
        SceneManager.LoadScene("Scene02");
    }

}
