using UnityEngine;

[RequireComponent(typeof(InputPlayerReader))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private InputPlayerReader _inputManager;

    private void Awake()
    {
        _inputManager = GetComponent<InputPlayerReader>();
    }

    private void Update()
    {
        Vector3 direction = new Vector3(_inputManager.HorizontalInput, 0f, _inputManager.VerticalInput);

        transform.Translate(direction * _speed * Time.deltaTime, Space.World);
    }
}
