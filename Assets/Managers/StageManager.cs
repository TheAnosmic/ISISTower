using UnityEngine;
using System.Collections.Generic;

public class StageManager : MonoBehaviour {

    [SerializeField]
    private static List<IDynamicStageEntity> dynamicEntities = new List<IDynamicStageEntity>();

    public static void AddDynamicEntity(IDynamicStageEntity entity)
    {
        dynamicEntities.Add(entity);
    }

	void Start () {
        foreach (IDynamicStageEntity entity in dynamicEntities)
        {
            entity.Spawn();
        }		
	}

    private void FixedUpdate()
    {
        Debug.Log("updating stage");
        foreach (IDynamicStageEntity entity in dynamicEntities)
        {
            entity.UpdateEntity();
        }
    }
}
