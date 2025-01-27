using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    public event Action<bool> Entered;
    public event Action<bool> Exited;

    private bool _hasEntered = false;

    private void OnTriggerEnter(Collider thief)
    {
        if (thief.GetComponent<Thief>())
        {
            _hasEntered = true;
            Entered?.Invoke(_hasEntered);

            thief.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider thief)
    {
        if (thief.GetComponent<Thief>())
        {
            _hasEntered = false;
            Exited?.Invoke(_hasEntered);

            thief.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }
}
