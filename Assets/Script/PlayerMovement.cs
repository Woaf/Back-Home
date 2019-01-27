using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;

    Transform player;

    bool facingRight = true;

    private void Start()
    {
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal");
        if(deltaX > 0)
        {
            if(!facingRight)
            {
                facingRight = true;
                player.transform.Rotate(new Vector3(0f, 180f, 0f));
            }
            
        }
        else if (deltaX < 0)
        {
            if(facingRight)
            {
                facingRight = false;
                player.transform.Rotate(new Vector3(0f, 180f, 0f));
            }
        }
        var newPos = player.position.x + deltaX * Time.deltaTime * speed;
        player.position = new Vector2(newPos, player.position.y);
    }
}
