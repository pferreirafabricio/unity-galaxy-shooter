using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private float _PowerupSpeed = 3.0f;

    [SerializeField]
    private int PowerUpId;

    [SerializeField]
    private AudioClip _audioClip;

	void Update ()
    {
        transform.Translate((Vector3.down * _PowerupSpeed) * Time.deltaTime);

        if (transform.position.y < -6.35f)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //Access the player
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                AudioSource.PlayClipAtPoint(_audioClip, Camera.main.transform.position, 0.5f);

                if (PowerUpId == 0)
                {
                    //Enable Triple Shot
                    player.TripleShotPowerupON();
                }
                else if (PowerUpId == 1)
                {
                    player.SpeedBoostON();
                }
                else if (PowerUpId == 2)
                {
                    player.ShieldON();
                }
            }

            //Destroy the PowerUp
            Destroy(this.gameObject);
        }
    }

}
