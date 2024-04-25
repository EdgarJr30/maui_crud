using UNAD.Entity;
using UNAD.DAL;
using UNAD.Core;
using UNAD.Views;

namespace UNAD;

public partial class ListadoProvincias : ContentPage
{
    Manager db = new Manager();
    public ListadoProvincias()
	{
		InitializeComponent();
	
        Loaded += MainPage_Loaded;
	}

    private void MainPage_Loaded(object sender, EventArgs e)
    {
       
        getData();
    }

    private void getData()
    {
        dtgProvincias.ItemsSource = db.ProvinciasGet();
    }

    async void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
    {
        await App.Current.MainPage.Navigation.PushModalAsync(new ProvinciasAddOrEdit());
       
        getData();
    }

   async void SwipeItem_Clicked(System.Object sender, System.EventArgs e)
    {
        ProvinciasAddOrEdit view = new ProvinciasAddOrEdit();
        view.NUEVO = false;

        SwipeItem item = sender as SwipeItem;
        view.ProvinciaID = (item.BindingContext as clsProvinciasBE).ProvinciaID;
        await App.Current.MainPage.Navigation.PushModalAsync(view);
        getData();
    }

   async void SwipeItem_Clicked_1(System.Object sender, System.EventArgs e)
    {

        SwipeItem item = sender as SwipeItem;
        int ProvinciaID = (item.BindingContext as clsProvinciasBE).ProvinciaID;
        var response = db.ProvinciasDeleteGetByProvinciaID(ProvinciaID);
        await App.Current.MainPage.DisplayAlert("Mensaje", response, "Aceptar");
        getData();
    }
}


