using UnityEngine;

public class PlayerAnimatorData : MonoBehaviour
{
    public static readonly int HorizontalMove = Animator.StringToHash(nameof(HorizontalMove));
    public static readonly int Run = Animator.StringToHash(nameof(Run));
}
