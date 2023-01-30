using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private Transform transform;
    Vector3 orignalposition;
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
            transform.position = transform.up * 3f * Time.deltaTime;
        }

        if(transform.position.y < -5f)
        {
            GameManager.thisManager.Damage(1);
            orignalposition.y = 0;
            transform.position = orignalposition;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacles")
        {
            GameManager.thisManager.Damage(1);
        }
    }
}
