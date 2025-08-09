using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class salirMenú : MonoBehaviour
{
    // Start is called before the first frame update
    public void SalteDeAqui()
    {
        SceneManager.LoadScene("portada"); 
    }
}