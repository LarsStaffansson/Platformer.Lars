using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    [SerializeField] float timeTillLoad = 1f;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("LoadLevel", timeTillLoad);
        }
    }
    void LoadLevel()
    {
        FindFirstObjectByType<ScenePersist>().ResetScenePersist();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }



}
