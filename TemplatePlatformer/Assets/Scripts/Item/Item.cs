using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private UnityEvent OnStayEvent;
    [SerializeField] private UnityEvent OnExitEvent;
    [SerializeField] private UnityEvent OnPickupEvent;
    protected GameObject player;

    private void Awake()
    {
    }

    void Start()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player = collision.gameObject;
            OnStay();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player = collision.gameObject;
            OnExit();
        }
    }

    protected virtual void OnStay()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Pickup();
        }
        OnStayEvent.Invoke();
    }

    protected virtual void OnExit()
    {
        OnExitEvent.Invoke();
    }

    protected virtual async Task Pickup()
    {
        await OnPickup();
        Destroy(gameObject);
    }
    
    protected virtual Task OnPickup()
    {
        OnPickupEvent.Invoke();
        return Task.CompletedTask;
    }
}
