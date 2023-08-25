using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewindable : MonoBehaviour
{
    [SerializeField] 
    private float deleteTime = 10f;
    [SerializeField]
    private float rewindSpeed = 2f;

    private Rigidbody2D rb2d;
    private List<Vector3> savedPositions = new List<Vector3>(); 
    private float lastDeleteTime = 0f;
    private bool rewinding;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rewinding = Input.GetKey(KeyCode.J);

        if (rb2d != null) rb2d.simulated = !rewinding;

        if (Time.time >= lastDeleteTime + deleteTime)
        {
            savedPositions.Clear();
            lastDeleteTime = Time.time;
        }

        if (rewinding) Rewind();
        
    }

    private void FixedUpdate()
    {
        if (!rewinding) savedPositions.Add(transform.position);
    }

    private void Rewind()
    {
        if (savedPositions.Count > 0)
        {
            Vector3 targetPosition = savedPositions[savedPositions.Count - 1];
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.fixedDeltaTime * rewindSpeed);

            if (transform.position == targetPosition)
            {
                savedPositions.RemoveAt(savedPositions.Count - 1);
            }
        }
        else
        {
            rewinding = false;
        }
    }
}
