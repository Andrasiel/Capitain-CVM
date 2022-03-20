using UnityEngine;
using UnityEngine.SceneManagement;

public class FinDeNiveau : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.SaveData();

            if(SceneManager.GetActiveScene().name == "Level3")
            {
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                GameManager.Instance.PlayerData.UpdateLevelProgression();
                GameManager.Instance.SaveData();
                //Utilisation du Build Setting pour faire l'enchainement des niveaux https://docs.unity3d.com/Manual/BuildSettings.html 
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }
            
            
        }
    }
}
