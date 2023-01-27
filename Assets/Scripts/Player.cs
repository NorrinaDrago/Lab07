using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private Transform transform;
    void Start()
    {
        transform = GetComponent<Transform>();
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            transform.position = transform.up * 10f * Time.deltaTime;
        }

        if(transform.position.y < -5f)
        {

        }
    }
}
