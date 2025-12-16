using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour
{
   public void OnClick()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }
}
