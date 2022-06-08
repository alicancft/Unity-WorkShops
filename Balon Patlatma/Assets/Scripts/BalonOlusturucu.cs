using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalonOlusturucu : MonoBehaviour
{
    public GameObject balon; // balon objesini tanımladık
    float balonOlusturmaSuresi = 1f;
    float zamanSayaci = 0f;
    OyunKontrolcu okScripti;

    // Start is called before the first frame update
    void Start()
    {
        okScripti = this.gameObject.GetComponent<OyunKontrolcu>();
    }

    // Update is called once per frame
    void Update()
    {
        zamanSayaci -= Time.deltaTime;
        int katSayi = (int)(okScripti.zamanSayaci / 10) - 6;
        katSayi *= -1;
        if (zamanSayaci < 0 && okScripti.zamanSayaci>0)
        {
            GameObject go = Instantiate(balon, new Vector2(Random.Range(-2.75f, 2.75f), -6f),
                Quaternion.identity); //balon oluşturma
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Random.Range(30f*katSayi, 80f*katSayi))); //yukarı hareketi için hızları
            zamanSayaci = balonOlusturmaSuresi;
        }
    }
}