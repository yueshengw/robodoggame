using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    public GameObject laserPrefab;


    void Update()
    {
        Vector3 mouseScreen = Input.mousePosition;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg - 90);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject laser = Instantiate(laserPrefab, gameObject.transform.position, Quaternion.Euler(0, 0, gameObject.transform.rotation.z));

            laser.GetComponent<Laser>().initialPosition = gameObject.transform.position;
            laser.GetComponent<Laser>().finalRotation = Quaternion.Euler(0,0,gameObject.transform.rotation.z);
        }
    }
}
