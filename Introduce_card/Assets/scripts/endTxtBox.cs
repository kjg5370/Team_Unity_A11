using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class endTxt : MonoBehaviour
{
    public void retryGame()
    {
        SceneManager.LoadScene("MainScene");
        AudioListener.pause = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
