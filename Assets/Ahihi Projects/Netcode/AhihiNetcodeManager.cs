using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TestNetcode
{
    public class AhihiNetcodeManager : MonoBehaviour
    {
        public GameObject manUtdPrefab;
        GameObject manUtd;

        private void Start()
        {
            // Chỉnh địa chỉ IP, Port
            //NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData("127.0.0.1", 12345, "0.0.0.0");

            NetworkManager.Singleton.OnClientConnectedCallback += id =>
            {
                print("Vừa có 1 thằng tên là " + id + " connect");
            };

            NetworkManager.Singleton.OnClientDisconnectCallback += id =>
            {
                print("Thằng " + id + " vừa disconnect");
            };
        }

        public void BamNut(int id)
        {
            manUtd = Instantiate(manUtdPrefab);
            manUtd.GetComponent<NetworkObject>().Spawn();

            // Giống Spawn() nhưng sẽ gán quyền owner cho client (1), nghĩa là nếu client (1) disconnect thì nó cx sẽ tan biến cùng player local luôn
            //manUtd.GetComponent<NetworkObject>().SpawnWithOwnership((ulong)id);

            manUtd.GetComponent<NetworkObject>().ChangeOwnership((ulong)id);
            print(manUtd.GetComponent<NetworkObject>().OwnerClientId + " đang là chủ sở hữu của object mới tạo");

            // Trả quyền owner về với server
            //manUtd.GetComponent<NetworkObject>().RemoveOwnership();
        }

        public void BamNut2()
        {
            //Destroy(manUtd);
            manUtd.GetComponent<NetworkObject>().Despawn();
        }

        public void BamNut3(int id)
        {
            // Disconnect thằng mình muốn
            NetworkManager.Singleton.DisconnectClient((ulong)id);
        }

        public void BamNut4(int id)
        {
            print("ID hiện tại của client này là :  " + NetworkManager.Singleton.LocalClientId);

            // 2 dòng này chả khác gì nhau
            //NetworkManager.Singleton.ConnectedClients[(ulong)id].PlayerObject.gameObject.name = "mot con vit";
            //NetworkManager.Singleton.SpawnManager.GetPlayerNetworkObject((ulong)id).gameObject.name = "mot con vit";
        }

        public void BamNut5()
        {
            NetworkManager.Singleton.SceneManager.LoadScene("Netcode 2", LoadSceneMode.Single);
        }

        public void BamNut6()
        {
            // Disconnect khỏi server
            NetworkManager.Singleton.Shutdown();
        }    

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                print(NetworkManager.Singleton.ConnectedClients.Count);
            if (Input.GetKeyDown(KeyCode.Q))
                foreach (ulong uid in NetworkManager.Singleton.ConnectedClientsIds)
                    print(uid);
        }
    }
}