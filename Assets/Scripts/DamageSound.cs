//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.Audio;

//public class DamageSound : MonoBehaviour
//{
//    private EnemyCollision enemyCollision;
//    private Player player;
//    public AudioSource audioSource;
//    public AudioClip damageEffect;
//    private void Start()
//    {
//        enemyCollision = GetComponent<EnemyCollision>();
//        audioSource = GetComponent<AudioSource>();
//        player = FindAnyObjectByType<Player>();
//    }
//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Player"))
//        {

//            audioSource.Play();


//        }
//    }
     

//}
