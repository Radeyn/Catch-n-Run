using UnityEngine;

public class HealthScript : MonoBehaviour
{
    private PlayerStatus _playerStatus;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (_playerStatus != null)
                _playerStatus.Heal(1);
                
            gameObject.SetActive(false);
            
        }
            
        else if (collision.gameObject.CompareTag("Floor"))
        {
            gameObject.SetActive(false);
        }

    }

    public void SetPlayer(PlayerStatus playerStatus)
    {
        _playerStatus = playerStatus;
    }
}
