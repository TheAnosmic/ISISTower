using UnityEngine;

[RequireComponent(typeof(IController))]
public class Player : MonoBehaviour, IDynamicStageEntity {

    [SerializeField]
    private IController controller;

    [SerializeField]
    private Transform spawnPosition;

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
}
