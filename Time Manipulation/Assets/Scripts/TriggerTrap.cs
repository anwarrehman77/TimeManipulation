using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrap : MonoBehaviour
{
    [SerializeField]
    GameObject trap;

    public void MakeTrapFall()
    {
        for (int i = 0; i < trap.transform.childCount; i++)
        {
            trap.transform.GetChild(i).gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }

        Destroy(gameObject);
    }
}
