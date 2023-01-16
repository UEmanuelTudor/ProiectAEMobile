using ProiectAEMobile.Models;

namespace ProiectAEMobile;

public partial class ServiciuPage : ContentPage
{
    ProgramariList sl;
    public ServiciuPage(ProgramariList slist)
    {
        InitializeComponent();
        sl = slist;
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var serviciu = (Serviciu)BindingContext;
        await App.Database.SaveProductAsync(serviciu);
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var serviciu = (Serviciu)BindingContext;
        await App.Database.DeleteProductAsync(serviciu);
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Serviciu p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Serviciu;
            var lp = new ListServiciu()
            {
                ProgramariListID = sl.ID,
                ServiciuID = p.ID
            };
            await App.Database.SaveListProductAsync(lp);
            p.ListServicii = new List<ListServiciu> { lp };
            await Navigation.PopAsync();
        }
    }
}