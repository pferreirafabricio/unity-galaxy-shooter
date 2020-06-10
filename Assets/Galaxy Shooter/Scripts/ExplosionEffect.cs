using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{

    void Start()
    {
        Destroy(this.gameObject, 3.0f);
    }
}
