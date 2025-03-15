using UnityEngine;
using TMPro;
using System.Collections;
public class StartCountdown : MonoBehaviour
{

    public TextMeshProUGUI countdownText;
    public GameObject countdown;
    private Animator animator;
    public SpawnScript spawnScript;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(StartCountdownRoutine());
        spawnScript = FindAnyObjectByType<SpawnScript>();

    }


    void Update()
    {

    }

    public IEnumerator StartCountdownRoutine()
    {
        Time.timeScale = 1.0f;
        countdown.gameObject.SetActive(true);
        StartCoroutine(spawnScript.DelayedStart());


        for (int i = 3; i > 0; i--)
        {
            animator.SetTrigger("COUNTDOWN");
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        countdown.gameObject.SetActive(false);

    }
}
