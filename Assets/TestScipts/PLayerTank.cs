using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class PLayerTank : MonoBehaviour
{
    
    [Header("Movement Data")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    private Rigidbody _rb;
   [SerializeField] private float _verticalInput;
   [SerializeField] private float _horizontalInput;

   [SerializeField] private Transform _aimTranform;
   [SerializeField] private LayerMask _aimLayer;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update() 
    {
        _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");
        AIM();
    }

    private void FixedUpdate() 
    {
        _rb.AddForce(transform.forward * _moveSpeed * _verticalInput);

        Vector3 move = transform.forward * _moveSpeed * _verticalInput;

        _rb.velocity = move;
        //_rb.velocity = new Vector3(0, 0, _moveSpeed * _verticalInput);
        if(_verticalInput >= 0 )
        {
            transform.Rotate(0, _horizontalInput * _rotationSpeed, 0);
        }
        else
        {
            transform.Rotate(0, -_horizontalInput * _rotationSpeed, 0);
        }
        
    }

    void AIM()
    {
        //Raycast

      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

      RaycastHit hit;

      if (Physics.Raycast(ray, out hit, Mathf.Infinity, _aimLayer)) 
      {
          Debug.Log($" Hit points: {hit.point}");
          _aimTranform.position = hit.point;
      }
  }

}
    
