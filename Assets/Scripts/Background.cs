using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Transform positionHolder;

    public float scrollSpeed;

    public float bottom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -bottom){
            transform.position = positionHolder.position;
        }

        transform.position = transform.position + (-transform.up * scrollSpeed * Time.deltaTime);
    }
}
