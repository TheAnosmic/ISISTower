using UnityEngine;
public class SceneManager : MonoBehaviour {

    [SerializeField]
    IDynamicStageEntity[] dynamicEntities;

	void Start () {
        foreach (IDynamicStageEntity entity in dynamicEntities)
        {
            entity.Spawn();
        }		
	}

    private void Update()
    {
        foreach (IDynamicStageEntity entity in dynamicEntities)
        {
            entity.UpdateMovement();
        }
    }
}
