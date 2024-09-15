using UnityEngine;

public class CuttingCounterAnimation : MonoBehaviour
{
    private const string Cut = "Cut";
    private Animator animator;

    [SerializeField]
    private CuttingCounter cuttingCounter;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        cuttingCounter.OnPlayerAltAction += CuttingCounter_OnPlayerAltAction; ;
    }

    private void CuttingCounter_OnPlayerAltAction(object sender, System.EventArgs e)
    {
        animator.SetTrigger(Cut);
    }
}
