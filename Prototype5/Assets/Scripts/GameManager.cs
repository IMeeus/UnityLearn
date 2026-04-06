using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private float spawnRate = 1.0f;

    public List<GameObject> targets;

    void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    void Update()
    {
        DestroyTargetOnClick();
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    void DestroyTargetOnClick()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.CompareTag("Target"))
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
