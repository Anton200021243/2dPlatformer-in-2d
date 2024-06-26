using UnityEngine;

[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(Mover))]
public class Player : MonoBehaviour
{
    [SerializeField] private Jumper _jumper;
    [SerializeField] private Mover _mover;

    private void Awake()
    {
        _jumper = GetComponent<Jumper>();
        _mover = GetComponent<Mover>();
    }

    private void FixedUpdate()
    {
        _mover.Move();
        _jumper.Jump();
    }  
}
