using UnityEngine;

public class DamageOnContactWeapon : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger", this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision", this);
    }
}
