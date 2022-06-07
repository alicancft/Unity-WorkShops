using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TopKontrol : MonoBehaviour
{
    public UnityEngine.UI.Button btn;
    public TextMeshProUGUI zaman,can,durum;
    private Rigidbody rb;
    float zamanSayaci = 100;
    int canSayaci = 3;
    bool oyunDevam = true;
    bool oyunTamam = false;
    public float Hiz =1.5f;
    // Start is called before the first frame update
    void Start()
    {
        can.text = canSayaci + "";
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunDevam && !oyunTamam)
        {
            zamanSayaci -= Time.deltaTime;
            zaman.text = (int)zamanSayaci + "";
        }
        else if (!oyunTamam)
        {
            durum.text = "Oyun Tamamlanamadı.";
            btn.gameObject.SetActive(true);
        }
        if (zamanSayaci < 0)
            {
                oyunDevam = false;
            }
        
    }

    void FixedUpdate()
    {
        if (oyunDevam && !oyunTamam)
        {
            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");
            Vector3 kuvvet = new Vector3(dikey, 0, -yatay);
            rb.AddForce(kuvvet * Hiz);
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    void OnCollisionEnter(Collision cls)
    {
        string objIsmi = cls.gameObject.name;
        if (objIsmi.Equals("Bitis"))
        {
            oyunTamam = true;
            durum.text = "Oyun Tamamlandı.";
            btn.gameObject.SetActive(true);
        }
        else if(!objIsmi.Equals("LabirentZemini") && !objIsmi.Equals("Zemin"))
        {
            canSayaci -= 1;
            can.text = canSayaci + "";
            if (canSayaci==0)
            {
                oyunDevam = false;
                durum.text = "Oyun Tamamlanamadı.";
                btn.gameObject.SetActive(true);
            }
        }
    }
}
