using UNAD.Entity;
using UNAD.DAL;
using UNAD.Core;
using UNAD.Views;

namespace UNAD;

public partial class ListadoCiudades : ContentPage
{
    Manager db = new Manager();
    public ListadoCiudades()
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
        dtgCiudades.ItemsSource = db.CiudadesGet();
    }

    async void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
    {
        await App.Current.MainPage.Navigation.PushModalAsync(new CiudadesAddOrEdit());
       
        getData();
    }

   async void SwipeItem_Clicked(System.Object sender, System.EventArgs e)
    {
        CiudadesAddOrEdit view = new CiudadesAddOrEdit();
        view.NUEVO = false;

        SwipeItem item = sender as SwipeItem;
        view.CiudadID = (item.BindingContext as clsCiudadesBE).CiudadID;
        await App.Current.MainPage.Navigation.PushModalAsync(view);
        getData();
    }

   async void SwipeItem_Clicked_1(System.Object sender, System.EventArgs e)
    {

        SwipeItem item = sender as SwipeItem;
        int CiudadID = (item.BindingContext as clsCiudadesBE).CiudadID;
        var response = db.CiudadesDeleteGetByCiudadID(CiudadID);
        await App.Current.MainPage.DisplayAlert("Mensaje", response, "Aceptar");
        getData();
    }
}


