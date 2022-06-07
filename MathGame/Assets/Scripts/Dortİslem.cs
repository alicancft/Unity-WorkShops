using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

public class Dortİslem : MonoBehaviour
{
    public TextMeshProUGUI ilkSayi, ikinciSayi, islem, durum;
    int sayi1, sayi2, islemIsareti, islemSonucu;
    [SerializeField] private TMP_InputField sonuc;
    void Start()
    {
        YeniSoru();
    }
    public void CevapKontrol()
    {
        if (int.Parse(sonuc.text) == islemSonucu)
        {
            durum.text = "DOGRU";
        }
        else
        {
            durum.text = "YANLIS";
        }
    }
    public void YeniSoru()
    {
        sayi1 = Random.Range(1, 10);
        sayi2 = Random.Range(1, 10);
        islemIsareti = Random.Range(1, 5);
        switch (islemIsareti)
        {
            case 1:
                islem.text = "+";
                islemSonucu = sayi1 + sayi2;
                break;
            case 2:
                islem.text = "-";
                islemSonucu = sayi1 - sayi2;
                break;
            case 3:
                islem.text = "*";
                islemSonucu = sayi1 * sayi2;
                break;
            case 4:
                islem.text = "/";
                islemSonucu = sayi1 / sayi2;
                break;
        }

        ilkSayi.text = sayi1 + "";
        ikinciSayi.text = sayi2 + "";
    }
    public void YeniSoruButtonAction()
    {
        sonuc.text = "";
        durum.text = "";
        YeniSoru();
    }
}