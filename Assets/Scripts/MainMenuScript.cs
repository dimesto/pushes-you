using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

     public string playerwin;
     public string playerName;
    public string gameScene;

    NetworkManager manager;
    void Awake()
    {
        manager = GetComponent<NetworkManager>();
    }
    NetworkMatch matchMaker
    {
        get
        {

            if (!manager.matchMaker) manager.StartMatchMaker();
            return manager.matchMaker;
        }
    }

    public void exitApp()
    {
        Application.Quit();
    }

    public void playSolo()
    {
        CreateRoomLan();
    }

    public void CreateRoomLan()
    {
        StartCoroutine(LoadScene(manager.offlineScene, onCreateRoomLan));
    }
    void onCreateRoomLan()
    {
        NetworkServer.Listen(4444);
        manager.StartHost();
    }

    NetworkClient myClient;
    public void ConnectToServerLan(string serverIP)
    {
        myClient.Connect(serverIP, 4444);
        SceneManager.LoadScene(gameScene);

        StartCoroutine(LoadScene(manager.offlineScene, onConnectToServerLan));
    }
    public void onConnectToServerLan()
    {
        manager.StartClient();

    }
    delegate void callbacklan();
    IEnumerator LoadScene( string sceneName , callbacklan callback )
    {
        if (sceneName == "")
            yield break;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        callback();
    }

    public void playMultiOnline()
    {
        matchMaker.ListMatches(0, 5, "", true, 0, 0, OnMatchRefreshList);
    }
    public void OnMatchRefreshList(bool success, string extendedInfo, List<MatchInfoSnapshot> matches)
    {
        if (success)
        {
            Debug.Log("Online room list creat");
            if (matches.Count > 0)
            {
                matchMaker.JoinMatch(matches[0].networkId, "", "", "", 0, 0, OnMatchJoined);
            }
            else
            {
                matchMaker.CreateMatch("no Name", 3, true, "", "", "", 0, 0, OnMatchCreate);
            }
            SceneManager.LoadScene(gameScene);
        }
        else
        {
            Debug.LogError("Online list match failed: " + extendedInfo);
        }
    }
    public void OnMatchJoined(bool success, string extendedInfo, MatchInfo matchInfo)
    {
    }

    public void OnMatchCreate(bool success, string extendedInfo, MatchInfo matchInfo)
    {
    }


    public void disconect()
    {
        manager.StopClient();
        StartCoroutine(LoadScene("Scenes/menu", ondeco));
    }
    public void ondeco()
    {

    }
}
