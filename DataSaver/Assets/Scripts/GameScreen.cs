using Assets.Infastructure;
using Assets.Scripts.Infastructure;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameScreen : MonoBehaviour
    {
        #region Fields

        [SerializeField]
        private int _coinsToAdd = 30;

        [SerializeField]
        private int _coinsToTake = 30;

        [SerializeField]
        private int _gemsToAdd = 1;

        [SerializeField]
        private int _gemsToTake = 1;

        #endregion

        #region Methods

        public void OnAddCoinsButtonClick()
        {
            var playerModel = PlayerModelProvider.Instance.CurrentSaveOption;
            playerModel.AddCoins(_coinsToAdd);
        }

        public void OnTakeCoinsButtonClick()
        {
            var playerModel = PlayerModelProvider.Instance.CurrentSaveOption;
            playerModel.WithdrawCoins(_coinsToTake);
        }

        public void OnAddGemsButtonClick()
        {
            var playerModel = PlayerModelProvider.Instance.CurrentSaveOption;
            playerModel.AddGems(_gemsToAdd);
        }

        public void OnTakeGemsButtonClick()
        {
            var playerModel = PlayerModelProvider.Instance.CurrentSaveOption;
            playerModel.WithdrawGems(_gemsToTake);
        }

        public void OnSaveBtnClick()
        {
            var dataManager = PlayerDataManager.Instance;
            dataManager.CheckSaveModelName();        
        }

        public void OnLoadBtnClick()
        {
            var dataManager = PlayerDataManager.Instance;
            dataManager.CheckLoadModelName();
        }

        #endregion
    }
}