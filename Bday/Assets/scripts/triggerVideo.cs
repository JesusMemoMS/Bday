using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class triggerVideo : MonoBehaviour
{
    private VideoPlayer video;
    private double duracion;
    public GameObject gameplayUI;
    void OnTriggerEnter2D(Collider2D other)
    {
        video = GetComponent<VideoPlayer>();
        gameplayUI.SetActive(false);
        video.Play();
        duracion = video.length;
        reactivate((float)video.length);
    }

    IEnumerator reactivate(float segundos)
    {
        yield return new WaitForSeconds(segundos);
        gameplayUI.SetActive(true);
    }
}
