using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class AhihiAdressables : MonoBehaviour
{
    [SerializeField] Image dcm;
    [SerializeField] AssetReference reference;               
    [SerializeField] AssetReferenceGameObject reference1;
    [SerializeField] AssetReferenceSprite reference2;
    [SerializeField] string address;
    AsyncOperationHandle<GameObject> handle;

    void Start()
    {
        reference.LoadAssetAsync<GameObject>().Completed += ((result) =>
        {
            if (result.Status == AsyncOperationStatus.Succeeded)
            {
                //Instantiate(reference.Asset);
                Instantiate(result.Result);
            }
            else Debug.LogError($"AssetReference {reference.RuntimeKey} failed to load.");
        });

        reference1.LoadAssetAsync().Completed += ((result) =>
        {
            if (result.Status == AsyncOperationStatus.Succeeded)
                Instantiate(result.Result);
            else Debug.LogError($"AssetReference {reference1.RuntimeKey} failed to load.");
        });

        reference2.LoadAssetAsync().Completed += ((result) =>
        {
            if (result.Status == AsyncOperationStatus.Succeeded)
                dcm.sprite = result.Result;
            else Debug.LogError($"AssetReference {reference2.RuntimeKey} failed to load.");
        });

        handle = Addressables.LoadAssetAsync<GameObject>(address);
        handle.Completed += ((result) =>
        {
            if (result.Status == AsyncOperationStatus.Succeeded)
                Instantiate(result.Result);
            else Debug.LogError($"Asset for {address} failed to load.");
        });
    }

    void OnDestroy()
    {
        reference.ReleaseAsset();
        reference1.ReleaseAsset();
        reference2.ReleaseAsset();
        handle.Release();
    }
}
