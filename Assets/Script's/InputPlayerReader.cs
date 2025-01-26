using UnityEngine;

public class InputPlayerReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    public float HorizontalInput { get; private set; }
    public float VerticalInput { get; private set; }

    private void Update()
    {
        HorizontalInput = Input.GetAxis(Horizontal);
        VerticalInput = Input.GetAxis(Vertical);
    }
}
