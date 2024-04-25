namespace UNAD.Views;

public partial class PaisesAddOrEdit : ContentPage
{
	public bool NUEVO = true;
	string result = string.Empty;
	public int PaisID = 0;
    Core.Manager db = new Core.Manager();

    public PaisesAddOrEdit()
	{
		InitializeComponent();
        Loaded += PaisesAddOrEdit_Loaded;
	}

    private void PaisesAddOrEdit_Loaded(object sender, EventArgs e)
    {
        if(!NUEVO)
		{
			txtPais.Text = db.PaisesGetByPaisID(PaisID).Pais;
		}
    }

    async void  Button_Clicked(System.Object sender, System.EventArgs e)
    {
		if(string.IsNullOrEmpty(txtPais.Text))
		{
			await App.Current.MainPage.DisplayAlert("Mensaje", "Es necesario el nombre del pais", "Aceptar");
			txtPais.Focus();
			return;
		}

	
		if (NUEVO)
		{	
			 result = db.PaisesCreate(txtPais.Text);
		}
		else
		{
            result = db.PaisesUpdate(PaisID, txtPais.Text);
        }

        await App.Current.MainPage.DisplayAlert("Mensaje", result, "Aceptar");
		txtPais.Text = string.Empty;
		txtPais.Focus();

        await App.Current.MainPage.Navigation.PopModalAsync();
    }
}
