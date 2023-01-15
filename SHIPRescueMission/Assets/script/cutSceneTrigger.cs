using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutSceneTrigger : MonoBehaviour
{
    [SerializeField] private GameObject Ship;
    [SerializeField] private GameObject fires;
    [SerializeField] private GameObject cutSceneCam;
    [SerializeField] private GameObject cars;
    [SerializeField] private GameObject mission;
    [SerializeField] private GameObject missionUpdate;
    [SerializeField] private GameObject helipadMarker;

    [SerializeField] private ParticleSystem[] particles;

    private void Awake()
    {
        particles = cars.GetComponentsInChildren<ParticleSystem>(); 
        foreach(ParticleSystem particle in particles)
        {
            particle.Stop();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        cutSceneCam.SetActive(true);
        mission.SetActive(false);
        fires.SetActive(true);
        Ship.SetActive(false);
        StartCoroutine(endCut());
        foreach (ParticleSystem particle in particles)
        {
            particle.Play();
        }
    }
    IEnumerator endCut()
    {
        yield return new WaitForSeconds(12);
        Ship.SetActive(true);
        cutSceneCam.SetActive(false);
        missionUpdate.SetActive(true);
        helipadMarker.SetActive(true);
    }
}
