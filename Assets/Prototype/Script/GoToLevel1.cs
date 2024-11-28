using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToLevel1 : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Player"))
        {
            SceneTransition.instance.NextLevel(2);

            Audio.Instance.musicSource.Stop();
            Audio.Instance.PlayMusic("NormalTheme");
            ChangeMap.GoToNewMap.ResetPlayerPosition();
            Floor.instance.Plus1Floor();
          
            
        }
    }
}
