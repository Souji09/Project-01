using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterNewMap : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {

            if (other.tag == "Player")
            {
                Floor.instance.FightFloor += 1;
                ChangeMap.GoToNewMap.DisPlayMap();
                Destroy(this);
            }
        }
    }
}
