using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject _playersCamera;
    [SerializeField] private GameObject _backCamera;
    private Vector3 offset = new Vector3(0.0f, 3.0f, -10.0f);
    private bool _isWork = false;
    
    private Transform _target;

    void Update()
    {
        if(_target == null)
        {
            _target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        _playersCamera.transform.position = _target.position + offset;

        _playersCamera.transform.LookAt(_target);
        _backCamera.transform.LookAt(_target.position);

        if (Input.GetKeyDown(KeyCode.V))
        {
            _backCamera.SetActive(_isWork);
            _isWork = (_isWork == false) ? true : false;
        }

    }
}
