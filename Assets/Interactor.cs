using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] Transform _interactionPoint;
    [SerializeField] float _interactionPointRadius = 0.5f;
    [SerializeField] LayerMask _interactableMask;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] int _numFound;

    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(
            _interactionPoint.position, 
            _interactionPointRadius, 
            _colliders, 
            _interactableMask);
    }
}
