using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;




public class TeamManager : NetworkManager
{
    public override void OnStartServer()
    {
        base.OnStartServer();

        NetworkServer.RegisterHandler<CreateTeamMessage>(OnCreateCharacter);
    }

    public override void OnClientConnect()
    {
        base.OnClientConnect();

        // you can send the message here, or wherever else you want
        CreateTeamMessage characterMessage = new CreateTeamMessage
        {
            team = 1,
            player = 1
        };

        NetworkClient.Send(characterMessage);
    }

    void OnCreateCharacter(NetworkConnectionToClient conn, CreateTeamMessage message)
    {
        // playerPrefab is the one assigned in the inspector in Network
        // Manager but you can use different prefabs per race for example
        GameObject gameobject = Instantiate(playerPrefab);

        // Apply data from the message however appropriate for your game
        // Typically Player would be a component you write with syncvars or properties
        TeamMember player = gameobject.GetComponent<TeamMember>();
        player.teamID = message.team;
        player.playerID = message.player;
        // call this to use this gameobject as the primary controller
        NetworkServer.AddPlayerForConnection(conn, gameobject);
    }
}

public struct CreateTeamMessage : NetworkMessage
{
    public int team;
    public int player;
}