using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        if (_numFound > 0)
        {
            IInteractable[] interactable = _colliders[0].GetComponents<IInteractable>();

            if (interactable != null) 
            {
                //if (interactable.Length > 1)
                //{
                //    if (Input.GetKeyDown(KeyCode.Space))
                //    {
                //        interactable[0].Interact(this);
                //    }
                //    else if (Input.GetKeyDown(KeyCode.E))
                //    {
                //        interactable[1].Interact(this);
                //    }
                //}
                //else
                //{
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        interactable[0].Interact(this);
                    }
                //}
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
