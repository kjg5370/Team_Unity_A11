using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class gameManager : MonoBehaviour
{
    public Text timeTxt;
    public GameObject card;
    public static gameManager I;
    public GameObject firstCard;
    public GameObject secondCard;
    public GameObject endTxtBox;
    public GameObject nameTxt;
    public AudioClip match;
    public AudioSource audioSource;
    public GameObject endPanel;

    public Text maxScoreTxt;
    public Text remainTimeTxt;
    public Text matchScoreTxt;
    public Text matchCount;

    private Animator animator;
    float maxScore = 0f;
    int checkMatched = 0;
    int count = 0;

    void Awake()
    {
        I = this;
    }

    float time = 60.0f;

    // Start is called before the first frame update
    void Start()
    {
        int[] cardImg = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };

        cardImg = cardImg.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        animator = timeTxt.GetComponent<Animator>();

        for (int i = 0; i < 16; i ++)
        {
            GameObject newCard = Instantiate(card);
            //newcard를 cards 안으로 옮김
            newCard.transform.parent = GameObject.Find("cards").transform;

            float x = (i / 4) * 1.4f -2.1f;
            float y = (i % 4) * 1.4f -3.0f;
            newCard.transform.position = new Vector3(x, y, 0);

            string imgName = "img" + cardImg[i].ToString();
            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(imgName);
        }

        Time.timeScale = 1.0f;


    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        if (time <= 0.0f)
        {
            time = 0;
            GameEnd();
        }
        if (time <= 10.0f)
        {
            audioManager.i.audioSource.pitch = 1.1f;
        }
        matchCount.text = count.ToString();
    }

    public void isMatched()
    {
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        if (firstCardImage == secondCardImage)
        {
            audioSource.PlayOneShot(match);
            firstCard.GetComponent<card>().destroyCard();
            secondCard.GetComponent<card>().destroyCard();

            checkMatched += 1;

            int cardsLeft = GameObject.Find("cards").transform.childCount;
            if (cardsLeft == 2)
            {
                GameEnd();
            }
        }
        else
        {
            time -= 3.0f;
            animator.SetTrigger("isMinus");
            firstCard.GetComponent<card>().closeCard();
            secondCard.GetComponent<card>().closeCard();
        }

        firstCard = null;
        secondCard = null;
        count += 1;
    }

    void GameEnd()
    {
        maxScore = (time / 15f + checkMatched) * 100;
        remainTimeTxt.text = time.ToString("N2");
        matchScoreTxt.text = checkMatched.ToString();
        maxScoreTxt.text = maxScore.ToString("N2");
        endPanel.SetActive(true);
        Time.timeScale = 0.0f;
    }


}
