using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float delay = 3f;

    int currentSceneIndex;

    private void Start() 
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnCollisionEnter(Collision other) {

        switch (other.gameObject.tag){
            case "Friendly":
                break;
            case "Obstacle":
                StartHitSequence();
                break;
            default:
                break;
        }

       
    }

    void StartHitSequence()
    {
        GetComponent<Movement>().enabled = false;
        StartCoroutine(LoadScene(currentSceneIndex));
    }

    IEnumerator LoadScene(int sceneIndex)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex);
    }
  
}
