using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _volumeChangeSpeed = 1;
    private AudioSource _alert;
    private Coroutine _changeVolumeCoroutine;

    private void Start()
    {
        _alert = GetComponent<AudioSource>();
        _alert.volume = 0;
    }

    public void Activation()
    {
        if (_changeVolumeCoroutine != null)
        {
            StopCoroutine(_changeVolumeCoroutine);
        }

        _changeVolumeCoroutine = StartCoroutine(ChangeVolume(1));
    }

    public void Deactivation()
    {
        StopCoroutine(_changeVolumeCoroutine);
        _changeVolumeCoroutine = StartCoroutine(ChangeVolume(0));
    }

    private IEnumerator ChangeVolume(float targetValue)
    {
        _alert.Play();
        var _volumeSpeed = new WaitForSeconds(0.1f);

        while (_alert.volume != targetValue)
        {
            _alert.volume = Mathf.MoveTowards(_alert.volume, targetValue, _volumeChangeSpeed * Time.deltaTime);
            yield return _volumeSpeed;
        }
    }
}
