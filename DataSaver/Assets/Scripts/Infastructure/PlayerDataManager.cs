using Assets.Infastructure;
using Assets.Models;
using Assets.Scripts.StorageSystem;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.Infastructure
{
    public class PlayerDataManager
    {
        #region Fields

        private static PlayerDataManager _instance;
        private readonly PlayerPrefsStorageSystem _playerPrefsStorage = new PlayerPrefsStorageSystem();
        private readonly LocalFileStorageSystem _localFileStorage = new LocalFileStorageSystem();

        #endregion

        #region Constructors

        private PlayerDataManager()
        {
            SubscribeToEvents();
        }

        #endregion

        #region Methods

        private void OnSaveCoinsToPref(int coins)
        {

        }

        private void OnSaveGemssToPref(int gems)
        {

        }

        private void SubscribeToEvents()
        {
            var playerModel = PlayerModelProvider.Instance.CurrentSaveOption;
            playerModel.CoinsBalanceChange += OnSaveCoinsToPref;
            playerModel.GemsBalanceChange += OnSaveGemssToPref;
        }

        public void SaveToPlayerPrefs()
        {
            _playerPrefsStorage.Save();
        }

        public void LoadPlayerPrefs()
        {
            _playerPrefsStorage.Load();
        }

        public void SaveToLocalFile()
        {
            _localFileStorage.Save();
        }

        public void LoadLocalFile()
        {
            _localFileStorage.Load();
        }

        public void CheckLoadModelName()
        {
            var playerModel = PlayerModelProvider.Instance.CurrentSaveOption;

            if (playerModel.ModelName == "PlayerPrefs")
            {
                LoadPlayerPrefs();
            }
            else
            {
                LoadLocalFile();
            }
        }

        public void CheckSaveModelName()
        {
            var playerModel = PlayerModelProvider.Instance.CurrentSaveOption;

            if (playerModel.ModelName == "PlayerPrefs")
            {
                SaveToPlayerPrefs();
            }
            else
            {
                SaveToLocalFile();
            }
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void CreateInstance()
        {
            _instance = new PlayerDataManager();
            Debug.Log("Player Data Manager Created");
        }

        #endregion

        #region Properties

        public static PlayerDataManager Instance => _instance;

        #endregion

    }
}
