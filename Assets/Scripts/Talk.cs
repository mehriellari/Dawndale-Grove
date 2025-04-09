using UnityEngine;

//this is just a test script to see if interact works
public class Talk : Interactable
{
    public override void Interact(Character character)
    {

        Debug.Log("You talked!");
        
    }
}
