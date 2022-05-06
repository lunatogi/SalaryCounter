using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Timeline;

public class Calculation : MonoBehaviour
{
    float allGider;
    int payDay;
    float salary;
    int daysLeft;
    float moneyLeft;
    float dailyMoney;
    int calculated;
    int currMonth;

    public Text moneyLeftTxt;
    public Text daysLeftTxt;
    // Start is called before the first frame update
    void Start()
    {
        UpdateMoney();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMoney();
    }

    public void UpdateMoney()
    {
        salary = PlayerPrefs.GetFloat("Maas", 0);
        allGider = PlayerPrefs.GetFloat("AllGider", 0);
        moneyLeft = PlayerPrefs.GetFloat("KalanPara", 0);
        payDay = PlayerPrefs.GetInt("PayDay", 1);
        currMonth = PlayerPrefs.GetInt("CurrMonth", 1);

        int numOfDays = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
        int today = DateTime.Today.Day;

        calculated = PlayerPrefs.GetInt("Hesaplandı", 0);

        if (today < payDay)
        {
            daysLeft = payDay - today;
        }
        else
        {
            daysLeft = numOfDays - today + 1;
            daysLeft += payDay;
        }

        if (currMonth != DateTime.Today.Month)
        {
            calculated = 0;
            currMonth = DateTime.Today.Month;
            PlayerPrefs.SetInt("CurrMonth", currMonth);
            PlayerPrefs.SetInt("Hesaplandı", calculated);
        }

        if(payDay == today && calculated == 0)
        {
            FirstSetup();
            currMonth = DateTime.Today.Month;
            PlayerPrefs.SetInt("CurrMonth", currMonth);
            calculated = 1;
            PlayerPrefs.SetInt("Hesaplandı", calculated);
        }

        //PlayerPrefs.SetFloat()

        dailyMoney = moneyLeft / daysLeft;

        Debug.Log("allgider : " + allGider);

        Debug.Log("moneyleft : " + moneyLeft);

        Debug.Log("daysleft : " + daysLeft);

        Debug.Log("daily : " + dailyMoney);

        moneyLeftTxt.text = dailyMoney.ToString("00.00");
        daysLeftTxt.text = daysLeft.ToString();
        
    }

    public void FirstSetup()
    {
        salary = PlayerPrefs.GetFloat("Maas", 0);
        allGider = PlayerPrefs.GetFloat("AllGider", 0);
        moneyLeft = salary - allGider;
        PlayerPrefs.SetFloat("KalanPara", moneyLeft);
    }
}
