using UnityEngine;

public class PoopPlacer : MonoBehaviour
{
    public GameObject PoopPrefab;
    public Sounds Sounds;
    public void Place(Vector3 position)
    {
        Instantiate(PoopPrefab, position, Quaternion.identity);
        Sounds.PlayPoopSound();
    }
}
