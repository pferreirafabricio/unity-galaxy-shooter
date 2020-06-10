using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float _EnemySpeed = 5f;

    [SerializeField]
    private GameObject _Enemy_Explosion;

    private UIManager _uiManager;

    [SerializeField]
    private AudioClip _audioClip;

    // Use this for initialization
    void Start()
    {
        //transform.position = new Vector3(Random.Range(-7.6f, 7.6f), 0, 0);

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((Vector3.down * _EnemySpeed) * Time.deltaTime);

        if (transform.position.y < -7.2f)
        {
            float RandomX = Random.Range(-7.6f, 7.6f);
            transform.position = new Vector3(RandomX, 6.35f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            Instantiate(_Enemy_Explosion, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(_audioClip, Camera.main.transform.position, 0.4f);

            Destroy(this.gameObject);
            _uiManager.UpdateScore();

        }

        else if (other.tag == "laser")
        {
            if (other.gameObject.name == "TripleShot") //(other.transform.parent.gameObject)
            {

                Destroy(other.gameObject);
                Destroy(other.transform.GetChild(2).gameObject);
                //Destroy(other.gameObject.transform.parent);
            }
       
            Destroy(other.gameObject);

            Instantiate(_Enemy_Explosion, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(_audioClip, Camera.main.transform.position, 0.4f);

            Destroy(this.gameObject);
            _uiManager.UpdateScore();
        }

    }

}
