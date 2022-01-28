using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float turnSpeed = 90f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            if(other.gameObject.GetComponent<Enemy>() != null)
            {
                return;
            }
            Destroy(gameObject);
            return;
        }
        if(other.gameObject.name != "Player")
        {
            return;
        }

        FindObjectOfType<AudioManager>().Play("CoinPickup");
        ScoreManager.instance.AddPoint();

        Destroy(gameObject);
    }
    void Start()
    {
        transform.Rotate(90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
