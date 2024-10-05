using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader: MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadScene (int levelIndex)
    {
     StartCoroutine(LoadSceneAsynchronously(levelIndex));
     
    }
    IEnumerator LoadSceneAsynchronously (int levelIndex)
    {
       AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
       while (!operation.isDone)
       {
          Debug.Log(operation.progress);
          yield return null; 
       }
    }
}
