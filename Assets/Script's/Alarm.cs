using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _volumeRate = 0.2f;
    [SerializeField] private Door _door;

    private readonly float _maxVolume = 1f;

    private AudioSource _source;
    private Coroutine _soundCoroutine;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _door.Entered += Activate;
        _door.Exited += Deactivate;
    }

    private void OnDisable()
    {
        _door.Entered -= Activate;
        _door.Exited -= Deactivate;
    }

    private void Activate()
    {
        if (_soundCoroutine != null)
            StopCoroutine(_soundCoroutine);

        _soundCoroutine = StartCoroutine(VolumeUp());
    }

    private void Deactivate()
    {
        if (_soundCoroutine != null)
            StopCoroutine(_soundCoroutine);

        _soundCoroutine = StartCoroutine(VolumeDown());
    }

    private IEnumerator VolumeUp()
    {
        _source.volume = 0;
        _source.Play();
        _source.loop = true;

        while (_source.volume != _maxVolume)
        {
            _source.volume = Mathf.MoveTowards(_source.volume, _maxVolume, _volumeRate * Time.deltaTime);

            yield return null;
        }
    }

    private IEnumerator VolumeDown()
    {
        while (_source.volume != 0)
        {
            _source.volume = Mathf.MoveTowards(_source.volume, 0, _volumeRate * Time.deltaTime);

            yield return null;
        }
    }
}
