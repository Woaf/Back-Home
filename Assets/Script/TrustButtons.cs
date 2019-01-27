using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TrustButtons : MonoBehaviour
{
    [SerializeField] Button button;
    Register register;

    private void Start()
    {
        register = FindObjectOfType<Register>();
    }

    public void onClickLoadScene()
    {
        int[] indices = { 9, 10 , 38, 39};
        int randomIndex = UnityEngine.Random.Range(0, 4);
        register.LevelCheck(Register.LevelResults.Win, Register.LevelGoal.Win, indices[randomIndex], Register.LevelTopic.Trust);
        SceneManager.LoadScene("Hub", LoadSceneMode.Single);
    }
}
