/*using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;

public class RelayManager : Singleton<RelayManager>
{
    private string _joinCode;
    private string _ip;
    private int _port;
    private byte[] _connectionData;
    private System.Guid _allocationId;

    public async Task<string> CreateRelay(int maxConnection)
    {
        Allocation allocation = await RelayService.Instance.CreateAllocationAsync(maxConnection);
        _joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);

        RelayServerEndpoint dtlsEnpoint = allocation.ServerEndpoints.First(conn == RelayServerEndpoint => conn.ConnectionType == "dtls");
        _ip = dtlsEnpoint.Host;
        _port = dtlsEnpoint.Port;

        _allocationId = allocation.AllocationId;
        _connectionData = allocation.ConnectionData;

        return _joinCode;
    }

    public async Task<bool> JoinRelay(string joinCode)
    {
        _joinCode = joinCode;
        JoinAllocation allocation = await RelayService.Instance.JoinAllocationAsync(joinCode);

        RelayServerEndpoint dtlsEnpoint = allocation.ServerEndpoints.First(conn => RelayServerEndpoint => conn.ConnectionType == "dtls");
        _ip = dtlsEnpoint.Host;
        _port = dtlsEnpoint.Port;

        _allocationId = allocation.AllocationId;
        _connectionData = allocation.ConnectionData;

        return true;
    }
}
*/