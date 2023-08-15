using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float health = 100;

    void Die()
    {
        Debug.Log("Died");
        // Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Trap") Die();
    }
}
