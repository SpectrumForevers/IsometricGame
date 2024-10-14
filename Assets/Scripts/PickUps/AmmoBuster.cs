using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBuster : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.player)
        {

        }
    }
}
