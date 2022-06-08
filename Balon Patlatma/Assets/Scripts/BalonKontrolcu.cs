using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalonKontrolcu : MonoBehaviour
{
    public OyunKontrolcu oyunKontrolScripti;
    public void Start()
    {
        oyunKontrolScripti = GameObject.Find("_Scripts").GetComponent<OyunKontrolcu>();
    }
    public GameObject patlama;
    public void OnMouseDown()
    {
        GameObject go = Instantiate(patlama, transform.position, transform.rotation);//patlattığın noktada patlama animasyonu oluşturma 
        Destroy(this.gameObject);//balon yoketme
        Destroy(go, 0.417f);//patlama animasyonunu gitmesi için
        oyunKontrolScripti.BalonEkle();
    }
}