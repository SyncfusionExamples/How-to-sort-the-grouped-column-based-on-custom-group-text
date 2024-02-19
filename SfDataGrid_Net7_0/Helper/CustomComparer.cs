using SfDataGrid_Net7_0.Model;
using Syncfusion.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGrid_Net7_0
{
    public class CustomComparer : IComparer<object>, ISortDirection
    {
        public int Compare(object x, object y)
        {
            DateTime nameX = new DateTime();
            DateTime nameY = new DateTime();

            //While data object passed to comparer

            if (x.GetType() == typeof(SalesByDate))
            {
                nameX = ((SalesByDate)x).Date;
                nameY = ((SalesByDate)y).Date;
            }

            //While sorting groups

            else if (x.GetType() == typeof(Group))
            {

                //Calculating the group key length
                nameX = ((((Group)x).Records[0] as RecordEntry).Data as SalesByDate).Date;
                nameY = ((((Group)y).Records[0] as RecordEntry).Data as SalesByDate).Date;
            }

            //returns the comparison result based in SortDirection.

            if (nameX < nameY)
                return SortDirection == ListSortDirection.Ascending ? 1 : -1;

            else if (nameX > nameY)
                return SortDirection == ListSortDirection.Ascending ? -1 : 1;

            else
                return 0;
        }


        private ListSortDirection _SortDirection;

        /// <summary>
        /// Gets or sets the property that denotes the sort direction.
        /// </summary>
        /// <remarks>
        /// SortDirection gets updated only when sorting the groups. For other cases, SortDirection is always ascending.
        /// </remarks>

        public ListSortDirection SortDirection
        {
            get { return _SortDirection; }
            set { _SortDirection = value; }
        }
    }
}
