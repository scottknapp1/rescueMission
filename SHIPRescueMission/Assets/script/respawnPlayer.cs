using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject respawn;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = respawn.transform.position;
        }
    }
}
