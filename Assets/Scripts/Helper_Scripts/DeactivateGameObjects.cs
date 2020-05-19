using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateGameObjects : MonoBehaviour
{
    public float timer = 1.5f;
     void Start()
    {
        Invoke("DeactivateAfterTime", timer);
    }
    public void DeactivateAfterTime()
    {
        Destroy(gameObject);
    }
}
