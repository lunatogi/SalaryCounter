using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GelirGiderEkle : MonoBehaviour
{
    public GameObject pnl_Gelir;
    public GameObject pnl_Gider;

    public InputField gelirEkleText;
    public InputField gelirNot;

    public InputField giderEkleText;
    public InputField giderNot;

    private float moneyLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GelirGiderBack(bool is_pnlGelir)     //pnl gelir ise true, değil ise false
    {
        if (is_pnlGelir)
        {
            pnl_Gelir.GetComponent<Animator>().Play("gelirOutAnim");
            Invoke("CloseGelir", 0.7f);
        }
        else
        {
            pnl_Gider.GetComponent<Animator>().Play("giderOutAnim");
            Invoke("CloseGider", 0.7f);
        }
    }

    public void CloseGelir() 
    {
        gelirEkleText.text = "";
        gelirNot.text = "";
        pnl_Gelir.SetActive(false);
    }

    public void CloseGider()
    {
        giderEkleText.text = "";
        giderNot.text = "";
        pnl_Gider.SetActive(false);
    }

    public void GiderEkleSave()
    {
        string newGiderSt = giderEkleText.text;
        bool valid = CheckValidation(newGiderSt);
        if (!valid)
            return;
        moneyLeft = PlayerPrefs.GetFloat("KalanPara", 0);
        float newGider = float.Parse(giderEkleText.text);
        moneyLeft -= newGider;
        PlayerPrefs.SetFloat("KalanPara", moneyLeft);

        Camera.main.SendMessage("UpdateMoney", SendMessageOptions.DontRequireReceiver);
        pnl_Gider.GetComponent<Animator>().Play("giderOutAnim");
        Invoke("CloseGider", 0.7f);
    }

    public void GelirEkleSave()
    {
        string newGelirSt = gelirEkleText.text;
        bool valid = CheckValidation(newGelirSt);
        if (!valid)
            return;
        moneyLeft = PlayerPrefs.GetFloat("KalanPara", 0);
        float newGelir = float.Parse(gelirEkleText.text);
        moneyLeft += newGelir;
        PlayerPrefs.SetFloat("KalanPara", moneyLeft);

        Camera.main.SendMessage("UpdateMoney", SendMessageOptions.DontRequireReceiver);
        pnl_Gelir.GetComponent<Animator>().Play("gelirOutAnim");
        Invoke("CloseGelir", 0.7f);
    }

    public bool CheckValidation(string txtString)
    {
        foreach (char ch in txtString)
        {
            if (!char.IsDigit(ch))
            {
                if (ch == '.')
                {
                    Debug.Log("Lütfen parayı virgül ile ayırınız");
                    return false;
                }
                else
                {
                    Debug.Log("Lütfen sayı dışında girmeyiniz");
                    return false;
                }
            }
            
        }
        return true;
    }
}
