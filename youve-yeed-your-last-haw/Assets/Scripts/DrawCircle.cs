using UnityEngine;
using System.Collections;

public class DrawCircle : MonoBehaviour
{
    GameManager gameManager;

    private Vector2 initialScale = new Vector2(1,1);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        initialScale = transform.localScale;
        // Start the scaling coroutine when the object starts
        StartCoroutine(ScaleOverTime(Vector3.zero, gameManager.getDrawCountdown()));
    }

    IEnumerator ScaleOverTime(Vector3 targetScale, float timeToScale)
    {
        float timer = 0f;
        while (timer < timeToScale)
        {
            transform.localScale = Vector3.Lerp(initialScale, targetScale, timer / timeToScale);
            timer += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
    }
}
