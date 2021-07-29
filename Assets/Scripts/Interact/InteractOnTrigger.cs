using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractOnTrigger : MonoBehaviour
{
    public string playerTag = "Player";
    public Interactions interactions;
    public EditDataOnPickup editDataOnPickup;
    public DestroyOnPickup destroyOnPickup;

    private bool canTriggerInteraction = true;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(playerTag) && !other.gameObject.GetComponent<PlayerInteractions>().inInteraction && canTriggerInteraction)
        {
            interactions.Interact();
            StartCoroutine(waitToTriggerNewInteraction());

            if (editDataOnPickup != null)
            {
                editDataOnPickup.EditData();
            }

            if (destroyOnPickup != null)
            {
                destroyOnPickup.DestroyItem();
            }
        }
    }

    private IEnumerator waitToTriggerNewInteraction()
    {
        canTriggerInteraction = false;
        yield return new WaitForSeconds(.3f);
        canTriggerInteraction = true;
    }
}
