using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject pnl_home;
    public GameObject pnl_maas;
    public GameObject pnl_genel;
    public GameObject pnl_settings;
    public GameObject pnl_gelirEkle;
    public GameObject pnl_giderEkle;

    public GameObject pnl_firstGenel;
    public GameObject pnl_firstMaas;

    public GameObject obj_Start;

    int firstTime;
    // Start is called before the first frame update
    void Start()
    {
        //firstTime = 1;
        //PlayerPrefs.SetInt("FirstTime", firstTime);
        firstTime = PlayerPrefs.GetInt("FirstTime", 1);
        if (firstTime == 0)
        {
            pnl_home.SetActive(true);
            Destroy(obj_Start);
            Destroy(pnl_firstGenel);
            Destroy(pnl_firstMaas);
        }
        else
        {
            firstTime = 0;
            PlayerPrefs.SetInt("FirstTime", firstTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddGenelGider(int index)
    {

    }

    public void Maas()
    {
        //pnl_home.SetActive(false);
        //pnl_settings.SetActive(false);

        pnl_maas.SetActive(true);
        pnl_maas.GetComponent<Animator>().Play("maasInAnim");
        pnl_settings.GetComponent<Animator>().Play("settingsOutAnim");
    }
    
    public void GiderEkle()
    {
        //pnl_home.SetActive(false);
        pnl_giderEkle.SetActive(true);
        pnl_giderEkle.GetComponent<Animator>().Play("giderInAnim");
    }

    public void GelirEkle()
    {
        //pnl_home.SetActive(false);
        pnl_gelirEkle.SetActive(true);
        pnl_gelirEkle.GetComponent<Animator>().Play("gelirInAnim");
    }

    public void GenelGider()
    {
        //pnl_settings.SetActive(false);

        //pnl_home.SetActive(false);
        pnl_genel.SetActive(true);
        pnl_genel.GetComponent<Animator>().Play("genelInAnim");
        pnl_settings.GetComponent<Animator>().Play("settingsOutAnim");
        
    }

    public void Settings()
    {
        pnl_settings.GetComponent<Animator>().Play("settingsInAnim");
    }

    public void GoBack(int i)
    {
        switch (i)
        {
            case 0:     //Ayarlardan geri dönme
                //pnl_settings.SetActive(false);
                pnl_settings.GetComponent<Animator>().Play("settingsOutAnim");
                //pnl_home.SetActive(true);
                break;
            case 1:     //Genel Gider geri dönme
                Invoke("CloseGenel", 0.7f);
                pnl_home.SetActive(true);
                //pnl_settings.SetActive(true);
                pnl_genel.GetComponent<Animator>().Play("genelOutAnim");
                break;
            case 2:     //Gider Ekle Save
                //pnl_giderEkle.SetActive(false);
                transform.gameObject.SendMessage("GiderEkleSave", SendMessageOptions.DontRequireReceiver);
                //pnl_giderEkle.GetComponent<Animator>().Play("giderOutAnim");
                //pnl_home.SetActive(true);
                break;
            case 3:     //Gelir Ekle Save
                //pnl_gelirEkle.SetActive(false);
                //pnl_home.SetActive(true);
                transform.gameObject.SendMessage("GelirEkleSave", SendMessageOptions.DontRequireReceiver);
                //pnl_gelirEkle.GetComponent<Animator>().Play("gelirOutAnim");
                break;
            case 4:     //Maaş geri gelme
                Invoke("CloseMaas", 0.7f);
                //pnl_settings.SetActive(true);
                pnl_maas.GetComponent<Animator>().Play("maasOutAnim");
                //pnl_home.SetActive(true);
                break;
            case 5:     //Gelir save'lemeden exit
                transform.gameObject.SendMessage("GelirGiderBack", true, SendMessageOptions.DontRequireReceiver);
                break;
            case 6:     //Gider save'lemeden exit
                transform.gameObject.SendMessage("GelirGiderBack", false, SendMessageOptions.DontRequireReceiver);
                break;
        }
    }

    public void FirstControls(int i)
    {
        switch (i)
        {
            case 0:                         //Maaş ilerle
                //pnl_firstMaas.SetActive(false);
                Camera.main.SendMessage("SaveMaas", SendMessageOptions.DontRequireReceiver);
                pnl_firstGenel.SetActive(true);
                pnl_firstMaas.GetComponent<Animator>().Play("firstMaasOutAnim");
                pnl_firstGenel.GetComponent<Animator>().Play("firstGenelInAnim");
                Invoke("CloseFirstMaas", 0.7f);
                break;
            case 1:                         //GenelGider geri dönme
                //pnl_firstGenel.SetActive(false);
                pnl_firstMaas.SetActive(true);
                pnl_firstMaas.GetComponent<Animator>().Play("firstMaasInLeftAnim");
                pnl_firstGenel.GetComponent<Animator>().Play("firstGenelRightOutAnim");
                Invoke("CloseFirstGenel", 0.7f);
                break;
            case 2:                         //GenelGider İleri
                //pnl_firstGenel.SetActive(false);
                /*
                pnl_home.SetActive(true);
                pnl_firstGenel.GetComponent<Animator>().Play("firstGenelRightOutAnim");
                Invoke("CloseFirstGenel", 0.7f);
                Destroy(pnl_firstGenel);
                Destroy(pnl_firstMaas);*/
                Camera.main.SendMessage("FirstSave", SendMessageOptions.DontRequireReceiver);
                SceneManager.LoadScene(0);
                break;
            case 3:
                pnl_firstMaas.SetActive(true);
                obj_Start.GetComponent<Animator>().Play("welcomeOutAnim");
                pnl_firstMaas.GetComponent<Animator>().Play("firstMaasInRightAnim");
                Destroy(obj_Start, 0.7f);
                break;
        }
    }

    public void CloseFirstMaas()
    {
        pnl_firstMaas.SetActive(false);
    }

    public void CloseFirstGenel()
    {
        pnl_firstGenel.SetActive(false);
    }

    public void CloseMaas()
    {
        pnl_maas.SetActive(false);
    }

    public void CloseGenel()
    {
        pnl_genel.SetActive(false);
    }

    public void GatyDev()
    {
        //İnternet sitesine gider
    }
}
