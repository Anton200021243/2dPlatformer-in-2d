using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorData : MonoBehaviour
{
    public static class Params
    {
        public static readonly int HorizontalMove = Animator.StringToHash(nameof(HorizontalMove));
    }
}
