using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    string nextScene;

    public string spawnPoint;

    void Start()
    {
        if (gameObject.name == "ToSingleZone")
            nextScene = "SelectShop_Single";
        else if(gameObject.name == "ToMultiZone")
            nextScene = "SelectShop_Multi";
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
