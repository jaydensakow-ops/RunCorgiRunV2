using UnityEngine;

public class MoonshinePlacer : TimedObjectPlacer
{
    public void Start()
    {
            minimumSecondsToWait = GameParameters.MoonshineMinimumSecondsToWait;
            maximumSecondsToWait = GameParameters.MoonshineMaximumSecondsToWait;
    }
    
    protected override void Place()
    {
        Instantiate(Prefab, SpawnTools.RandomTopOfScreenLocationWorldSpace(), 
            Quaternion.identity);
    }
}
