using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinManager : MonoBehaviour//Coin iþlemlerinin yapýldýðý sýnýf.
{
    private int coin;
    public Text coinText;

    public int Coins { get => coin; set => coin = value; }
    
   

    public void coinArttýrma(int ArtanCoinMiktari) //Coin arttýrma iþlemlerinin yapýldýðý metod.
    {   
        Coins = ArtanCoinMiktari + Coins;
        coinText.text = "COIN: "+Coins.ToString();
    }
    
}
