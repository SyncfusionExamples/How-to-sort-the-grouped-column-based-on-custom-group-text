# How to sort the grouped column based on custom group text

In the [WPF DataGrid](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfDataGrid.html) (SfDataGrid), when we applying the [Custom grouping](https://help.syncfusion.com/wpf/datagrid/grouping#custom-grouping), the default sorting behavior applied for custom text. It sorts the view based on key values only when grouped the columns. However, this behavior can be customized using the  [SortComparer](https://help.syncfusion.com/cr/wpf/Syncfusion.Data.SortComparer.html) method to achieve sorting based on custom group property values.
```C#
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
```
You can attach this in the Xaml code by using the below mentioned code snippet,
```Xml
<window.resources>
    <local:groupdatatimeconverter x:key="customGroupDateTimeConverter">
    <local:customcomparer x:key="Comparer">
</local:customcomparer></local:groupdatatimeconverter></window.resources>


<syncfusion:sfdatagrid.sortcomparers>
    <linq:sortcomparer comparer="{StaticResource Comparer}" propertyname="Date">
</linq:sortcomparer></syncfusion:sfdatagrid.sortcomparers>
```
 ![SfDataGrid_SortComparer.gif](https://support.syncfusion.com/kb/agent/attachment/article/14456/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjE1MDIxIiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.vkjwdPL51SEBpXWyyn63yv3cNruEZE2YPu9urTN5hwg)
 
Take a moment to peruse the [WPF DataGrid - Custom Sorting](https://help.syncfusion.com/wpf/datagrid/sorting#custom-sorting) documentation, where you can find about the clipboard operations with code examples.</object>

