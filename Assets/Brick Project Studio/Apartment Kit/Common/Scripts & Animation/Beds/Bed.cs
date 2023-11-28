using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bed : MonoBehaviour
{
    public Transform Player;
    public bool clicked;

    private const float QUIET_THRESHOLD = 0.0001f; // adjust this value to change the sensitivity of the check
    private const float QUIET_TIME_THRESHOLD = 5.0f; // adjust this value to change the time required for audio to be quiet

    private float quietTime;

    void Start()
    {
        clicked = false;
        quietTime = 0.0f;
    }

    void OnMouseOver()
    {
        float[] samples = new float[1024];
        AudioListener.GetOutputData(samples, 0);
        bool isQuiet = true;
        for (int i = 0; i < samples.Length; i++)
        {
            if (Mathf.Abs(samples[i]) > QUIET_THRESHOLD)
            {
                isQuiet = false;
                break;
            }
        }

        if (isQuiet)
        {
            quietTime += Time.deltaTime;
            if (quietTime >= QUIET_TIME_THRESHOLD)
            {
                if (Player)
                {
                    float dist = Vector3.Distance(Player.position, transform.position);
                    if (dist < 15)
                    {
                        if (clicked == false)
                        {
                            if (Input.GetMouseButtonDown(0))
                            {
                                clicked = true;
                                SceneManager.LoadScene("End");
                            }
                        }
                    }
                }
            }
        }
        else
        {
            quietTime = 0.0f;
        }
    }
}