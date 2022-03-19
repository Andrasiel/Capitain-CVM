using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string collectableName;
    // Start is called before the first frame update
    void Start()
    {
        if(collectableName != null)
        {
            foreach (string collectable in GameManager.Instance.PlayerData.ListeCollectable)
            {
                if (GameManager.Instance.PlayerData.ListeCollectable.Equals(collectableName))
                {
                   Destroy(gameObject);
                }

            }
        }
        else
        {
            collectableName = gameObject.name;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameManager.Instance.PlayerData.AjouterCollectableRammasse(collectableName);
            Destroy(gameObject);
        }
    }
}
