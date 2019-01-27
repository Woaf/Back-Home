using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DudeController : MonoBehaviour
{

    [SerializeField] Register register;
    Vector3 enterC;
    int jumping = 1;

    // Start is called before the first frame update
    void Start()
    {
        enterC = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x > 2f) //-2.2f)
        {
            jumping = 0;
        }
        else
        {
            jumping = 1;
        }
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + (Input.GetAxis("Horizontal") / 20f),
            gameObject.transform.position.y + (Input.GetAxis("Jump")*jumping)/8);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //print("Trigger test");
        if (col.gameObject.tag == "Respawn")
        {
            gameObject.transform.position = enterC;
            //print("Trigger found");
        }
    }

    public void GaveUp()
    {
        Register.register.LevelCheck(Register.LevelResults.Skip, Register.LevelGoal.Skip, 5, Register.LevelTopic.Relief);
        SceneManager.LoadScene("Hub", LoadSceneMode.Single);
    }


}
