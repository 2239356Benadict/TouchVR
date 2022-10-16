using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotate : MonoBehaviour
{
    public float rotateSpeed;
    public float revolveSpeed;
    public GameObject targetPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);

        transform.RotateAround(targetPoint.transform.position, Vector3.up, revolveSpeed * Time.deltaTime);
    }
}
