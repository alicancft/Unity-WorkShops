using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KupAnimasyonKontrol : MonoBehaviour
{
    float sayac = 2f;

    void Update()
    {
        sayac -= Time.deltaTime;
        if (sayac < 0f)
        {
            GetComponent<Animator>().Play(0);
            sayac = Random.Range(4f, 6f);
        }
    }
}