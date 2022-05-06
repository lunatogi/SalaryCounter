using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Maas : MonoBehaviour
{
    public GameObject pnl_Maas;

    public InputField payDay;
    public InputField payValue;
    // Start is called before the first frame update
    void Start()
    {
        payDay.text = PlayerPrefs.GetInt("PayDay", 1).ToString();
        payValue.text = PlayerPrefs.GetFloat("Maas", 0).ToString();
        pnl_Maas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveMaas()
    {
        int payDayInt = Int32.Parse(payDay.text);
        if (payDayInt > 0 && payDayInt < 29)
        {
            PlayerPrefs.SetInt("PayDay", Int32.Parse(payDay.text));
            PlayerPrefs.SetFloat("Maas", float.Parse(payValue.text));
            Debug.Log("Maaş verisi kaydedildi");
        }
        else
        {
            Debug.Log("Maaş günü her ayda olan bir ayın günü olmalı");
        }
    }
}
