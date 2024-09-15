using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{ private static readonly int IdleState = Animator.StringToHash("Base Layer.idle");
    private static readonly int MoveState = Animator.StringToHash("Base Layer.move");
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
