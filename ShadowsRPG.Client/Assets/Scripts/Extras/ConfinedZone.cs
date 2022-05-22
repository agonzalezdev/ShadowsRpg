using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfinedZone : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vCam;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            vCam.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            vCam.gameObject.SetActive(false);
        }
    }
}
