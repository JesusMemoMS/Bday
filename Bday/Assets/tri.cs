using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tri : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        SceneManager.LoadScene(3);
    }
}
