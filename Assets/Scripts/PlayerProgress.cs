using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    private int money;
    public TMP_Text moneyText;
    public int Money => money;
    private void Start()
    {
        money = PlayerPrefs.GetInt("Money");
        ChangeUI();
    }
    public bool TryChangeMoney(int change)
    {
        if(change+money < 0)
        {
            return false;
        }
        else
        {
            money += change;
            PlayerPrefs.SetInt("Money",money);
            ChangeUI();
            return true;
        }
    }
    private void ChangeUI()
    {
        moneyText.text = $"You Got{money}";
    }

}
