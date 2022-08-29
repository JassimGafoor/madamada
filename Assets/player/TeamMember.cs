
using UnityEngine;
using Mirror;
public class TeamMember : NetworkBehaviour
{
    [SyncVar]
    public int teamID = 0;
    [SyncVar]
    public int playerID = 0;
}
