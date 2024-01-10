using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitEntity : MonoBehaviour
{
    [SerializeField] private int _damageValue;

    private bool _hasHit;

    private BoxCollider _boxCollider;

    [SerializeField] private UnityEvent _onHit;

    private void Hit(GameObject target)
    {
        _hasHit = true;
        _onHit?.Invoke();
        target.transform.parent.GetComponent<EntityHealth>().DecreaseHealth(_damageValue);
    }

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
                //_hasHit = true;
                //other.transform.parent.GetComponent<EntityHealth>().DecreaseHealth(_damageValue);
                Hit(other.gameObject);
            }
        }
    }
}
