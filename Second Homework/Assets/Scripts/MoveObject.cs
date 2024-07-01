using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MoveObject : MonoBehaviour
{
    public float speed = 0.05f;
    public float rotation = 70.0f;

    public Transform PlayerTransform;
    private GameObject _initedPrefab;
    [SerializeField]private GameObject Prefab;
    
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerTransform == null)
        {
            PlayerTransform = transform; 
        }
    }

    //private void FixedUpdate()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.L))
        {
            if (_initedPrefab == null)
            {
                OnInstantiate();
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (_initedPrefab != null)
            {
                OnDestroy();
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            PlayerTransform.Translate(Vector3.forward * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            PlayerTransform.Translate(Vector3.back * speed );
        }
        if (Input.GetKey(KeyCode.A))
        {
            PlayerTransform.transform.Rotate(0, (-1) * rotation * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            PlayerTransform.transform.Rotate(0, rotation * Time.deltaTime, 0);
        }

    }

    private void OnDestroy()
    {
        Destroy(_initedPrefab);
    }

    private void OnInstantiate()
    {
        _initedPrefab = Instantiate(Prefab, new Vector3(50, 1, 50), Quaternion.identity);
    }

}



