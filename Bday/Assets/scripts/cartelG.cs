using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cartelG : MonoBehaviour
{
    public GameObject cartel;
    private Animator cartelAnim;

    void Start()
    {
        cartelAnim = cartel.GetComponent<Animator>();
    }
    public void cartelGuardado()
    {
        cartelAnim.Play("defadeCartel");
    }
}
