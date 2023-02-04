using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;

    GameObject focalPoint;
    float powerupForce = 15.0f;

    [SerializeField] float speed;
    [SerializeField] bool hasPowerup = false;
    [SerializeField] GameObject powerupIndicator;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        float fInput = Input.GetAxis("Vertical");
        playerRb.AddForce(fInput * speed * focalPoint.transform.forward);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountDownRoutine());
        }
    }

    IEnumerator PowerupCountDownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemy = collision.rigidbody.GetComponent<Rigidbody>();
            Vector3 playerToEnemy = collision.gameObject.transform.position - transform.position;

            enemy.AddForce(powerupForce * playerToEnemy, ForceMode.Impulse);
        }
    }
}
