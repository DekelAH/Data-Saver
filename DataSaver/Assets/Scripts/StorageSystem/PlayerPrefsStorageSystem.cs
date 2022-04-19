using Assets.Infastructure;
using UnityEngine;

namespace Assets.Scripts.StorageSystem
{
    public class PlayerPrefsStorageSystem : StorageSystem
    {
        #region Methods

        protected override void LoadInternal()
        {
            var playerModel = PlayerModelProvider.Instance.CurrentSaveOption;
            playerModel.Initialize(PlayerPrefs.GetInt("coins"), PlayerPrefs.GetInt("gems"));
            Debug.Log("Loaded from PlayerPrefs!");
        }

        protected override void SaveInternal()
        {
            var playerModel = PlayerModelProvider.Instance.CurrentSaveOption;
            PlayerPrefs.SetInt("coins", playerModel.CoinsBalance);
            PlayerPrefs.SetInt("gems", playerModel.GemsBalance);
            PlayerPrefs.Save();
            Debug.Log("Saved to PlayerPrefs!");
        }

        #endregion
    }
}
