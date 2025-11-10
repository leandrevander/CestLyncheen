using UnityEngine;

public class XPFillAnim : MonoBehaviour
{
    [SerializeField] private Animator animator;
    void Start()
    {
        animator.Play("Fill Anim");
    }
}
