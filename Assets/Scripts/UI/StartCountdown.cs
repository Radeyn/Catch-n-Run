using UnityEngine;
using TMPro;
using System.Collections;
public class StartCountdown : MonoBehaviour
{

    public TextMeshProUGUI countdownText;
    public GameObject countdown;
    private Animator animator;
    [SerializeField] SpawnScript spawnScript;

    void Start()
    {
        animator = GetComponent<Animator>();
        
        StartCoroutine(StartCountdownRoutine());

    }


    void Update()
    {

    }

    public IEnumerator StartCountdownRoutine()
    {
        Time.timeScale = 1.0f;
        countdown.gameObject.SetActive(true);
        StartCoroutine(spawnScript.SpawnObjects());


        for (int i = 3; i > 0; i--)
        {
            animator.SetTrigger("COUNTDOWN");
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        countdown.gameObject.SetActive(false);

    }
}
