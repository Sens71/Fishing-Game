using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public ShopItem[] throwForce;
    public ShopItem[] catchCapacity;
    private int catchUpgradeIndex;
    private int throwUpgradeIndex;
    public TMP_Text catchUpgrade;
    public TMP_Text throwUpgrade;
    public Hook hook;
    public PlayerProgress playerProgress;

    private void Start()
    {
        catchUpgrade.text = catchCapacity[catchUpgradeIndex].cost.ToString();
        throwUpgrade.text = throwForce[throwUpgradeIndex].cost.ToString();
    }
    public void UpgradeForce()
    {
        if (playerProgress.TryChangeMoney(throwForce[throwUpgradeIndex].cost)&& throwUpgradeIndex < throwForce.Length)
        {
            hook.throwForce = throwForce[throwUpgradeIndex].value;
            throwUpgradeIndex++;
            throwUpgrade.text = throwForce[throwUpgradeIndex].cost.ToString();
        }
    }
    public void UpgradeCapacity()
    {

    }
}
[Serializable]

public class ShopItem
{
    public float value;
    public int cost;
}
