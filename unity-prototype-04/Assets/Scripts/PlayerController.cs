using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public float speed = 5F;
    public bool hasPowered;
    private float powerupStrength = 15F;
    public GameObject powerupIndicator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Powerup")){
            hasPowered = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountDownRoutine());
        }
    }

    IEnumerator PowerupCountDownRoutine(){
        yield return new WaitForSeconds(7);
        hasPowered = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Enemy") && hasPowered){

            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
        powerupIndicator.transform.position = playerRb.transform.position - new Vector3(0F,0.5F,0F);
    }
}
