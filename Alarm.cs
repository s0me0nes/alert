using UnityEngine;

public class Alarm : MonoBehaviour
{
    private AudioSource _alert;
    private bool _isVolumeUp = false;
    private float _slowlyChangeVolume = 6;

    private void Start()
    {
        _alert = GetComponent<AudioSource>();
        _alert.volume = 0;
    }

    private void Update()
    {
        if (_isVolumeUp)
        {
            _alert.volume += Time.deltaTime / _slowlyChangeVolume;
        }
        else if (_isVolumeUp == false)
        {
            _alert.volume -= Time.deltaTime / _slowlyChangeVolume;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _isVolumeUp = true;
            _alert.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _isVolumeUp = false;
        }
    }
}