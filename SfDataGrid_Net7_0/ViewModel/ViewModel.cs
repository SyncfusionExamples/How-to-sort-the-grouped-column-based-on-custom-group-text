using SfDataGrid_Net7_0.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGrid_Net7_0
{
    class SalesInfoViewModel
    {
        public SalesInfoViewModel()
        {

        }

        private ObservableCollection<SalesByDate> _DailySalesDetails = null;

        public ObservableCollection<SalesByDate> DailySalesDetails
        {
            get
            {
                if (_DailySalesDetails == null)
                    return new SalesInfoRepository().GetSalesDetailsByDay(60);
                else
                    return _DailySalesDetails;
            }

        }
    }
}
