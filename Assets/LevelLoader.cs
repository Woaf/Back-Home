using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour
{

    [SerializeField] Register register;
    [SerializeField] Button btn1, btn2, btn3, btn4, btn5, btn6, btn7;
    [SerializeField] SpriteRenderer SundialBase;
    [SerializeField] Sprite day1, day2, day3, day4, day5, day6, day7;
    [SerializeField] GameObject DayInfoSplash, HubCanvas;
    [SerializeField] TextMeshProUGUI DayInfoText;
    [SerializeField] GameObject Dude1, Dude2, Dude3, Dude4;
    [SerializeField] SpriteRenderer Dude2slot1, Dude2slot2, Dude2slot3;
    [SerializeField] SpriteRenderer Dude3slot1, Dude3slot2, Dude3slot3, Dude3slot4, Dude3slot5, Dude3slot6;
    [SerializeField] SpriteRenderer Dude4slot1, Dude4slot2, Dude4slot3, Dude4slot4, Dude4slot5, Dude4slot6;
    [SerializeField] Sprite[] floors = new Sprite[8];
    [SerializeField] Sprite gf, roof;

    private float timing;

    private void Start()
    {

        if (Register.register.completion[0])
        {
            btn1.interactable = false;
        }
        if (Register.register.completion[1])
        {
            btn2.interactable = false;
        }
        if (Register.register.completion[2])
        {
            btn3.interactable = false;
        }
        if (Register.register.completion[3])
        {
            btn4.interactable = false;
        }
        if (Register.register.completion[4])
        {
            btn5.interactable = false;
        }
        if (Register.register.completion[5])
        {
            btn6.interactable = false;
        }
        if (Register.register.completion[6])
        {
            btn7.interactable = false;
        }
        HubCanvas.SetActive(false);
        DayInfoSplash.SetActive(true);

        switch (CountTrueValues())
        {
            case 0:
                SundialBase.sprite = day1;
                DayInfoText.text = "Day 1\n(4 days remaining)";
                Dude1.SetActive(true); Dude2.SetActive(false); Dude3.SetActive(false); Dude4.SetActive(false);
                break;
            case 1:
                SundialBase.sprite = day2;
                DayInfoText.text = "Day 2\n(3 days remaining)";
                Dude1.SetActive(false); Dude2.SetActive(true); Dude3.SetActive(false); Dude4.SetActive(false);
                break;
            case 2:
                SundialBase.sprite = day3;
                DayInfoText.text = "Day 3\n(2 days remaining)";
                Dude1.SetActive(false); Dude2.SetActive(false); Dude3.SetActive(true); Dude4.SetActive(false);
                break;
            case 3:
                SundialBase.sprite = day4;
                Invoke("Sans", Random.Range(10.0f, 60.0f));
                DayInfoText.text = "Day 4\n(the last day)";
                Dude1.SetActive(false); Dude2.SetActive(false); Dude3.SetActive(true); Dude4.SetActive(false);
                break;
            case 4:
                SundialBase.sprite = day5;
                DayInfoText.text = "Welcome...";
                Dude1.SetActive(false); Dude2.SetActive(false); Dude3.SetActive(false); Dude4.SetActive(true);
                SundialBase.gameObject.SetActive(false);
                HubCanvas.SetActive(false);
                btn1.interactable = false;
                btn2.interactable = false;
                btn3.interactable = false;
                btn4.interactable = false;
                btn5.interactable = false;
                btn6.interactable = false;
                btn7.interactable = false;
                break;
            case 5:
                SundialBase.sprite = day6;
                DayInfoText.text = "Day 6\n(2 days remaining)";
                Dude1.SetActive(false); Dude2.SetActive(false); Dude3.SetActive(true); Dude4.SetActive(false);
                break;
            case 6:
                SundialBase.sprite = day7;
                DayInfoText.text = "Day 7\n(1 days remaining)";
                Dude1.SetActive(false); Dude2.SetActive(false); Dude3.SetActive(true); Dude4.SetActive(false);
                break;
            case 7:
                SundialBase.sprite = day7;
                DayInfoText.text = "Welcome";
                Dude1.SetActive(false); Dude2.SetActive(false); Dude3.SetActive(false); Dude4.SetActive(true);
                break;
            default:
                return;
        }

        //if (Dude2.activeInHierarchy)
        //{
            Dude2slot1.sprite = floors[Register.register.floors[0]];
            Dude2slot2.sprite = floors[Register.register.floors[1]];
            Dude2slot3.sprite = floors[Register.register.floors[2]];
        //}

        //if (Dude3.activeInHierarchy)
        //{
            Dude3slot1.sprite = floors[Register.register.floors[0]];
            Dude3slot2.sprite = floors[Register.register.floors[1]];
            Dude3slot3.sprite = floors[Register.register.floors[2]];
            Dude3slot4.sprite = floors[Register.register.floors[3]];
            Dude3slot5.sprite = floors[Register.register.floors[4]];
            Dude3slot6.sprite = floors[Register.register.floors[5]];
        //}
            Dude4slot1.sprite = gf;
            Dude4slot2.sprite = floors[Register.register.floors[0]];
            Dude4slot3.sprite = floors[Register.register.floors[1]];
            Dude4slot4.sprite = floors[Register.register.floors[2]];
            Dude4slot5.sprite = floors[Register.register.floors[3]];
            Dude4slot6.sprite = roof;


        Invoke("HideSplashAndShowHub", 3.0f);
        timing = Time.timeSinceLevelLoad;
    }

    public int CountTrueValues()
    {
        int truecount = 0;
        for (int i = 0; i < Register.register.completion.Length; i++)
        {
            if (Register.register.completion[i] == true) truecount++;
        }
        return truecount;
    }

    public void LoadLv1()
    {
        if (!register.completion[0])
        {
            SceneManager.LoadScene("Scene 1", LoadSceneMode.Single);
        }
    }
    public void LoadLv2()
    {
        if (!register.completion[1])
        {
            SceneManager.LoadScene("Scene 2", LoadSceneMode.Single);
        }
    }
    public void LoadLv3()
    {
        if (!register.completion[2])
        {
            SceneManager.LoadScene("Scene 3", LoadSceneMode.Single);
        }
    }
    public void LoadLv4()
    {
        if (!register.completion[3])
        {
            SceneManager.LoadScene("Scene 4", LoadSceneMode.Single);
        }
    }
    public void LoadLv5()
    {
        if (!register.completion[4])
        {
            SceneManager.LoadScene("Scene 5", LoadSceneMode.Single);
        }
    }
    public void LoadLv6()
    {
        if (!register.completion[5])
        {
            SceneManager.LoadScene("Scene 8", LoadSceneMode.Single);
        }
    }
    public void LoadLv7()
    {
        if (!register.completion[6])
        {
            SceneManager.LoadScene("Scene 7", LoadSceneMode.Single);
        }
    }

    private void HideSplashAndShowHub()
    {
        DayInfoSplash.SetActive(false);
        HubCanvas.SetActive(true);
    }

    private void Sans()
    {
        SundialBase.sprite = day5;
        Invoke("Sherif", 0.1f);
    }

    private void Sherif ()
    {
        SundialBase.sprite = day4;
    }

    private void Update()
    {
        if ((Time.timeSinceLevelLoad - timing) > 0.025f && DayInfoText.fontSize < 70)
        {
            DayInfoText.fontSize += 1;
            timing = Time.timeSinceLevelLoad;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
