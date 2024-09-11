using UnityEngine;

public class FoodCounterAnimation : MonoBehaviour
{
    private const string OPEN_CLOSE = "OpenClose";
    private Animator animator;

    [SerializeField]
    private FoodCounter foodCounter;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        foodCounter.OnPlayerGrabbingObject += FoodCounter_OnPlayerGrabbingObject; ;
    }

    private void FoodCounter_OnPlayerGrabbingObject(object sender, System.EventArgs e)
    {
        animator.SetTrigger(OPEN_CLOSE);
    }
}
