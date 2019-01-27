using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ArrowTask : MonoBehaviour
{
    [SerializeField] GameObject leftArrow, rightArrow;
    [SerializeField] TextMeshProUGUI counterText;
    private double score = 72109012;
    private bool leftPressed, rightPressed;
    private byte phase = 1;
    [SerializeField] Register register;

    // Start is called before the first frame update
    void Start()
    {
        counterText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            rightPressed = true;
            leftPressed = false;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rightPressed = false;
            leftPressed = true;
        }
        else
        {
            rightPressed = false;
            leftPressed = false;
        }


        switch (phase)
        {
            case 1:
                if (Random.Range(1, 3) == 1)
                {
                    leftArrow.SetActive(true);
                    rightArrow.SetActive(false);
                }
                else
                {
                    rightArrow.SetActive(true);
                    leftArrow.SetActive(false);
                }
                phase = 2;
                break;
            case 2:
                if (leftArrow.activeSelf && leftPressed)
                {
                    phase = 3;
                }
                else if (rightArrow.activeSelf && rightPressed)
                {
                    phase = 3;
                }
                else if ((leftArrow.activeSelf && rightPressed) ||
                        (rightArrow.activeSelf && leftPressed))
                {
                    score -= 2;
                    phase = 3;
                }
                else
                {
                    phase = 2;
                }
                break;
            case 3:
                score++;
                if (score > 72109062)
                {
                    Register.register.LevelCheck(
                    Register.LevelResults.Win, Register.LevelGoal.Win, 6, Register.LevelTopic.Rest);
                    SceneManager.LoadScene("Hub", LoadSceneMode.Single);
                }
                else if (score < 72108987)
                {
                    Register.register.LevelCheck(
                    Register.LevelResults.Fail, Register.LevelGoal.Fail, 7, Register.LevelTopic.Rest);
                    SceneManager.LoadScene("Hub", LoadSceneMode.Single);
                }
                counterText.text = score.ToString();
                leftArrow.SetActive(false);
                rightArrow.SetActive(false);
                phase = 4;
                break;
            case 4:
                if (Mathf.Approximately(Input.GetAxis("Horizontal"),0.0f))
                {
                    phase = 1;
                }
                break;
            default:
                if (Random.Range(1, 2) == 1)
                {
                    leftArrow.SetActive(true);
                    rightArrow.SetActive(false);
                }
                else
                {
                    rightArrow.SetActive(true);
                    leftArrow.SetActive(false);
                }
                phase = 2;
                break;
        }

    }



}
