using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEntity : MonoBehaviour
{
    [SerializeField] private int _damageValue;

    private bool _hasHit;

    private BoxCollider _boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if(!_boxCollider.enabled)
        {
            _hasHit = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other != null /*&& !_hasHit*/)
        {
            Debug.Log(other.name);
            if(other.transform.parent.GetComponent<EntityHealth>() != null && other.transform.GetComponent<HitEntity>() == null)
            {
                _hasHit = true;
                other.transform.parent.GetComponent<EntityHealth>().DecreaseHealth(_damageValue);
            }
        }
    }
}
