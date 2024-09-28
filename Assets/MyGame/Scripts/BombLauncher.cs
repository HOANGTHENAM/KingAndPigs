using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLauncher : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject bombPrefab;
    public void FireBomb()
    {
        GameObject bomb = Instantiate(bombPrefab, launchPoint.position, bombPrefab.transform.rotation);
        Vector3 originalScale = bomb.transform.localScale;
        bomb.transform.localScale = new Vector3(originalScale.x * transform.localScale.x > 0 ? 1 : -1,
                                                originalScale.y, originalScale.z);
    }
}
