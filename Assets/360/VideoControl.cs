using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoControl : MonoBehaviour
{

    private UnityEngine.Video.VideoPlayer videoPlayer;
    private UnityEngine.Video.VideoPlayer videoPlayer2;
    public GameObject VideoScene;
    public GameObject VideoScene2;
    public GameObject blackScreen;
    public GameObject border;
    public GameObject credit;
    public Sprite[] sprite;
    public GameObject[] AudioObject;



    [SerializeField]
    private AudioSource audioSource;



    void Start()
    {
        videoPlayer = VideoScene.GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.Pause();

        videoPlayer2 = VideoScene2.GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer2.Pause();
        credit.SetActive(false);


        AudioObject[0].SetActive(true);
        AudioObject[1].SetActive(false);
        AudioObject[2].SetActive(false);


        if (videoPlayer.clip != null)
        {
            videoPlayer.EnableAudioTrack(0, true);
            videoPlayer.SetTargetAudioSource(0, audioSource);
        }
    }

    //Check if input keys have been pressed and call methods accordingly.
    void Update()
    {
       /*Play or pause the video.
        if (Input.GetKeyDown("space"))
        {
            if (videoPlayer.isPlaying)
                videoPlayer.Pause();
            else
                videoPlayer.Play();
                audioSource.Play();
        }
/*
        if (Input.GetMouseButtonDown(0))
        {
            if (videoPlayer.isPlaying)
                videoPlayer.Pause();
            else
                videoPlayer.Play();
            audioSource.Play();
        }
        */
    }


    public void playPause()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            GetComponent<Image>().sprite = sprite[0];
        }
        else
        {
            videoPlayer.Play();
            GetComponent<Image>().sprite = sprite[1];
            audioSource.Play();
        }
        
    }

    public void InitPlay()
    {
        StartCoroutine(_InitPlay());

    }

    public IEnumerator _InitPlay()
    {
        while (blackScreen.GetComponent<Renderer>().material.color.a > 0)
        {
            Color col = blackScreen.GetComponent<Renderer>().material.color;
            col.a = col.a - 0.01f;
            blackScreen.GetComponent<Renderer>().material.color = col;
            yield return new WaitForSeconds(0.02f);
        }
        videoPlayer.Play();
        blackScreen.SetActive(false);
        gameObject.transform.parent.gameObject.SetActive(false);
        audioSource.Play();
        AudioObject[1].SetActive(true);
        AudioObject[0].SetActive(false);


        //yield return null;
    }
    public void Playvideo2()
    {
        VideoScene2.SetActive(true);
        videoPlayer2.Play();
        VideoScene.SetActive(false);
        border.SetActive(false);
        credit.SetActive(true);
        AudioObject[0].SetActive(false);
        AudioObject[1].SetActive(false);
        AudioObject[2].SetActive(true);
    }


}