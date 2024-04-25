using UNAD.Entity;
using UNAD.DAL;
using UNAD.Core;
using UNAD.Views;

namespace UNAD;

public partial class ListadoPaises : ContentPage
{
    Manager db = new Manager();
    public ListadoPaises()
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
        dtgPaises.ItemsSource = db.PaisesGet();
    }

    async void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
    {
        await App.Current.MainPage.Navigation.PushModalAsync(new PaisesAddOrEdit());
       
        getData();
    }

   async void SwipeItem_Clicked(System.Object sender, System.EventArgs e)
    {
        PaisesAddOrEdit view = new PaisesAddOrEdit();
        view.NUEVO = false;

        SwipeItem item = sender as SwipeItem;
        view.PaisID = (item.BindingContext as clsPaisesBE).PaisID;
        await App.Current.MainPage.Navigation.PushModalAsync(view);
        getData();
    }

   async void SwipeItem_Clicked_1(System.Object sender, System.EventArgs e)
    {

        SwipeItem item = sender as SwipeItem;
        int PaisID = (item.BindingContext as clsPaisesBE).PaisID;
        var response = db.PaisesDeleteGetByPaisID(PaisID);
        await App.Current.MainPage.DisplayAlert("Mensaje", response, "Aceptar");
        getData();
    }
}


