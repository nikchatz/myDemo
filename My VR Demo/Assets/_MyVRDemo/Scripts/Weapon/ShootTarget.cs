using System;
using UnityEngine;
using UnityEngine.Events;

public class ShootTarget : MonoBehaviour
{
    [Serializable] public class HitEvent : UnityEvent<int> { }
    public HitEvent onHit = new HitEvent();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            FigureOutScore(collision.transform.position);
        }
    }

    private void FigureOutScore(Vector3 hitPosition)
    {
        float distanceFromCenter = Vector3.Distance(transform.position, hitPosition);
        int score = 0;
        
        if (distanceFromCenter < 1.035f)
        {
            score = 25;
        }
        else
        {
            score = 5;
        }

        onHit.Invoke(score);
    }
}
