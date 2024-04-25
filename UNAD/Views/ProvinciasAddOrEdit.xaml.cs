namespace UNAD.Views;

public partial class ProvinciasAddOrEdit : ContentPage
{
	public bool NUEVO = true;
	string result = string.Empty;
	public int ProvinciaID = 0;
    Core.Manager db = new Core.Manager();

    public ProvinciasAddOrEdit()
	{
		InitializeComponent();
        Loaded += ProvinciasAddOrEdit_Loaded;
	}

    private void ProvinciasAddOrEdit_Loaded(object sender, EventArgs e)
    {
        if(!NUEVO)
		{
			txtProvincia.Text = db.ProvinciasGetByProvinciaID(ProvinciaID).Provincia;
			txtPaisID.Text = db.ProvinciasGetByProvinciaID(ProvinciaID).PaisID.ToString();
		}
    }

    async void  Button_Clicked(System.Object sender, System.EventArgs e)
    {
		if(string.IsNullOrEmpty(txtProvincia.Text))
		{
			await App.Current.MainPage.DisplayAlert("Mensaje", "Es necesario el nombre del Provincia", "Aceptar");
			txtProvincia.Focus();
			return;
		}

	
		if (NUEVO)
		{	
			 result = db.ProvinciasCreate(txtProvincia.Text, int.Parse(txtPaisID.Text));
		}
		else
		{
            result = db.ProvinciasUpdate(ProvinciaID, txtProvincia.Text, int.Parse(txtPaisID.Text));
        }

        await App.Current.MainPage.DisplayAlert("Mensaje", result, "Aceptar");
		txtProvincia.Text = string.Empty;
		txtProvincia.Focus();

        await App.Current.MainPage.Navigation.PopModalAsync();
    }
}
