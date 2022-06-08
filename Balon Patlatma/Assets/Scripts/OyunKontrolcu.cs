using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OyunKontrolcu : MonoBehaviour
{
    public GameObject patlama;
    public TextMeshProUGUI zamanText, balonText;
    public float zamanSayaci = 60f;
    int patlayanBalon = 0;
    // Start is called before the first frame update
    void Start()
    {
        balonText.text = "Balon : " + patlayanBalon;
    }

    // Update is called once per frame
    void Update()
    {
        if (zamanSayaci > 0)
        {
            zamanSayaci -= Time.deltaTime;
            zamanText.text = "Süre : " + (int)zamanSayaci;
        }
        else
        {
            GameObject[] go = GameObject.FindGameObjectsWithTag("balon");
            for (int i = 0; i < go.Length; i++)
            {
                Instantiate(patlama, go[i].transform.position, transform.rotation);
                Destroy(go[i]);
            }
        }
    }

    public void BalonEkle()
    {
        patlayanBalon += 1;
        balonText.text = "Balon : " + patlayanBalon;
    }
}
