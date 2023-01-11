using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class GravityField : MonoBehaviour
{
    public float magnetPower;
    public GameObject player;
    private Vector3 target;
    public bool magnet = false;
    public LayerMask players;
 
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            player = col.gameObject;
            magnet = true;
        }
    }
 
    void Update()
    {  

        if (magnet){
            
        }
        
        // if (magnet)
        // {
        //     target = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        //     Vector3 difference = target - gameObject.transform.position;
        //     float distance = difference.magnitude;
        //     Vector2 direction = difference / distance;
        //     direction.Normalize();
        //     player.GetComponent<Rigidbody2D>().velocity = direction * magnetPower;
        // }
 
        // if (Physics2D.OverlapArea(new Vector2(gameObject.transform.position.x - 0.15f, gameObject.transform.position.y + 0.25f), new Vector2(gameObject.transform.position.x + 0.15f, gameObject.transform.position.y - 0.25f), players))
        // {
        //     Debug.Log(gameObject.name);
        //     magnet = false;
        // }
 
        
    }
 
}
 

