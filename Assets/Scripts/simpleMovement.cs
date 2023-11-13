using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class simpleMovement : NetworkBehaviour
{
    private void Update()
    {
        if (!IsOwner) 
            return;

        if (IsClient)
        {
            Vector3 moveDirection = Vector3.zero;

            if (Input.GetKey(KeyCode.W)) {  moveDirection.y = +1; }
            if (Input.GetKey(KeyCode.S)) {  moveDirection.y = -1; }
            if (Input.GetKey(KeyCode.D)) {  moveDirection.x = +1; }
            if (Input.GetKey(KeyCode.A)) {  moveDirection.x = -1; }

            float speed = 3f;

            transform.position += moveDirection * speed * Time.deltaTime; 
        }
    }
}
