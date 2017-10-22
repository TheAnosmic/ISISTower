using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


class MainMenuEventDispatcher : MonoBehaviour
{

    [SerializeField]
    private Button ConnectButton;
    [SerializeField]
    private InputField ConnectHostInput;


    [SerializeField]
    private Button HostButton;
    [SerializeField]
    private Button OptionsButton;
    [SerializeField]
    private Button QuitButton;

    public delegate void ConnectClick(String host, int port);

    public event ConnectClick OnConnectClick;

    public delegate void ButtonClick();

    public event ButtonClick OnHostClicked;
    public event ButtonClick OnOptionsClicked;
    public event ButtonClick OnQuitClicked;

    void Start()
    {
        ConnectButton.onClick.AddListener(HandleConnectButtonClicked);
        HostButton.onClick.AddListener(HandleHostButtonClicked);
        OptionsButton.onClick.AddListener(HandleOptionsButtonClicked);
        QuitButton.onClick.AddListener(HandleQuitButtonClicked);

        OnConnectClick += (host, port) =>
        {
            Debug.Log("Clicked connect with " + host + ":" + port);
        };

        OnHostClicked += () => { Debug.Log("Host Clicked"); };
        OnOptionsClicked += () => { Debug.Log("Options Clicked"); };
        OnQuitClicked += () =>
        {
            Debug.Log("Quit Clicked");
            Application.Quit();
        };
    }

    private void HandleConnectButtonClicked()
    {
        if (OnConnectClick == null)
        {
            return;
        }

        var host = ConnectHostInput.text;
        var parts = host.Split(':');
        host = parts[0];
        var port = int.Parse(parts[1]);
        OnConnectClick(host, port);

    }

    private void HandleHostButtonClicked()
    {
        if (OnHostClicked != null)
        {
            OnHostClicked();
        }
    }

    private void HandleOptionsButtonClicked()
    {
        if (OnOptionsClicked != null)
        {
            OnOptionsClicked();
        }
    }

    private void HandleQuitButtonClicked()
    {
        if (OnQuitClicked != null)
        {
            OnQuitClicked();
        }
    }
}