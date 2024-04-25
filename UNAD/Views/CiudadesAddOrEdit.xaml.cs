namespace UNAD.Views;

public partial class CiudadesAddOrEdit : ContentPage
{
	public bool NUEVO = true;
	string result = string.Empty;
	public int CiudadID = 0;
    Core.Manager db = new Core.Manager();

    public CiudadesAddOrEdit()
	{
		InitializeComponent();
        Loaded += CiudadesAddOrEdit_Loaded;
	}

    private void CiudadesAddOrEdit_Loaded(object sender, EventArgs e)
    {
        if(!NUEVO)
		{
			txtCiudad.Text = db.CiudadesGetByCiudadID(CiudadID).Ciudad;
			txtProvinciaID.Text = db.CiudadesGetByCiudadID(CiudadID).ProvinciaID.ToString();
		}
    }

    async void  Button_Clicked(System.Object sender, System.EventArgs e)
    {
		if(string.IsNullOrEmpty(txtCiudad.Text))
		{
			await App.Current.MainPage.DisplayAlert("Mensaje", "Es necesario el nombre del Ciudad", "Aceptar");
			txtCiudad.Focus();
			return;
		}

	
		if (NUEVO)
		{	
			 result = db.CiudadesCreate(txtCiudad.Text, int.Parse(txtProvinciaID.Text));
		}
		else
		{
            result = db.CiudadesUpdate(CiudadID, txtCiudad.Text, int.Parse(txtProvinciaID.Text));
        }

        await App.Current.MainPage.DisplayAlert("Mensaje", result, "Aceptar");
		txtCiudad.Text = string.Empty;
		txtCiudad.Focus();

        await App.Current.MainPage.Navigation.PopModalAsync();
    }
}
