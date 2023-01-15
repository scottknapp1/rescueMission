using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatFixerPos : MonoBehaviour
{
    [SerializeField] private GameObject box;
    [SerializeField] private GameObject respawnCrate;

    public bool inDropZone = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (box.transform.position.y < respawnCrate.transform.position.y && !inDropZone)
        {
            box.transform.position = respawnCrate.transform.position;
        }
    }
}
