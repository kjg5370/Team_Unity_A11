using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
    
{
    public Animator anim;
    public AudioClip flip;
    public AudioSource audioSource;

    float timeSpan;
    float checkTime;
    bool isWork = false;

    // Start is called before the first frame update
    void Start()
    {
        timeSpan = 0.0f;
        checkTime = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWork)
        {
            timeSpan += Time.deltaTime;
            if (timeSpan >= checkTime && gameManager.I.secondCard == null)
            {

                closeCardInvoke();
                gameManager.I.firstCard = null;
                timeSpan = 0;
            }
        }
    }

    public void openCard()
    {
        audioSource.PlayOneShot(flip);


        anim.SetBool("isOpen", true);
        transform.Find("front").gameObject.SetActive(true);
        transform.Find("back").gameObject.SetActive(false);
        transform.Find("back").gameObject.GetComponent<SpriteRenderer>().color= new Color32(96, 195, 200, 255);

        if (gameManager.I.firstCard == null)
        {
            gameManager.I.firstCard = gameObject;
            isWork = true;
        }
        else
        {
            gameManager.I.secondCard = gameObject;
            gameManager.I.isMatched();
        }
    }


    public void destroyCard()
    {
        Invoke("destroyCardInvoke", 0.5f);
    }

    void destroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void closeCard()
    {
        Invoke("closeCardInvoke", 0.5f);
    }

    void closeCardInvoke()
    {
        anim.SetBool("isOpen", false);
        transform.Find("back").gameObject.SetActive(true);
        transform.Find("front").gameObject.SetActive(false);
        isWork = false;
    }

    
}
