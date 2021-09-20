using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class RoomListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform content;
    [SerializeField]
    private RoomListing roomListing;

    private List<RoomListing> listings = new List<RoomListing>();
    private RoomCanvases roomCanvases;

    public void FirstInitialize(RoomCanvases _canvases)
    {
        roomCanvases = _canvases;
        content.DestroyChildren();
        listings.Clear();
    }
    public override void OnEnable() 
    {
        base.OnEnable();

        
    }
    public override void OnJoinedRoom()
    {
        roomCanvases.CurrentRoomCanvas.Show();
    }
    public override void OnRoomListUpdate(List<RoomInfo> _roomList)
    {
        foreach (RoomInfo info in _roomList)
        {
            if(info.RemovedFromList)
            {
                int index = listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if(index != -1)
                {
                    Destroy(listings[index].gameObject);
                    listings.RemoveAt(index);
                }

            }
            else
            {
                int index = listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if(index == -1)
                {
                    RoomListing _listing = Instantiate(roomListing, content);
                    if(_listing != null)
                    {
                        _listing.SetRoomInfo(info);
                        listings.Add(_listing);
                    }
                }  
            }   
        }        
    }
}
