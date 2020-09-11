using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Crosshair : MonoBehaviour
{
    public List<GameObject> images;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        
        images[0].transform.position = ray.GetPoint(20f);
        images[1].transform.position = ray.GetPoint(40f);
    }
}
