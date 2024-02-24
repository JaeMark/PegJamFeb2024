using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    private static HealthManager instance;

    // Public property to access the instance
    public static HealthManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<HealthManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(HealthManager).Name;
                    instance = obj.AddComponent<HealthManager>();
                }
            }
            return instance;
        }
    }

    // Event triggered whenever the health changes
    public UnityAction<int> OnHealthChanged;

    private int health = 3;

    // Public property to access the health
    public int Health
    {
        get { return health; }
        private set
        {
            // Trigger the health change event
            OnHealthChanged?.Invoke(health);
        }
    }

    public void UpdateHealth(int amount)
    {
        Health += amount;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}