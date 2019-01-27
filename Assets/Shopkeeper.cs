using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shopkeeper : MonoBehaviour
{

    [SerializeField] RawImage myStage;
    [SerializeField] Texture b111, b112, b113, b121, b122, b123, b131, b132, b133,
        b211, b212, b213, b221, b222, b223, b231, b232, b233,
        b311, b312, b313, b321, b322, b323, b331, b332, b333;
    private byte toggleA, toggleB, toggleC;

    // Start is called before the first frame update
    void Start()
    {
        toggleA = 1; toggleB = 1; toggleC = 1;
    }

    void UpdateImage()
    {
        if (toggleA == 1 && toggleB == 1 && toggleC == 1)
        {
            myStage.texture = b111;
        }
        else if (toggleA == 1 && toggleB == 1 && toggleC == 2)
        {
            myStage.texture = b112;
        }
        else if (toggleA == 1 && toggleB == 1 && toggleC == 3)
        {
            myStage.texture = b113;
        }
        else if (toggleA == 1 && toggleB == 2 && toggleC == 1)
        {
            myStage.texture = b121;
        }
        else if (toggleA == 1 && toggleB == 2 && toggleC == 2)
        {
            myStage.texture = b122;
        }
        else if (toggleA == 1 && toggleB == 2 && toggleC == 3)
        {
            myStage.texture = b123;
        }
        else if (toggleA == 1 && toggleB == 3 && toggleC == 1)
        {
            myStage.texture = b131;
        }
        else if (toggleA == 1 && toggleB == 3 && toggleC == 2)
        {
            myStage.texture = b132;
        }
        else if (toggleA == 1 && toggleB == 3 && toggleC == 3)
        {
            myStage.texture = b133;
        }
        else if (toggleA == 2 && toggleB == 1 && toggleC == 1)
        {
            myStage.texture = b211;
        }
        else if (toggleA == 2 && toggleB == 1 && toggleC == 2)
        {
            myStage.texture = b212;
        }
        else if (toggleA == 2 && toggleB == 1 && toggleC == 3)
        {
            myStage.texture = b213;
        }
        else if (toggleA == 2 && toggleB == 2 && toggleC == 1)
        {
            myStage.texture = b221;
        }
        else if (toggleA == 2 && toggleB == 2 && toggleC == 2)
        {
            myStage.texture = b222;
        }
        else if (toggleA == 2 && toggleB == 2 && toggleC == 3)
        {
            myStage.texture = b223;
        }
        else if (toggleA == 2 && toggleB == 3 && toggleC == 1)
        {
            myStage.texture = b231;
        }
        else if (toggleA == 2 && toggleB == 3 && toggleC == 2)
        {
            myStage.texture = b232;
        }
        else if (toggleA == 2 && toggleB == 3 && toggleC == 3)
        {
            myStage.texture = b233;
        }
        else if (toggleA == 3 && toggleB == 1 && toggleC == 1)
        {
            myStage.texture = b311;
        }
        else if (toggleA == 3 && toggleB == 1 && toggleC == 2)
        {
            myStage.texture = b312;
        }
        else if (toggleA == 3 && toggleB == 1 && toggleC == 3)
        {
            myStage.texture = b313;
        }
        else if (toggleA == 3 && toggleB == 2 && toggleC == 1)
        {
            myStage.texture = b321;
        }
        else if (toggleA == 3 && toggleB == 2 && toggleC == 2)
        {
            myStage.texture = b322;
        }
        else if (toggleA == 3 && toggleB == 2 && toggleC == 3)
        {
            myStage.texture = b323;
        }
        else if (toggleA == 3 && toggleB == 3 && toggleC == 1)
        {
            myStage.texture = b331;
        }
        else if (toggleA == 3 && toggleB == 3 && toggleC == 2)
        {
            myStage.texture = b332;
        }
        else if (toggleA == 3 && toggleB == 3 && toggleC == 3)
        {
            myStage.texture = b333;
        }
    }

    public void ToggleABackward()
    {
        switch (toggleA)
        {
            case 1:
                toggleA = 3; break;
            case 2:
                toggleA = 1; break;
            case 3:
                toggleA = 2; break;
            default: break;
        }
        UpdateImage();
    }
    public void ToggleAForward()
    {
        switch (toggleA)
        {
            case 1:
                toggleA = 2; break;
            case 2:
                toggleA = 3; break;
            case 3:
                toggleA = 1; break;
            default: break;
        }
        UpdateImage();
    }
    public void ToggleBBackward()
    {
        switch (toggleB)
        {
            case 1:
                toggleB = 3; break;
            case 2:
                toggleB = 1; break;
            case 3:
                toggleB = 2; break;
            default: break;
        }
        UpdateImage();
    }
    public void ToggleBForward()
    {
        switch (toggleB)
        {
            case 1:
                toggleB = 2; break;
            case 2:
                toggleB = 3; break;
            case 3:
                toggleB = 1; break;
            default: break;
        }
        UpdateImage();
    }
    public void ToggleCBackward()
    {
        switch (toggleC)
        {
            case 1:
                toggleC = 3; break;
            case 2:
                toggleC = 1; break;
            case 3:
                toggleC = 2; break;
            default: break;
        }
        UpdateImage();
    }
    public void ToggleCForward()
    {
        switch (toggleC)
        {
            case 1:
                toggleC = 2; break;
            case 2:
                toggleC = 3; break;
            case 3:
                toggleC = 1; break;
            default: break;
        }
        UpdateImage();
    }

    public void Confirm()
    {
        Register.register.LevelCheck(Register.LevelResults.Skip, Register.LevelGoal.Skip,
            ((toggleA-1)*9)+((toggleB-1)*3)+toggleC+10, Register.LevelTopic.Playfulness);
        SceneManager.LoadScene("Hub", LoadSceneMode.Single);
    }
}
