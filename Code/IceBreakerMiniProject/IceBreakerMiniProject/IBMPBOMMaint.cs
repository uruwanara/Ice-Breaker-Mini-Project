using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace IceBreakerMiniProject
{
    public class IBMPBOMMaint : PXGraph<IBMPBOMMaint, IBMPManufacturedItems>
    {
        #region Data Views
        public SelectFrom<IBMPManufacturedItems>.View ManufacturedProducts;
        public SelectFrom<IBMPBOM>.Where<IBMPBOM.manufacPartID.IsEqual<IBMPManufacturedItems.inventoryID.FromCurrent>>.View Components;
        #endregion

        #region Events
        /// <summary>
        /// Validate the components are not duplicated
        /// </summary>
        /// <param name="e"></param>
        protected void _(Events.FieldUpdated<IBMPBOM, IBMPBOM.manufacPartID> e)
        {
            IBMPBOM row = e.Row;

            if (row == null) return;

            var allRows = Components.Select();

            foreach (IBMPBOM item in allRows)
            {
                if (item.ManufacPartID == row.ManufacPartID)
                {
                    this.Components.Ask(Components.Current, "Warning", "Duplicated Components Location added!", MessageButtons.OK);
                    e.Cache.Remove(row.ManufacPartID);
                    break;
                }
            }
        }
        #endregion
    }
}