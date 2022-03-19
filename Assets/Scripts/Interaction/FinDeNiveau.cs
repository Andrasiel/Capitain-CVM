using UnityEngine;
using UnityEngine.SceneManagement;

public class FinDeNiveau : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Félicitation, le niveau est terminé.");
            GameManager.Instance.SaveData();

            if(SceneManager.GetActiveScene().name == "Level3")
            {
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                GameManager.Instance.PlayerData.AjouterNiveau();
                GameManager.Instance.SaveData();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }
            
            
        }
    }
}
