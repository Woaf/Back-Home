using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendDrink : MonoBehaviour
{
    [SerializeField] Sprite idleSprite;
    [SerializeField] Sprite drinkSprite;
    [SerializeField] GameObject friendSlider;

    Slider friendS;

    public float beerAmount;

    bool isDrinking = false;

    [SerializeField] float drinkCounter = 5.7f;
    [SerializeField] float minTimeBetweenDrinks = 0.7f;
    [SerializeField] float maxTimeBetweenDrinks = 3.1f;

    // Start is called before the first frame update
    void Start()
    {
        friendS = friendSlider.GetComponent<Slider>();
        friendS.value = 10;
        friendSlider.SetActive(false);
        drinkCounter = UnityEngine.Random.Range(minTimeBetweenDrinks, maxTimeBetweenDrinks);
        beerAmount = friendS.maxValue;

        transform.position = new Vector3(-3.2f, -0.5f, 0f);
        transform.localScale = new Vector3(transform.localScale.x * 1f, transform.localScale.y * 1f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        countDownAndDrink();   
    }

    private void countDownAndDrink()
    {

        drinkCounter -= Time.deltaTime;
        if(drinkCounter <= 0 && !isDrinking)
        {
            isDrinking = true;
            Drink();
            drinkCounter = UnityEngine.Random.Range(minTimeBetweenDrinks, maxTimeBetweenDrinks);
        }
        else if (drinkCounter <= 0 && isDrinking)
        {
            isDrinking = false;
            DontDrink();
            drinkCounter = UnityEngine.Random.Range(minTimeBetweenDrinks, maxTimeBetweenDrinks);
        }

    }

    private void DontDrink()
    {
        friendSlider.SetActive(false);
        GetComponent<SpriteRenderer>().sprite = idleSprite;
    }

    private void Drink()
    {
        friendSlider.SetActive(true);

        beerAmount -= Time.deltaTime * UnityEngine.Random.Range(40f, 80f);
        friendS.value = beerAmount;

        GetComponent<SpriteRenderer>().sprite = drinkSprite;
    }
}
