using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainmenuanimations : MonoBehaviour
{

    [SerializeField] GameObject MainMenuObjects;
    [SerializeField] GameObject SplashScreenObjects;
    [SerializeField] GameObject CreditsMenuObjects;
    [SerializeField] RawImage FloatingIsland;
    [SerializeField] TextMeshProUGUI SplashScreenText;
    private float timing;

    private void Start()
    {
        MainMenuObjects.SetActive(false);
        SplashScreenObjects.SetActive(true);
        CreditsMenuObjects.SetActive(false);
        timing = Time.timeSinceLevelLoad;
        Invoke("HideSplashAndShowMenu",3.0f);
    }

    // Update is called once per frame
    private void Update()
    {
        FloatingIsland.rectTransform.anchoredPosition3D =
            new Vector3(FloatingIsland.rectTransform.anchoredPosition3D.x,
            (Mathf.Sin(Time.timeSinceLevelLoad) * 35) + 40,
            FloatingIsland.rectTransform.anchoredPosition3D.z);

        if ((Time.timeSinceLevelLoad - timing) > 0.025f && SplashScreenText.fontSize < 70)
        {
            SplashScreenText.fontSize += 1;
            timing = Time.timeSinceLevelLoad;
        }
    }

    private void HideSplashAndShowMenu()
    {
        SplashScreenObjects.SetActive(false);
        MainMenuObjects.SetActive(true);
    }

    public void CreditsMenuToggle()
    {
        if (CreditsMenuObjects.activeInHierarchy)
        {
            CreditsMenuObjects.SetActive(false);
            MainMenuObjects.SetActive(true);
        }
        else
        {
            CreditsMenuObjects.SetActive(true);
            MainMenuObjects.SetActive(false);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Hub", LoadSceneMode.Single);
    }
}
