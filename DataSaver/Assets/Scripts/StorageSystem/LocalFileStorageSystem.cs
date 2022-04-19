using Assets.Infastructure;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.StorageSystem
{
    public class LocalFileStorageSystem : StorageSystem
    {
        #region Methods

        protected override void LoadInternal()
        {
            if (File.Exists(Application.dataPath + "/save.txt"))
            {
                string json = File.ReadAllText(Application.dataPath + "/save.txt");
                Debug.Log("Loaded: " + json);

                var playerModel = PlayerModelProvider.Instance.CurrentSaveOption;
                JsonUtility.FromJsonOverwrite(json, playerModel);


                playerModel.Initialize(playerModel.CoinsBalance, playerModel.GemsBalance);
            }
            else
            {
                Debug.Log("No Save!");
            }
        }

        protected override void SaveInternal()
        {
            var playerModel = PlayerModelProvider.Instance.CurrentSaveOption;
            string json = JsonUtility.ToJson(playerModel);
            File.WriteAllText(Application.dataPath + "/save.txt", json);

            Debug.Log("Saved!");
        }

        #endregion
    }
}
