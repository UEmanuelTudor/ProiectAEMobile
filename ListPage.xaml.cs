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
        await App.Database.SaveProgramariListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (ProgramariList)BindingContext;
        await App.Database.DeleteProgramariListAsync(slist);
        await Navigation.PopAsync();
    }

}