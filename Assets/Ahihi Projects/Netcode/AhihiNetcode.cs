using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace TestNetcode
{
    public class AhihiNetcode : NetworkBehaviour
    {
        NetworkVariable<int> networkVariable = new NetworkVariable<int>();
        int pes;

        [ServerRpc]
        public void GuiLenServerRpc(ServerRpcParams rpcParams = default)
        {
            networkVariable.Value = 3;
            pes = 2017;
        }

        [ClientRpc]
        public void GuiXuongClientRpc()
        {
            print("Gui xuong client");
        }
    }
}