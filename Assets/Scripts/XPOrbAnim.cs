using UnityEngine;

public class XPOrbAnim : MonoBehaviour
{
    [SerializeField] private Animator animator;
    void Start()
    {
        animator.Play("Orb Anim");
    }

}
