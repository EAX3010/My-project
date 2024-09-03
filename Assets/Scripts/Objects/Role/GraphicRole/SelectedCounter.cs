using UnityEngine;

public class SelectedCounter : MonoBehaviour
{
    public void Enable()
    {
        this.gameObject.SetActive(true);

    }
    public void Disable()
    {
        this.gameObject.SetActive(false);
    }
}
