using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementController : MonoBehaviour
{
    public int halfWidth = 17;
    public int halfHeight = 10;

    public float jumpForce = 5.0f;
    public bool grounded = false;
    public Rigidbody2D playerBody;

    public Dictionary<string, int> pickedFruits = new Dictionary<string, int>();

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        float distance = 5 * Time.deltaTime;
        
        // movement along the x axis
        if (Input.GetKey(KeyCode.D) && pos.x < halfWidth)
        {
            pos.x += distance;
        }
        if (Input.GetKey(KeyCode.A) && pos.x > -halfWidth)
        {
            pos.x -= distance;
        }
        
        // movement along the y axis 
        /*if (Input.GetKey(KeyCode.W) && pos.y < halfHeight)
        {
            pos.y += distance;
        }
        if (Input.GetKey(KeyCode.S) && pos.y > -halfHeight)
        {
            pos.y -= distance;
        }*/
        
        transform.position = pos;

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            grounded = !grounded;
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpForce);
        }

        foreach (KeyValuePair<string,int> tag_Count in pickedFruits){
            Debug.Log(tag_Count.Key + ":" + tag_Count.Value);
        }
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("ded");
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
        if (col.gameObject.tag == "Ground")
        {
            grounded = true;
        }else if(col.gameObject.tag == "Fruit"){
            string fruitTag = col.gameObject.GetComponent<FruitScript>().fruitTag;
            if (pickedFruits.ContainsKey(fruitTag)){
                pickedFruits[fruitTag] += 1;
            }else{
                pickedFruits.Add(fruitTag, 1);
            }
            Destroy(col.gameObject);
        }
    }
}
