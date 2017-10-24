using UnityEngine;

[RequireComponent(typeof(IController))]
public class Player : MonoBehaviour, IDynamicStageEntity {

    [SerializeField]
    private IController controller;

    [SerializeField]
    private Transform spawnPosition;

    private IPickup _pickup;

    public void Start()
    {
        controller = GetComponent<IController>();
        StageManager.AddDynamicEntity(this);
    }

    public void Spawn()
    {
        transform.position = spawnPosition.position;
    }

    public void UpdateEntity()
    {
        controller.UpdateMovement();
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            if (_pickup == null)
            {
                _pickup = other.GetComponent<PickupSpawner>().Pickup();
                _pickup.Use(this);
                _pickup = null;
            }
        }
    }
}
