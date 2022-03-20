using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuLevels : MonoBehaviour
{

    List<Button> buttons;
    int nbButtons = 3;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GameManager.Instance.PlayerData.levelProgression);
        buttons = new List<Button>();
        // Créer la liste de boutons selon les composants du menu.
        for (int i = 1; i <= nbButtons; i++)
        {
            Button button = GameObject.Find("ButtonNiv"+i).GetComponent<Button>();
            button.interactable = false;
            buttons.Add(button);
        }

        // Réinitialisation de l'état des boutons.
        for (int i = 0; i < buttons.Count; i++) 
        {
            buttons[i].interactable = false;

        }

        // Activation des boutons selon la progression du joueur.
        for (int i = 0; i <= GameManager.Instance.PlayerData.levelProgression; i++)
        {
            buttons[i].interactable = true;
        }

    }

}
