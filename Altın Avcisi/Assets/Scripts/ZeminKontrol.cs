using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeminKontrol : MonoBehaviour
{
   public OyunKontrol oyunK;
    public void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("dusman"))
        {
            Destroy(c.gameObject);
        }
        else if (c.gameObject.CompareTag("Player"))
        {
            oyunK.oyunAktif = false;
        }
    }
}
