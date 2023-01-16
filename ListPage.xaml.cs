using ProiectAEMobile.Models;

namespace ProiectAEMobile;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (ProgramariList)BindingContext;
        slist.Data = DateTime.UtcNow;
        await App.Database.SaveShopListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (ProgramariList)BindingContext;
        await App.Database.DeleteShopListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ServiciuPage((ProgramariList)
       this.BindingContext)
        {
            BindingContext = new Serviciu()
        });

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (ProgramariList)BindingContext;

        listView.ItemsSource = await App.Database.GetListProductsAsync(shopl.ID);
    }

    async void OnDeleteItemButtonClicked(object sender, EventArgs e)
    {
        Serviciu serviciu;
        var shopList = (ProgramariList)BindingContext;
        if (listView.SelectedItem != null)
        {
            serviciu = listView.SelectedItem as Serviciu;
            var listProductAll = await App.Database.GetListProducts();
            var listProduct = listProductAll.FindAll(x => x.ServiciuID == serviciu.ID & x.ProgramariListID == shopList.ID);
            await App.Database.DeleteListProductAsync(listProduct.FirstOrDefault());
            await Navigation.PopAsync();
        }

    }
}