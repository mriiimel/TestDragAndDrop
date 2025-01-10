using UnityEngine;


public class AppleView : MonoBehaviour
{
    [SerializeField] private Collider2D _appleCollider;
    

    private AppleController _appleController;

    

    public void DisableCollider()
    {
        _appleCollider.enabled = false;
    }

    public void EnebleCollider()
    {
        _appleCollider.enabled = true; 
    }
}
