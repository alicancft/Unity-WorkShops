using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TopKontrol : MonoBehaviour
{
    public UnityEngine.UI.Button btn; //buton ekleme.
    public TextMeshProUGUI zaman, can, durum;//text leri ekleme.
    private Rigidbody rb; //rigidbody ulaşmak için eklenti.
    float zamanSayaci = 100;
    int canSayaci = 5;
    bool oyunDevam = true;
    bool oyunTamam = false;
    public float Hiz = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        can.text = canSayaci + "";//can sayısı eknranda gözüksün diye
        rb = GetComponent<Rigidbody>();//rigidbody companentine ulaşmak için.
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunDevam && !oyunTamam)//oyun devam ediyor ve bitmemişse
        {
            zamanSayaci -= Time.deltaTime;//zamanı 1 er saniye azaltır.
            zaman.text = (int)zamanSayaci + "";//floatı int e çevirme
        }
        else if (!oyunTamam) //oyun tamam değilse       ?
        {
            durum.text = "Oyun Tamamlanamadı.";
            btn.gameObject.SetActive(true);
        }

        if (zamanSayaci < 0)//zaman 0 olana kadar devam
        {
            oyunDevam = false;
        }
    }

    void FixedUpdate()
    {
        if (oyunDevam && !oyunTamam)//oyun devam ediyor bitmemişse
        {
            float yatay = Input.GetAxis("Horizontal");//yön tuşlarını atama
            float dikey = Input.GetAxis("Vertical");//yön tuşları atama
            Vector3 kuvvet = new Vector3(dikey, 0, -yatay);//eksen hareketi
            rb.AddForce(kuvvet * Hiz);//kuvvet sonucunu rigidbody ekleme.
        }
        else
        {
            rb.velocity = Vector3.zero; //hareketi durdurur.
            rb.angularVelocity = Vector3.zero; //dönme hareketini durdurur.
        }
    }

    void OnCollisionEnter(Collision cls)//çarpışma algılamak
    {
        string objIsmi = cls.gameObject.name;//her çarptığı objenin ismi
        if (objIsmi.Equals("Bitis"))//sona gelmişse
        {
            oyunTamam = true;
            durum.text = "Oyun Tamamlandı.";//ekrana yazcak
            btn.gameObject.SetActive(true);//buton aktif olcak yeniden oynayabilmek için.
        }
        else if (!objIsmi.Equals("LabirentZemini") && !objIsmi.Equals("Zemin"))//başlangıçta zemine çarpıyor can azalmaması için.
        {
            canSayaci -= 1;
            can.text = canSayaci + "";
            if (canSayaci == 0)//can 0 olunca
            {
                oyunDevam = false;
                durum.text = "Oyun Tamamlanamadı.";//ekrana yazcak
                btn.gameObject.SetActive(true);
            }
        }
    }
}