using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTime : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Rigidbody2D>() != null) StartCoroutine(PauseRbSimulation(col.gameObject.GetComponent<Rigidbody2D>()));
    }

    private IEnumerator PauseRbSimulation(Rigidbody2D targetRb)
    {
        targetRb.simulated = false;

        yield return new WaitForSeconds(3f);

        targetRb.simulated = true;
    }
}
