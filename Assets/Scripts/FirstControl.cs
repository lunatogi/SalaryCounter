using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstControl : MonoBehaviour
{

    public GameObject[] genelGiderSprites;
    public GameObject[] genelGiderBtnAdd;
    public GameObject[] genelGiderBtnSubstract;
    public GameObject[] genelGiderHarcama;
    public GameObject[] genelGiderTutar;
    public InputField[] harcamaText;
    public InputField[] tutarText;

    public InputField payDay;       //Maaş günü
    public InputField payValue;     //Maaş tutarı

    int genelGiderNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddColumn(int index)
    {
        Debug.Log(index);

        PlayerPrefs.SetInt("GenelGiderNumber", index);

        genelGiderSprites[index].SetActive(true);
        genelGiderBtnSubstract[index].SetActive(true);
        genelGiderHarcama[index].SetActive(true);
        genelGiderTutar[index].SetActive(true);
        genelGiderBtnAdd[index].SetActive(false);
        if (index < 6)
            genelGiderBtnAdd[index + 1].SetActive(true);
        if (index > 0)
            genelGiderBtnSubstract[index - 1].SetActive(false);
    }

    public void SubstractColumn(int index)
    {
        PlayerPrefs.SetInt("GenelGiderNumber", index - 1);

        genelGiderSprites[index].SetActive(false);
        genelGiderBtnSubstract[index].SetActive(false);
        genelGiderHarcama[index].SetActive(false);
        genelGiderTutar[index].SetActive(false);
        genelGiderBtnAdd[index].SetActive(true);
        if (index < 6)
            genelGiderBtnAdd[index + 1].SetActive(false);
        if (index > 0)
            genelGiderBtnSubstract[index - 1].SetActive(true);
    }

    public void FirstSave()
    {
        float allGider = 0;
        genelGiderNum = PlayerPrefs.GetInt("GenelGiderNumber", -1);
        for (int y = 0; y <= genelGiderNum + 1; y++)
        {
            string txt = harcamaText[y].text;
            PlayerPrefs.SetString("ggSt" + y, txt);
            float tutar = float.Parse(tutarText[y].text);
            PlayerPrefs.SetFloat("ggFlt" + y, tutar);
            //Debug.Log(PlayerPrefs.GetString("ggSt"+y, "d"))
            allGider += tutar;
        }
        PlayerPrefs.SetFloat("AllGider", allGider);
        FirstMaasSave();
    }

    public void FirstMaasSave()
    {
        PlayerPrefs.SetFloat("Maas", float.Parse(payValue.text));
        PlayerPrefs.SetInt("PayDay", Int32.Parse(payDay.text));
        Debug.Log("payday::::::::: " + PlayerPrefs.GetInt("PayDay").ToString());
        if (Int32.Parse(payDay.text) > 31 || Int32.Parse(payDay.text) < 1)
        {
            Debug.Log("Maaş günü bir ayın günü olmalı");
        }
        else
        {
            //PlayerPrefs.SetInt("Maas", Int32.Parse(payValue.text));
            //PlayerPrefs.SetInt("PayDay", Int32.Parse(payDay.text));
        }
        Camera.main.SendMessage("FirstSetup", SendMessageOptions.DontRequireReceiver);
    }

    
}
