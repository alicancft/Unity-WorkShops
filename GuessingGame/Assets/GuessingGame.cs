using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuessingGame : MonoBehaviour
{
    private int minSayi = 1;
    private int maxSayi = 100;
    private int tahmin;
    private bool oyunBasladiMi = false;
    private bool oyunBittiMi = false;
    void Start()
    {
        print("Benimle oyun oynamak ister misin? (E/H)");
    }
    void Update()
    {
        if (!oyunBasladiMi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                print("Harika! Aklından 1-100 arasında bir sayı tut ve Enter tuşuna bas!");
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                print("Sen bilirsin!");
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                Kontrol();
                oyunBasladiMi = true;
            }
        }
        else if (!oyunBittiMi)
        {

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                minSayi = tahmin;
                Kontrol();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                maxSayi = tahmin;
                Kontrol();
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                print("Yaşasın, aklındaki sayıyı buldum!");
                oyunBittiMi = true;
            }
        }
    }

    void Kontrol()
    {
        tahmin = (minSayi + maxSayi) / 2;
        print("Aklından tuttuğun sayı "+tahmin+" mi? Daha büyük ise yukarı, daha küçük ise aşağı yön tuşuna bas! Doğruysa boşluk tuşuna bas!");
    }
}
