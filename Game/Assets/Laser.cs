using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float laserSpeed = 50;
    public Vector3 initialPosition;
    public Quaternion finalRotation;
    public float destructionTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        StartCoroutine(DestroyAfterTime(destructionTime));
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = initialPosition;
        gameObject.transform.rotation = finalRotation;
        gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.transform.right * laserSpeed;
    }
    IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
