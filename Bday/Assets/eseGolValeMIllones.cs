using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class eseGolValeMIllones : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerPrefs.SetFloat("posX", 0);
        PlayerPrefs.SetFloat("posY", 0);
        SceneManager.LoadScene("acto2");
    }
}
