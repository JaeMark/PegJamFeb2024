using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HealthDamager : MonoBehaviour
{
    public void DealDamage(int damage)
    {
        if (HealthManager.Instance != null)
        {
            HealthManager.Instance.UpdateHealth(damage);
        }
        else
        {
            Debug.LogError("HealthManager.Instance is null!");
        }
    }
}
