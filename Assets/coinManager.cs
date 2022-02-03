using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinManager : MonoBehaviour//Coin i�lemlerinin yap�ld��� s�n�f.
{
    private int coin;
    public Text coinText;

    public int Coins { get => coin; set => coin = value; }
    
   

    public void coinArtt�rma(int ArtanCoinMiktari) //Coin artt�rma i�lemlerinin yap�ld��� metod.
    {   
        Coins = ArtanCoinMiktari + Coins;
        coinText.text = "COIN: "+Coins.ToString();
    }
    
}
