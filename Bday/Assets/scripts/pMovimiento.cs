using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.Events;

public class pMovimiento : MonoBehaviour
{
    public float movSpeed;
    private Vector2 moviteto;
    private Rigidbody2D cuerpo;
    private bool up1, up2, up3, up4;
    private int direccion;
    public bool testing;
    public Animator anim;
    public UnityEvent<Vector3, int> onChange;
    [NonSerialized] public string ultimoCuarto;
    void Start()
    {
        moviteto = new Vector2(0, 0);
        cuerpo = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if (!testing && PlayerPrefs.HasKey("posX"))
            transform.position = new Vector3
            (
                PlayerPrefs.GetFloat("posX"),
                PlayerPrefs.GetFloat("posY"),
                0
            );
    }
    void FixedUpdate()
    {
        if (moviteto.x != 0 && moviteto.y != 0)
            cuerpo.velocity = Time.deltaTime * moviteto / 1.41f;
        else
            cuerpo.velocity = Time.deltaTime * moviteto;
    }
    void Update()
    {
        if (moviteto.x == 0 && moviteto.y == 0)
        {
            onChange.Invoke(new Vector3(0, 0, 0), direccion);
        }
    }
    //raaaaaaaaaaaaaaaaaaaaaaaa
    IEnumerator wow()
    {
        while (true)
        {
            Debug.Log(PlayerPrefs.GetInt("progreso"));
            yield return new WaitForSeconds(1);
        }
    }
    public void arriba()
    {
        if (up1)
        {
            moviteto.y = 0;
            up1 = false;
            anim.Play("atrasNormal");
        }
        else
        {
            direccion = 1;
            onChange.Invoke(transform.position, direccion);
            moviteto.y = movSpeed;
            up1 = true;
            anim.Play("atrasCaminando");
        }
    }
    public void abajo()
    {
        if (up2)
        {
            moviteto.y = 0;
            up2 = false;
            anim.Play("frenteNormal");

        }
        else
        {
            direccion = 2;
            onChange.Invoke(transform.position, direccion);
            moviteto.y = -movSpeed;
            up2 = true;
            anim.Play("frenteCaminando");
        }
    }
    public void izquierda()
    {
        if (up3)
        {
            moviteto.x = 0;
            up3 = false;
            anim.Play("izquierdaNormal");
        }
        else
        {
            direccion = 3;
            onChange.Invoke(transform.position, direccion);
            moviteto.x = -movSpeed;
            up3 = true;
            anim.Play("izquierdaCaminando");
        }
    }
    public void derecha()
    {
        if (up4)
        {
            moviteto.x = 0;
            up4 = false;
            anim.Play("derechaNormal");
        }
        else
        {
            direccion = 4;
            onChange.Invoke(transform.position, direccion);
            moviteto.x = movSpeed;
            up4 = true;
            anim.Play("derechaCaminando");
        }
    }
}