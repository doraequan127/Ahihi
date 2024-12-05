using UnityEngine;
using UnityEngine.AddressableAssets;

public class AhihiBeginSceneAdressables : MonoBehaviour
{
    [SerializeField] string address;
    [SerializeField] AssetReference reference;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Addressables.LoadSceneAsync(address);
            Addressables.LoadSceneAsync(reference);
        }
    }
}
