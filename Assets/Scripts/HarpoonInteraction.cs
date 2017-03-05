using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonInteraction : MonoBehaviour {
    private Camera main_camera;
    private ManagementClass management;
    private GameObject the_player;
    private Rigidbody2D rb2d;
    // Use this for initialization
    void Start () {
        the_player = GameObject.FindWithTag("Player");
        rb2d = GetComponent<Rigidbody2D>();
        //main_camera = management.main;
	}

    void OnCollisionEnter2D (Collision2D coll)
    {
        Debug.Log("zzzzzzz");
        if (coll.gameObject.tag == "Level")
        {
            Debug.Log("fnfnfnfnnf");
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
            the_player.GetComponent<Rigidbody2D>().isKinematic = true;
            the_player.GetComponent<PlayerController>().move_to = transform.position;
            the_player.GetComponent<PlayerController>().point_move = true;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
