using System.Collections.ObjectModel;

public class CategoryModel
{
    public string CategoryName { get; set; }

    public ObservableCollection<ValueModel> Values { get; set; }

    public CategoryModel()
    {
        Values = new ObservableCollection<ValueModel>();
    }
}
