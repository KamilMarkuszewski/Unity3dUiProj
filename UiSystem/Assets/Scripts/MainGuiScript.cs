using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGuiScript : MonoBehaviour
{
    public Transform ObjectPrefab;
    public Transform PrefabLifeCounter;
    public Transform PrefabPlayButton;
    public Transform PrefabShowPoints;
    public Transform PrefabTimer;
    private string _buttonSize = "200";

    void Start()
    {
        UiSystemService.Instance.OnStart();
    }

    void Awake()
    {
        UiSystemService.Instance.OnAwake();
    }

    void Update()
    {
        UiSystemService.Instance.OnUpdate();
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 70, 30), "GameObj"))
        {
            float size;
            if (float.TryParse(_buttonSize, out size))
            {
                //dla uproszczenia interfejsu pozwalam definiowac wielkosc x i y naraz
                UiSystemService.Instance.AddGameButton(size, size, ObjectPrefab);
            }
            else
            {
                _buttonSize = "Błąd";
            }
        }

        if (GUI.Button(new Rect(90, 10, 50, 30), "UiObj"))
        {
            //dla uproszczenia interfejsu wrzuce wszystko od razu na sztywno
            UiSystemService.Instance.AddUiButton(1, 1, PrefabLifeCounter);
            UiSystemService.Instance.AddUiButton(0.1f, 0.1f, PrefabPlayButton);
            UiSystemService.Instance.AddUiButton(1f, 1f, PrefabShowPoints);
            UiSystemService.Instance.AddUiButton(1f, 1f, PrefabTimer);
        }

        if (GUI.Button(new Rect(150, 10, 100, 30), "1024x768 (4:3)"))
        {
            UiSystemService.Instance.SetResolution(1024f, 768f);
        }

        if (GUI.Button(new Rect(260, 10, 120, 30), "1600x1024 (16:10)"))
        {
            UiSystemService.Instance.SetResolution(1600f, 1024f);
        }

        if (GUI.Button(new Rect(390, 10, 100, 30), "750x1334 (6'')"))
        {
            UiSystemService.Instance.SetResolution(750f, 1334f);
        }

        if (GUI.Button(new Rect(500, 10, 100, 30), "480x800 (4.3'')"))
        {
            UiSystemService.Instance.SetResolution(480f, 800f);
        }

        GUI.Label(new Rect(610, 10, 50, 30), "Rozmiar");
        _buttonSize = GUI.TextField(new Rect(670, 10, 50, 30), _buttonSize);

        if (GUI.Button(new Rect(730, 10, 80, 30), "GRAJ"))
        {
            UiSystemService.Instance.SaveStateAndDestroyObjects();
            SceneManager.LoadScene("GameScene");
        }
    }
    




}
