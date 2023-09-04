using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _volumeSpeed = 1;
    [SerializeField] private float _runningSpeed = 0.05f;

    private AudioSource _alert;
    private Coroutine _changeVolumeCoroutine;

    private float _volumeOff = 0f;
    private float _volumeOn = 1f;

    private void Start()
    {
        _alert = GetComponent<AudioSource>();
        _alert.volume = 0;
    }

    public void Activate()
    {
        if (_changeVolumeCoroutine != null)
        {
            _alert.Play();
            StopCoroutine(_changeVolumeCoroutine);
        }

        _changeVolumeCoroutine = StartCoroutine(ChangeVolume(_volumeOn));
    }

    public void Deactivate()
    {
        int stopPlayback = 5;

        StopCoroutine(_changeVolumeCoroutine);
        _changeVolumeCoroutine = StartCoroutine(ChangeVolume(_volumeOff));
        Invoke(nameof(VolumeOff), stopPlayback);
    }

    private void VolumeOff()
    {
        _alert.Stop();
    }

    private IEnumerator ChangeVolume(float targetValue)
    {
        var updateFrequency = new WaitForSeconds(_runningSpeed);

        while (_alert.volume != targetValue)
        {
            _alert.volume = Mathf.MoveTowards(_alert.volume, targetValue, _volumeSpeed * Time.deltaTime);
            yield return updateFrequency;
        }
    }
}
