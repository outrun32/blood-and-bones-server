using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerSend
{
    private static void SendTCPData(int _toClient, Packet _packet)
    {
        _packet.WriteLength();
        Server.clients[_toClient].tcp.SendData(_packet);
    }
    private static void SendTCPDataToAll(Packet _packet)
    {
        _packet.WriteLength();
        for (int i = 1; i <= Server.MaxPlayers; i++)
        {
            Server.clients[i].tcp.SendData(_packet);
        }
    }
    private static void SendTCPDataToAll(int _exceptClient, Packet _packet)
    {
        _packet.WriteLength();
        for (int i = 1; i <= Server.MaxPlayers; i++)
        {
            if (i != _exceptClient)
            {
                Server.clients[i].tcp.SendData(_packet);
            }
        }
    }
    private static void SendUDPData(int _toClient, Packet _packet)
    {
        _packet.WriteLength();
        Server.clients[_toClient].udp.SendData(_packet);
    }

    private static void SendUDPDataToAll(Packet _packet)
    {
        _packet.WriteLength();
        for (int i = 1; i <= Server.MaxPlayers; i++)
        {
            Server.clients[i].udp.SendData(_packet);
        }
    }
    private static void SendUDPDataToAll(int _exceptClient, Packet _packet)
    {
        _packet.WriteLength();
        for (int i = 1; i <= Server.MaxPlayers; i++)
        {
            if (i != _exceptClient)
            {
                Server.clients[i].udp.SendData(_packet);
            }
        }
    }

    #region Packets
    public static void Welcome(int _toClient, string _msg)
    {
        using (Packet _packet = new Packet((int)ServerPackets.welcome))
        {
            _packet.Write(_msg);
            _packet.Write(_toClient);

            SendTCPData(_toClient, _packet);
        }
    }
<<<<<<< Updated upstream

    public static void SpawnPlayer(int _toClient, Player _player)
=======
    public static void SpawnPlayer(int _toClient, PlayerSpawnModel _player)
>>>>>>> Stashed changes
    {
        using (Packet _packet = new Packet((int)ServerPackets.spawnPlayer))
        {
            _packet.Write(_player.ID);
            _packet.Write(_player.Username);
            _packet.Write(_player.transform.position);
            _packet.Write(_player.transform.rotation);
            _packet.Write(_player.MAXHealth);
            _packet.Write(_player.MAXMana);
            _packet.Write(_player.StartHealth);
            _packet.Write(_player.StartMana);
                
            SendTCPData(_toClient, _packet);
        }
    }
    //TODO: 
    public static void PlayerPosition(Player _player)
    {
        using (Packet _packet = new Packet((int)ServerPackets.playerPosition))
        {
            _packet.Write(_player.ID);
            _packet.Write(_player.transform.position);

            SendUDPDataToAll(_packet);
        }
    }

    public static void PlayerRotation(Player _player)
    {
        using (Packet _packet = new Packet((int)ServerPackets.playerRotation))
        {
            _packet.Write(_player.ID);
            _packet.Write(_player.transform.rotation);

            SendUDPDataToAll(_player.ID, _packet);
        }
    }

    public static void PlayerDisconnected(int _playerId)
    {

        using (Packet _packet = new Packet((int)ServerPackets.playerDisconnected))
        {
            _packet.Write(_playerId);

            SendTCPDataToAll(_packet);
        }
    }
    public static void PlayerAnimation(Player _player)
    {
        using (Packet _packet = new Packet((int)ServerPackets.playerAnimataion))
        {
            _packet.Write(_player.ID);
            _packet.Write(_player.GetAnimationModel());
            SendTCPDataToAll(_packet);
        }
    }
    public static void PlayerInfo(Player _player)
    {
        using (Packet _packet = new Packet((int)ServerPackets.playerInfo))
        {
            _packet.Write(_player.ID);
            _packet.Write(_player.Health);
            _packet.Write(_player.Mana);
            SendTCPDataToAll(_packet);
        }
    }
    public static void PlayerDeath(Player _player)
    {
        using (Packet _packet = new Packet((int)ServerPackets.playerDeath))
        {
            _packet.Write(_player.ID);
            SendTCPDataToAll(_packet);
        }
    }
    #endregion
}
