using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInputUI : MonoBehaviour
{
    [SerializeField] private bool destroy = true;
    void Start()
    {
#if UNITY_EDITOR
        if (!destroy)
        {
            return;
        }
#endif
        if (!Application.isMobilePlatform)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
