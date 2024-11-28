using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition instance;
     [SerializeField] public Animator TransitionAnim;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public void NextLevel(int sceneIndex)
    {
        StartCoroutine(Load(sceneIndex));
    }

    private IEnumerator Load(int sceneIndex)
    {
        
        TransitionAnim.SetTrigger("Start");
        
        yield return new WaitForSeconds(2f);
        
        SceneManager.LoadSceneAsync(sceneIndex);
           
        yield return new WaitForSeconds(0.7f);
        TransitionAnim.SetTrigger("End");

    }
}
