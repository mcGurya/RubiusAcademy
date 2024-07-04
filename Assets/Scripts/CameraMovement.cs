using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject _playersCamera;
    [SerializeField] private GameObject _backCamera;
    [SerializeField] private GameObject spawnPoint;


    private Vector3 offset = new Vector3(0.0f, 3.0f, -15.0f);
    private bool _isWork = false;
    
    private Transform _target;

    void Update()
    {
        if (spawnPoint.transform.childCount != 0)
        {
            _target = spawnPoint.transform.GetChild(0);
        }else   
        {
            _target = spawnPoint.transform;
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
