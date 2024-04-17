using UnityEngine;

public class HandleInput : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const KeyCode Space = KeyCode.Space;

    public float InputHorizontal()
    {
        return Input.GetAxisRaw(Horizontal);
    }

    public bool SpaceInput()
    {
        return Input.GetKeyDown(Space);
    }
}
