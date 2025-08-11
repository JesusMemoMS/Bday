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
    private bool up1, up2, up3, up4, collision;
    private Vector3 posicionAnterior;
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
    public void restartMovement()
    {
        Debug.Log("posis");
        cuerpo.constraints = RigidbodyConstraints2D.None;
        cuerpo.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    public void stopp()
    {
        cuerpo.constraints = RigidbodyConstraints2D.FreezePosition;
        moviteto = Vector2.zero;
        anim.SetBool("idle", true);
        up1 = false;
        up2 = false;
        up3 = false;
        up4 = false;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        collision = true;
    }
    void OnCollisionExit2D(Collision2D other)
    {
        collision = false;
    }
    void FixedUpdate()
    {
        if (moviteto.x != 0 && moviteto.y != 0 && !collision)
            cuerpo.velocity = Time.deltaTime * moviteto / 1.41f;
        else
            cuerpo.velocity = Time.deltaTime * moviteto;
        if (Vector3.Distance(transform.position, posicionAnterior) < 0.01)
        {
            onChange.Invoke(Vector3.zero, 0);
        }
        else
            posicionAnterior = transform.position;
    }
    public void arriba()
    {
        if (up1)
        {
            moviteto.y = 0;
            up1 = false;
            anim.SetBool("idle", true);            
        }
        else
        {
            moviteto.y = movSpeed;
            up1 = true;
            anim.SetBool("idle", false);
            anim.Play("atrasCaminando");
            onChange.Invoke(transform.position, 1);
        }
    }
    public void abajo()
    {
        if (up2)
        {
            moviteto.y = 0;
            up2 = false;
            anim.SetBool("idle", true);

        }
        else
        {
            moviteto.y = -movSpeed;
            up2 = true;
            anim.SetBool("idle", false);
            anim.Play("frenteCaminando");
            onChange.Invoke(transform.position, 2);
        }
    }
    public void izquierda()
    {
        if (up3)
        {
            moviteto.x = 0;
            up3 = false;
            anim.SetBool("idle", true);
        }
        else
        {
            moviteto.x = -movSpeed;
            up3 = true;
            anim.SetBool("idle", false);
            anim.Play("izquierdaCaminando");
            onChange.Invoke(transform.position, 3);
        }
    }
    public void derecha()
    {
        if (up4)
        {
            moviteto.x = 0;
            up4 = false;
            anim.SetBool("idle", true);
        }
        else
        {
            moviteto.x = movSpeed;
            up4 = true;
            anim.SetBool("idle", false);
            anim.Play("derechaCaminando");
            onChange.Invoke(transform.position, 4);
        }
    }
}