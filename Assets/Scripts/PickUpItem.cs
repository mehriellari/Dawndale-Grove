using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//editable fields to adjust pick up speed and from what distance away
public class PickUpItem : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 5f;
    [SerializeField] float pickupDistance = 1.5f;
    [SerializeField] float ttl = 10f;

    public Item item;
    public int count = 1;


    private void Start()
    {
        player = GameManager.instance.player.transform;
    }

    //for rendering the sprite
    public void Set(Item item, int count)
    {
        this.item = item;
        this.count = count;

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = item.icon;
    }

    //setting a 10 sec time limit for dropped items before they are destroyed
    private void Update()
    {
        ttl -= Time.deltaTime;
        if (ttl < 0)
        {
            Destroy(gameObject);
        }

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > pickupDistance )
        {
            return;
        }
        //make an object move toward the player when within distance
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime);

        //adding item to inventory if you are within range
        if(distance < 0.1f)
        {
            
            if(GameManager.instance.inventoryContainer != null)
            {
                GameManager.instance.inventoryContainer.Add(item, count);
            }
            else
            {
                Debug.LogWarning("no inventory container attached to the game manager");
            }

                Destroy(gameObject);
        }
    }
}
