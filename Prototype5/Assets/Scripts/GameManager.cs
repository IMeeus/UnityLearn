using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private float spawnRate = 1.0f;

    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;

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
                var hitGameObject = hit.collider.gameObject;
                if (hitGameObject.CompareTag("Target"))
                {
                    var target = hitGameObject.GetComponent<Target>();
                    AddScore(target.pointValue);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }

    private void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.SetText("Score: " + score);
    }
}
