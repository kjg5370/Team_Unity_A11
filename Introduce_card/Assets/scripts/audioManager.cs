using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public static audioManager i;

    public AudioClip bgmusic;
    public AudioSource audioSource;

    private void Awake()
    {
        i = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = bgmusic;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
