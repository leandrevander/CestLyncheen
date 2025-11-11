using UnityEngine;

public class XPBarAnim : MonoBehaviour
{
    [SerializeField] private Animator animator;
    void Start()
    {
        animator.Play("Bar Anim");
    }
}
