using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    //[SerializeField] private Alarm _alarm;

    public event Action Entered;
    public event Action Exited;

    private void OnTriggerEnter(Collider thief)
    {
        Entered?.Invoke();

        thief.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    private void OnTriggerExit(Collider thief)
    {
        Exited?.Invoke();

        thief.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
