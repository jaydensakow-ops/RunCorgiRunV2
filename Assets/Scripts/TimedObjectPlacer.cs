using System.Collections;
using UnityEngine;

public class TimedObjectPlacer : MonoBehaviour
{
    public GameObject Prefab;
    
    public float minimumSecondsToWait;
    public float maximumSecondsToWait;

    private bool isOkToCreate = true;
    void Update()
    {
        if (isOkToCreate)
        {
            StartCoroutine(CountdownUnitlCreation());
        }
    }

    IEnumerator CountdownUnitlCreation()
    {
        isOkToCreate = false;
        
        float secondsToWait = Random.Range(minimumSecondsToWait, maximumSecondsToWait);
        yield return new WaitForSeconds(2f);
        Place();
        
        isOkToCreate = true;
    }

    protected virtual void Place()
    {
        Instantiate(Prefab, SpawnTools.RandomLocationWorldSpace(), Quaternion.identity);
    }
}
