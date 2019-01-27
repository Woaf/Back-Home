using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Choices : MonoBehaviour
{
    [SerializeField] Register register;

    public void YesChosen()
    {
        Register.register.LevelCheck(
            Register.LevelResults.Win, Register.LevelGoal.Win, 2, Register.LevelTopic.Affiliation);
        SceneManager.LoadScene("Hub", LoadSceneMode.Single);
    }

    public void NoChosen()
    {
        Register.register.LevelCheck(Register.LevelResults.Fail, Register.LevelGoal.Fail, 3, Register.LevelTopic.Affiliation);
        SceneManager.LoadScene("Hub", LoadSceneMode.Single);
    }


}
