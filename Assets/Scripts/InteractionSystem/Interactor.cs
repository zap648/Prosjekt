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
                if (interactable.Length > 1)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        interactable[0].Interact(this);
                    }
                    else if (Input.GetKeyDown(KeyCode.E))
                    {
                        interactable[1].Interact(this);
                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        interactable[0].Interact(this);
                    }
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E)) // By default, the player will drop the coal he has in his inventory in front of him
            {
                List<GameObject> playerInventory = GetComponent<Player>().inventory;
                if (playerInventory.Count > 0)
                {
                    playerInventory.Last().SetActive(true);
                    playerInventory.Last().transform.position = transform.position + Vector3.right * 2;
                    Debug.Log($"Dropped {playerInventory.Last().name}");
                    playerInventory.Remove(playerInventory.Last());
                }
                else
                {
                    Debug.Log("You have no coal to drop");
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
