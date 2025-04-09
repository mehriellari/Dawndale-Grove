using UnityEngine;

public class CharacterInteractController : MonoBehaviour
{
    Movement2 characterMove;
    Rigidbody2D rb;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 0.5f;
    Character character;

    private void Awake()
    {
        characterMove = GetComponent<Movement2>();
        rb = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
    }

    //making right mouse button the interact button
    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Interact();
        }
    }

    //for interacting with objects if the character collider collides with another
    private void Interact()
    {
        Vector2 position = rb.position + characterMove.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach(Collider2D c in colliders)
        {
            Interactable hit = c.GetComponent<Interactable>();
            if(hit != null)
            {
                hit.Interact(character);
                break;
            }
        }
    }
}
