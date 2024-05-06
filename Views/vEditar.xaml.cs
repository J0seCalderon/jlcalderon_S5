using jlcalderon_S5.Modelos;

namespace jlcalderon_S5.Views;

public partial class vEditar : ContentPage
{
    private Persona persona;
    public vEditar(Persona persona)
	{
        InitializeComponent();
        this.persona = persona;
        BindingContext = this.persona;
    }

    private void GuardarCambios_Clicked(object sender, EventArgs e)
    {
        // Guardar los cambios en la base de datos
        App.personRepo.UpdatePerson(persona);
        // Mostrar mensaje de éxito o error
        //lblStatus.Text = App.personRepo.statusMessage;

        Navigation.PushAsync(new Views.vPersona());

    }

    private void bntCancelar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.vPersona());
    }
}