using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRaycast : MonoBehaviour
{
    public GameObject crosshair;
    public float interactionDistance;
    public LayerMask layers;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, layers))
        {
            if (hit.collider.gameObject.GetComponent<door>())
            {
                crosshair.SetActive(true);
                if (Input.GetMouseButtonDown(0)) // Menggunakan klik kiri mouse
                {
                    hit.collider.gameObject.GetComponent<door>().openClose();
                }
            }
            else
            {
                crosshair.SetActive(false);
            }
        }
        else
        {
            crosshair.SetActive(false);
        }
    }
}