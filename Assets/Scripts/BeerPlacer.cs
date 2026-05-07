using System.Collections;
using UnityEngine;

public class BeerPlacer : MonoBehaviour
{
    public GameObject BeerPrefab;
    void Update()
    {
        StartCoroutine(CountdownUnitlCreation());
    }

    IEnumerator CountdownUnitlCreation()
    {
        yield return new WaitForSeconds(2f);
        Place();
    }

    private void Place()
    {
        Instantiate(BeerPrefab, SpawnTools.RandomLocationWorldSpace(), Quaternion.identity);
    }
}
