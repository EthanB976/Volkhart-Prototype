using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    [SerializeField] AlienBase alienBase;

    private void Start()
    {
        alienBase = GetComponent<AlienBase>();
    }
    private void Update()
    {
        if (alienBase.stunned)
        {
            return;
        }
    }
}
