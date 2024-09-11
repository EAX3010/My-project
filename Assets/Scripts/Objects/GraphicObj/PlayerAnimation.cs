using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private const string IS_MOVING = "IsMoving";
    private Animator animator;

    [SerializeField]
    private Player Player;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        animator.SetBool(IS_MOVING, Player.IsMoving());
    }
}
