using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Register register;

    private void Start()
    {
        //Debug.Log(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + Input.GetAxis("Horizontal"),
            gameObject.transform.position.y + Input.GetAxis("Vertical"));
    }

    /*private void OnTriggerStay(Collider other)
    {
        print("Trigger test");
        if (other.gameObject.tag == "Finish")
        {
            print("Trigger found");
            register.LevelCheck(Register.LevelResults.Win, Register.LevelGoal.Win, 2, 4);
            Destroy(gameObject);
        }
    

    void OnTriggerEnter2D(Collider2D col)
    {
        //print("Trigger test");
        if (col.gameObject.tag == "Finish")
        {
            //print("Trigger found");
            register.LevelCheck(Register.LevelResults.Win, Register.LevelGoal.Win, 2, 4);
            Destroy(gameObject);
        }
    }*/

    void OnCollisionEnter2D(Collision2D col)
    {
        //print("Trigger test");
        if (col.gameObject.tag == "Finish")
        {
            //print("Trigger found");
            Register.register.LevelCheck(Register.LevelResults.Win, Register.LevelGoal.Win, 4, Register.LevelTopic.Homecoming);
            SceneManager.LoadScene("Hub", LoadSceneMode.Single);
        }
    }
}
