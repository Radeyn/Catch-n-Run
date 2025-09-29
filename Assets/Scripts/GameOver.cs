using System.Collections;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private Animator firstHeartAnimator;
    private Animator secondHeartAnimator;
    private Animator thirdHeartAnimator;
    private Animator lastHeartAnimator;
    private Player player;

    public GameObject firstHeart;
    public GameObject secondHeart;
    public GameObject thirdHeart;  
    public GameObject lastHeart;
    public GameObject gameOverUI;

    void Start()
    {

        // Kalplerin animator bileşenlerini al
        if (firstHeart) firstHeartAnimator = firstHeart.GetComponent<Animator>();
        if (secondHeart) secondHeartAnimator = secondHeart.GetComponent<Animator>();
        if (thirdHeart) thirdHeartAnimator = thirdHeart.GetComponent<Animator>();
        if (lastHeart) lastHeartAnimator = lastHeart.GetComponent<Animator>();


        // Oyuncuyu bul
        player = FindAnyObjectByType<Player>();
        if (player == null)
        {
            Debug.LogError("Player script not found!");
        }
    }

    private void Update()
    {
        if (!player) return;  // Oyuncu yoksa hata vermemesi için kontrol

        float playerHealth = player.playerHealth;


        if (playerHealth < 4)
        {
            firstHeartAnimator.SetBool("HeartEmpty", true);
        }
        else
        {
            firstHeartAnimator.SetBool("HeartEmpty", false);
        }

        if (playerHealth < 3)
        {
            secondHeartAnimator.SetBool("HeartEmpty", true);
        }
        else
        {
            secondHeartAnimator.SetBool("HeartEmpty", false);
        }
        if (playerHealth < 2)
        {
            thirdHeartAnimator.SetBool("HeartEmpty", true);
        }
        else
        {
            thirdHeartAnimator.SetBool("HeartEmpty", false);
        }
        if (playerHealth < 1)
        {
            lastHeartAnimator.SetBool("HeartEmpty", true);


            StartCoroutine(GameOverSequence());

        }
        else 
        { 
            lastHeartAnimator.SetBool("HeartEmpty", false);
        }
        }

        IEnumerator GameOverSequence()
        {
            

            

            float animTime = lastHeartAnimator.GetCurrentAnimatorStateInfo(0).length;

            yield return new WaitForSecondsRealtime(animTime); //



            Time.timeScale = 0; 
            gameOverUI.SetActive(true); 

        }
    public void ResetAnimation()
    {

        firstHeartAnimator.SetBool("HeartEmpty", false);
        secondHeartAnimator.SetBool("HeartEmpty", false);
        thirdHeartAnimator.SetBool("HeartEmpty", false);
        lastHeartAnimator.SetBool("HeartEmpty", false);
        
    }
}

