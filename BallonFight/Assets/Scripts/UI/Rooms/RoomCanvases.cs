using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class responsible to organize the other canvases
public class RoomCanvases : MonoBehaviour
{
   [SerializeField]
   private CreateOrJoinRoomCanvas createOrJoinRoomCanvas;
   public CreateOrJoinRoomCanvas CreateOrJoinRoomCanvas {get { return createOrJoinRoomCanvas; } }
   [SerializeField]
   private CurrentRoomCanvas currentRoomCanvas;
   public CurrentRoomCanvas CurrentRoomCanvas {get { return currentRoomCanvas; } }
   [SerializeField]
   private BackgroundCanvas backgroundCanvas;
   public BackgroundCanvas BackgroundCanvas {get { return backgroundCanvas; } }
   [SerializeField]
   private LobbyManager lobbyManager;
    public LobbyManager LobbyManager{get { return lobbyManager; } }
   private void Awake()
   {
       FirstInitialize();
   }

   private void FirstInitialize()
   {
       lobbyManager.FirstInitialize(this);
       createOrJoinRoomCanvas.FirstInitialize(this);
       currentRoomCanvas.FirstInitialize(this);
       backgroundCanvas.FirstInitialize(this);
   }
}
