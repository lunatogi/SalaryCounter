using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class GenelGider : MonoBehaviour
{
    public GameObject pnl_GenelGider;

    public GameObject[] genelGiderSprites;
    public GameObject[] genelGiderBtnAdd;
    public GameObject[] genelGiderBtnSubstract;
    public GameObject[] genelGiderHarcama;
    public GameObject[] genelGiderTutar;
    public InputField[] harcamaText;
    public InputField[] tutarText;

    int genelGiderNum;
    // Start is called before the first frame update
    void Start()
    {
        SortGenelGider();
    }

    public void SortGenelGider()
    {
        genelGiderNum = PlayerPrefs.GetInt("GenelGiderNumber", -1);
        if (genelGiderNum > -1)
        {
            for (int k = 0; k <= genelGiderNum; k++)
            {
                AddColumn(k);
            }
        }

        for(int h = 0; h <= genelGiderNum+1; h++)
        {
            harcamaText[h].text = PlayerPrefs.GetString("ggSt" + h, "sss");
            tutarText[h].text = PlayerPrefs.GetFloat("ggFlt" + h, 0).ToString();
        }

        pnl_GenelGider.SetActive(false);
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
        if(index < 6)
            genelGiderBtnAdd[index + 1].SetActive(true);
        if (index > 0)
            genelGiderBtnSubstract[index-1].SetActive(false);
    }

    public void SubstractColumn(int index)
    {
        PlayerPrefs.SetInt("GenelGiderNumber", index-1);

        genelGiderSprites[index].SetActive(false);
        genelGiderBtnSubstract[index].SetActive(false);
        genelGiderHarcama[index].SetActive(false);
        genelGiderTutar[index].SetActive(false);
        genelGiderBtnAdd[index].SetActive(true);
        if(index < 6)
            genelGiderBtnAdd[index + 1].SetActive(false);
        if (index > 0)
            genelGiderBtnSubstract[index-1].SetActive(true);
    }

    public void Save()
    {
        float allGider = 0;
        genelGiderNum = PlayerPrefs.GetInt("GenelGiderNumber", -1);
        for(int y = 0; y <= genelGiderNum+1; y++)
        {
            string txt = harcamaText[y].text;
            PlayerPrefs.SetString("ggSt" + y, txt);
            float tutar = float.Parse(tutarText[y].text);
            PlayerPrefs.SetFloat("ggFlt" + y, tutar);
            //Debug.Log(PlayerPrefs.GetString("ggSt"+y, "d"))
            allGider += tutar;
        }
        PlayerPrefs.SetFloat("AllGider", allGider);
        Debug.Log("GelirGider verisi kaydedildi");
    }
}
