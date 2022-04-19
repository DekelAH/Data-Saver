using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StorageSystem
{
    public abstract class StorageSystem
    {
        #region Methods

        public void Save()
        {
            SaveInternal();
        }

        protected abstract void SaveInternal();

        public void Load()
        {
            LoadInternal();
        }

        protected abstract void LoadInternal();

        #endregion
    }
}
