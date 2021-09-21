using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

   private void Awake()
   {
       FirstInitialize();
   }

   private void FirstInitialize()
   {
       createOrJoinRoomCanvas.FirstInitialize(this);
       currentRoomCanvas.FirstInitialize(this);
       backgroundCanvas.FirstInitialize(this);
   }
}
