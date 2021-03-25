using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class Pun : MonoBehaviourPunCallbacks
{
    private string gameVersion = "1";
    private string roomName = "launcherRoom";
    
    public void StartPun()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        Connect();
    }

    void Connect()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.GameVersion = gameVersion;
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    
    public override void OnConnectedToMaster()
    {
    Debug.Log("PUN: OnConnectedToMaster() was called by PUN");
         var roomOptions = new RoomOptions() {IsVisible = true, IsOpen = true, MaxPlayers = 20};
         var typedLobby = new TypedLobby(roomName, LobbyType.Default);
         PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, typedLobby);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("PUN: OnDisconnected() was called by PUN with reason {0}", cause);
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("PUN: OnCreatedRoom() called by PUN.");
    }

    public override void OnJoinedRoom()
    {
        
        Debug.Log("PUN: OnJoinedRoom() called by PUN. Now this client is in a room.");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogWarningFormat("PUN: OnJoinRoomFailed() called by PUN with reason {0}", message);
    }
}