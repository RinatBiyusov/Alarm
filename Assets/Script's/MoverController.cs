using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoverController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        transform.Translate(movement * _speed * Time.deltaTime, Space.World);
    }
}
