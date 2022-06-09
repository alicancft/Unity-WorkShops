using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OyunKontrol : MonoBehaviour
{
    public TextMeshProUGUI altinSayisiText;
    public bool oyunAktif = true;

    public int altinSayisi;

    public void AltinArttir()
    {
        altinSayisi += 1;
        altinSayisiText.text = "" + altinSayisi;
    }
}