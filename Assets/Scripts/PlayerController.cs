using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    // physics - FixedUpdate, game code - Update
    public float horizontal_speed;
    // editable property
    private Rigidbody2D rb2d_harpoon;
    private PhysicsMaterial2D physeeks;
    public float vertical_speed;
    private bool isGrounded;
    public ManagementClass management;
    private GameObject harpoon;
    private Camera main_camera;
    private Vector3 endpoint;
    public float harpoon_speed;
    public bool point_move = false;
    public Vector3 move_to;
    private bool facing_right = true;

    void Start()
    {

        //physeeks = Instantiate(Resources.Load("ground_physeeks", typeof(PhysicsMaterial2D))) as PhysicsMaterial2D;

        //GetComponent<Animation>().Play("Run");
        main_camera = management.main;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Ground" || coll.gameObject.tag == "Level")
        {
            management.is_grounded = true;
        }
    }

    /*void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Harpoon")
        {
            Physics2D.IgnoreCollision(coll.collider, GetComponent<Collider2D>());
        }
    }
    */

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Door")
        {
            Debug.Log("b1");
            Application.LoadLevel("Scene - Copy");
        }
        else if (coll.gameObject.tag == "Door2")
        {
            Debug.Log("b2");
            Application.LoadLevel("Scene - Copy - Copy");
        }
        else if (coll.gameObject.tag == "Ground")
        {
            Application.LoadLevel("Scene - Copy - Copy");
        }
        else if (coll.gameObject.tag == "Door3")
        {
            Application.LoadLevel("Scene - Copy - Copy - Copy");
        }
        else if (coll.gameObject.tag == "Ground2")
        {
            Application.LoadLevel("Scene - Copy - Copy - Copy");
        }
        else if (coll.gameObject.tag == "Door4")
        {
            Application.LoadLevel("EndScene");
        }
    }



    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("clicked" + Input.mousePosition);
            endpoint = main_camera.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(endpoint);
            Vector3 dir = endpoint - transform.position;
            dir.Normalize();
            GameObject.Destroy(GameObject.FindWithTag("Harpoon"));
            harpoon = Instantiate(management.harpoon_prefab, transform.position + dir * 2, Quaternion.identity) as GameObject;
            Physics2D.IgnoreCollision(harpoon.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            harpoon.transform.forward = new Vector3(1, 0, 0);
            harpoon.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, Mathf.Rad2Deg * Mathf.Atan2((endpoint - harpoon.transform.position).y, (endpoint - harpoon.transform.position).x)));
            rb2d_harpoon = harpoon.GetComponent<Rigidbody2D>();
            harpoon.SetActive(true);
            rb2d_harpoon.AddForce((endpoint - harpoon.transform.position) * harpoon_speed);

        }
        if (Input.GetKeyDown("w") && management.is_grounded)
        {
            management.is_grounded = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, vertical_speed);
        }
        if (Input.GetKey("a"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-horizontal_speed, GetComponent<Rigidbody2D>().velocity.y);
            //gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("sharpoon_1_left", typeof(Sprite)) as Sprite;
            if (!gameObject.GetComponent<SpriteRenderer>().flipX)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }

        }
        if (Input.GetKey("d"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(horizontal_speed, GetComponent<Rigidbody2D>().velocity.y);
            //gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("sharpoon_1", typeof(Sprite)) as Sprite;
            if (gameObject.GetComponent<SpriteRenderer>().flipX)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        if (point_move)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(move_to.x, move_to.y, 0), 0.1f);
            if (transform.position.x == move_to.x && transform.position.y == move_to.y)
            {
                point_move = false;
                GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
    } 

    void Flip()
    {
        facing_right = !facing_right;
        Vector3 the_scale = transform.localScale;
        the_scale.x *= -1;
        transform.localScale = the_scale;
    }
   
}
