using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] 
    private string NextLevel;
    

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SoundManager.PlaySound("Win");
            SceneManager.LoadScene(NextLevel);
        }
    }
}
