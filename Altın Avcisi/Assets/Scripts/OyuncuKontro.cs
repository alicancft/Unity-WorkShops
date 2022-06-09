using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuKontro : MonoBehaviour
{
    public OyunKontrol oyunK;
    private float hiz = 10f;

    void Update()
    {
        if (oyunK.oyunAktif)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            x *= Time.deltaTime * hiz;
            y *= Time.deltaTime * hiz;
            transform.Translate(x, 0f, y);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Vector3 jumpOffSet = new Vector3(0, transform.position.y+3f, 0);
                gameObject.GetComponent<Rigidbody>().AddForce(jumpOffSet);
            }
        }
    }
    
    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag.Equals("altin"))
        {
            oyunK.AltinArttir();
            Destroy(c.gameObject);
        }
        else if (c.gameObject.tag.Equals("dusman"))
        {
            oyunK.oyunAktif = false;
        }
        else if (c.gameObject.CompareTag("Finish") && oyunK.altinSayisi==3)
        {
            oyunK.oyunAktif = false;
        }
    }
}