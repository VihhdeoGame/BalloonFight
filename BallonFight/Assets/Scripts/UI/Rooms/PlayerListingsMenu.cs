using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PlayerListingsMenu : MonoBehaviourPunCallbacks
{
   [SerializeField]
    private Transform content;
    [SerializeField]
    private PlayerListing playerListing;
    private RoomCanvases roomCanvases;

    private List<PlayerListing> listings = new List<PlayerListing>();
    public override void OnEnable()
    {
        base.OnEnable();
        GetCurrentRoomPlayers();       
    }
    public override void OnDisable()
    {
        base.OnDisable();
        for (int i = 0; i < listings.Count; i++)
            Destroy(listings[i].gameObject);
        listings.Clear();
    }
    public void FirstInitialize(RoomCanvases _canvases)
    {
        roomCanvases = _canvases;
    }

    private void GetCurrentRoomPlayers()
    {
        foreach(KeyValuePair<int, Player> _playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(_playerInfo.Value);
        }        
    }
    private void AddPlayerListing(Player _player)
    {
        int index = listings.FindIndex(x => x.Player == _player);
        if(index != -1)
        {
            listings[index].SetPlayerInfo(_player);
        }
        else
        { 
            PlayerListing _listing = Instantiate(playerListing, content);
            if(_listing != null)
            {
                _listing.SetPlayerInfo(_player);
                listings.Add(_listing);
            }
        }
    }
    public override void OnPlayerEnteredRoom(Player _newPlayer)
    {
        AddPlayerListing(_newPlayer);
    }
    public override void OnPlayerLeftRoom(Player _otherPlayer)
    {
        int index = listings.FindIndex(x => x.Player == _otherPlayer);
        if(index != -1)
        {
            Destroy(listings[index].gameObject);
            listings.RemoveAt(index);
        }        
    }
}
