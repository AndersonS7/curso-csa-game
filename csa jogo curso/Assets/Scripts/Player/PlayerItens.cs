using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItens : MonoBehaviour
{
    [Header("Amounts")]
    public int totalWood;
    public int carrots;
    public float currentWater;

    [Header("Limits")]
    public float waterLimit = 20;
    public float carrotsLimit = 10;
    public float woodLimit = 5;

    public void WaterLimit(float water)
    {
        if (currentWater < waterLimit)
        {
            currentWater += water;
        }
    }
}