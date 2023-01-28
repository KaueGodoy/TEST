using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireballAttack : MonoBehaviour
{
    public Transform firePosition;
    public GameObject projectile;

    // Update is called once per frame
    void Update()
    {
        // attack button = left mouse (0 = left, 1 = right button)
        if (Input.GetMouseButtonDown(0))
        {
            // spawn projectile
            Instantiate(projectile, firePosition.position, firePosition.rotation); // spawn position
        }
    }
}
