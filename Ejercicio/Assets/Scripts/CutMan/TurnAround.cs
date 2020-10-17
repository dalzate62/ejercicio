using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAround : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        Vector3 vector = new Vector3(transform.root.localScale.x * -1, transform.root.localScale.y, transform.root.localScale.z);
        transform.root.localScale = vector;
    }
}
