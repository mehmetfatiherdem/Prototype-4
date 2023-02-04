using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;
    Rigidbody enemyRb;

    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 lookDirection = (player.transform.position - pos).normalized;

        enemyRb.AddForce(lookDirection * speed);
 
    }

}
