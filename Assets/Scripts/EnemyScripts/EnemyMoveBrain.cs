using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveBrain : MonoBehaviour
{
    private bool _detectPlayer;

    private GameObject _target;

    public event Action OnDetectPlayer;

    public bool DetectPlayer { get => _detectPlayer; set => _detectPlayer = value; }
    public GameObject Target { get => _target; set => _target = value; }

    void CheckVisibility(GameObject target)
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position + new Vector3(0, 0, 1f), target.transform.position - transform.position, out hit, Mathf.Infinity))
        {
            Debug.Log(target.transform.name);
            Debug.Log(target.transform == hit.transform);
            Debug.DrawRay(transform.position + new Vector3(0, 0, 1f), (hit.point - (transform.position + new Vector3(0, 0, 1f))), Color.yellow);
            if(hit.transform == target.transform)
            {
                Debug.Log("See player");
                _target = target.gameObject;
                _detectPlayer = true;
                OnDetectPlayer?.Invoke();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other != null)
        {
            if (_detectPlayer == false)
            {
                if (other.transform.parent.GetComponentInChildren<PlayerMove>() != null && other.transform.GetComponent<HitEntity>() == null)
                {
                    Debug.Log("find player");
                    CheckVisibility(other.transform.parent.gameObject);
                }
            }
        }
    }

}
