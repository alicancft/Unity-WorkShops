using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//kütüphane eklemek gerekiyor başlatmak için.

public class Buton : MonoBehaviour
{
    public void YenidenBasla()
    {
        SceneManager.LoadScene("SampleScene");//butona basında samplescene sahnesi en baştan başlatmak için
    }
}
