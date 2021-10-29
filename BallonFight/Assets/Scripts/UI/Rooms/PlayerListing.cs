using System.Collections;
using System.Collections.Generic;
using System.Text;
using Photon.Realtime;
using TMPro;
using UnityEngine;

//Class responsible to display a player in a room
public class PlayerListing : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;
    public Player Player{ get; private set; }
    public void SetPlayerInfo(Player _player)
    {
        Player = _player;
        text.text = _player.NickName;
        text.color = GameManager.PlayerManager.playerColors[(_player.ActorNumber-1)%4];
    }
}
