using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulateTime : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private float timeScaler = 2f;
    private float manipulationCooldown = 5f;
    private float nextManipulateTime = 0f;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && (Time.time >= nextManipulateTime) && (PlayerPrefs.GetInt("CanSpeedUp") == 1)) StartCoroutine(ChangeTimeSpeed());
    }

    private IEnumerator ChangeTimeSpeed()
    {
        Time.timeScale *= timeScaler;
        StartCoroutine(playerMovement.ChangeMovementStats(timeScaler, timeScaler / 1.5f, 3f));
        yield return new WaitForSeconds(3f);
        Time.timeScale /= timeScaler;


        nextManipulateTime = Time.time + manipulationCooldown;
    }

    private void FixedUpdate()
    {
        
    }
}
