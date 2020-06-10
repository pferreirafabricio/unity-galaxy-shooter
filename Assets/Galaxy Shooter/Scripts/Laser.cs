using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _LaserSpeed = 10.0f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate((Vector3.up * _LaserSpeed) * Time.deltaTime);

        if (transform.position.y >= 5.45f)
        {
            /*
             * if (transform.parent != null)
            {
                Destroy(transform.parent); //transform.parent.gameObject
            }
            */

            Destroy(this.gameObject);   
            //Destroy(Player);
        }

	}
}
