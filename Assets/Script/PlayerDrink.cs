using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDrink : MonoBehaviour
{
    [SerializeField] Sprite idleSprite;
    [SerializeField] Sprite drinkSprite;
    [SerializeField] GameObject beerSlider;
    [SerializeField] float beerAmount;
    [SerializeField] GameObject friend;
    [SerializeField] GameObject displayButton;

    Slider beerS;

    [SerializeField] Register register;

    bool isDrinking = false;

    private float friendBeerAmount;

    // Start is called before the first frame update
    void Start()
    {
        beerS = FindObjectOfType<Slider>();
        beerSlider.SetActive(false);
        beerAmount = beerS.maxValue;
        friendBeerAmount = friend.GetComponent<FriendDrink>().beerAmount;
    }

    // Update is called once per frame
    void Update()
    {
        friendBeerAmount = friend.GetComponent<FriendDrink>().beerAmount;
        ManagDrink();
        EndGame();
    }

    private void EndGame()
    {
        if(beerAmount <= 0 && friendBeerAmount > 0)
        {
            Register.register.LevelCheck(Register.LevelResults.Win, Register.LevelGoal.Win, 8, Register.LevelTopic.Friends);
            SceneManager.LoadScene("Hub", LoadSceneMode.Single);
        }
        else if(beerAmount > 0 && friendBeerAmount < 0)
        {
            Register.register.LevelCheck(Register.LevelResults.Fail, Register.LevelGoal.Win, 8, Register.LevelTopic.Friends);
            SceneManager.LoadScene("Hub", LoadSceneMode.Single);
        }
    }

    private void ManagDrink()
    {
        if (isDrinking)
        {
            beerAmount -= Time.deltaTime;
            beerS.value = beerAmount;
        }

        if (Input.GetButtonDown("Jump") && beerAmount >= 0)
        {
            isDrinking = true;
            Drink();
        }
        else if (Input.GetButtonUp("Jump"))
        {
            isDrinking = false;
            StopDrinking();
        }
    }

    private void StopDrinking()
    {
        beerSlider.SetActive(false);
        GetComponent<SpriteRenderer>().sprite = idleSprite;
        displayButton.SetActive(true);
    }

    private void Drink()
    {
        beerSlider.SetActive(true);
        GetComponent<SpriteRenderer>().sprite = drinkSprite;
        displayButton.SetActive(false);
    }

}
