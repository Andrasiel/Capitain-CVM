using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PannelCollectables : MonoBehaviour
{

    public List<GameObject> containersCollectable;
    // Start is called before the first frame update
    void Start()
    {        


        foreach(GameObject container in containersCollectable)
        {
            foreach (string collectable in GameManager.Instance.PlayerData.ListeCollectable)
            {
                if (collectable.Equals(container.name))
                {
                    container.SetActive(true);
                }
            }
                    
        }
        
    }

}
