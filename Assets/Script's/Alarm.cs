using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _volumeRate = 0.2f;
    [SerializeField] private Door _door;

    private readonly int _maxVolume = 1;
    private readonly int _minVolume = 0;

    private Coroutine _soundCoroutine;
    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _door.Entered += MonitorInvasion;
        _door.Exited += MonitorInvasion;
    }

    private void OnDisable()
    {
        _door.Entered -= MonitorInvasion;
        _door.Exited -= MonitorInvasion;
    }

    private void MonitorInvasion(bool hasEntered)
    {
        if (_soundCoroutine != null)
            StopCoroutine(_soundCoroutine);

        _soundCoroutine = StartCoroutine(ChangeVolume(hasEntered));
    }

    private IEnumerator ChangeVolume(bool hasEntered)
    {
        int targetVolume;

        if (hasEntered)
        {
            _source.volume = 0;
            targetVolume = _maxVolume;
            _source.Play();
        }
        else
        {
            targetVolume = _minVolume;
        }

        while (_source.volume != targetVolume)
        {
            _source.volume = Mathf.MoveTowards(_source.volume, targetVolume, _volumeRate * Time.deltaTime);
            Debug.Log(_source.volume);
            yield return null;
        }

        if (hasEntered == false)
            _source.Stop();
    }
}
