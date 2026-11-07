using UnityEngine;
using UnityEngine.InputSystem;

public class Interacte : MonoBehaviour
{
    public int interactionRange = 3;
    public Transform transcam;
    public void Interact(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            return;
        }
        
        if (Physics.Raycast(transcam.position, transcam.forward, out RaycastHit hit, interactionRange))
        {
            Debug.Log("Interacted with " + hit.collider.gameObject.name);
            if (hit.collider.gameObject.CompareTag("item"))
            {
                hit.collider.gameObject.GetComponent<Item>().Items();
            }
        }

    }
}
