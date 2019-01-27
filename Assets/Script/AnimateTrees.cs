using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateTrees : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject trees;
    [SerializeField] GameObject clouds;
    // Start is called before the first frame update

    private void Update()
    {
        trees.transform.position = new Vector3(-player.transform.position.x / 25.0f, trees.transform.position.y, trees.transform.position.z);
        clouds.transform.position = new Vector3(-player.transform.position.x / 40.0f, clouds.transform.position.y, clouds.transform.position.z);
    }

}
