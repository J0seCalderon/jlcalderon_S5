using jlcalderon_S5.Modelos;
using Microsoft.Win32;

namespace jlcalderon_S5.Views;

public partial class vPersona : ContentPage
{
	public vPersona()
	{
		InitializeComponent();
    }

    private void bntAgregar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        App.personRepo.AddNewPerson(txtPersona.Text);
        lblStatus.Text = App.personRepo.statusMessage;
    }

    private void bntObtener_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        List<Persona> people = App.personRepo.GetAllPeople();
        ListaPersonas.ItemsSource = people;
    }

    private void bntEditar_Clicked(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.CommandParameter is int id)
        {
            // Obtener la persona a editar de la base de datos
            Persona persona = App.personRepo.GetPersonById(id);

            if (persona != null)
            {
                // Mostrar una página de edición de persona
                Navigation.PushAsync(new Views.vEditar(persona));
            }
            else
            {
                lblStatus.Text = "Error al obtener los datos de la persona.";
            }
        }
    }

    private void bntEliminar_Clicked(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.CommandParameter is int id)
        {
            App.personRepo.DeletePerson(id.ToString());
            lblStatus.Text = App.personRepo.statusMessage;
            bntObtener_Clicked(sender, e); // Actualizar la lista después de eliminar
        }
        else
        {
            lblStatus.Text = "Error al eliminar la persona.";
        }
    }
}