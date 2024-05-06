using jlcalderon_S5.Modelos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jlcalderon_S5
{
    public class PersonRepository
    {
        string _dbPath;
        private SQLiteConnection conn;
        public string statusMessage {  get; set; }

        public void Init()
        {
            if (conn is not null)
                return;
            conn = new(_dbPath);
            conn.CreateTable<Persona>();
        }
        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;   
        }
        public void AddNewPerson(string nombre)
        {
            int result = 0;
            try
            {
                Init();

                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("Nombre Requerido");

                Persona persona = new() { Name = nombre };
                result = conn.Insert(persona);

                statusMessage = string.Format("Dato Agregado", result, nombre); 
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("Error, no se inserto", nombre, ex.Message);
                //throw;
            }
        }
        public List<Persona> GetAllPeople()
        {
            try
            {
                Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("Error al mostrar los datos", ex.Message);
            }
            return new List<Persona>();
        }

        public void DeletePerson(string id)
        {
            try
            {
                Init();
                conn.Delete<Persona>(id);
                statusMessage = "Persona eliminada correctamente.";
            }
            catch (Exception ex)
            {
                statusMessage = $"Error al eliminar la persona: {ex.ToString()}";
            }
        }
        public void EditPerson(Persona persona)
        {
            try
            {
                Init();
                conn.Update(persona);
                statusMessage = "Persona actualizada correctamente.";
            }
            catch (Exception ex)
            {
                statusMessage = $"Error al actualizar la persona: {ex.Message}";
            }
        }
        public Persona GetPersonById(int id)
        {
            try
            {
                Init();
                return conn.Find<Persona>(id);
            }
            catch (Exception ex)
            {
                statusMessage = $"Error al obtener la persona: {ex.Message}";
                return null;
            }
        }
        public void UpdatePerson(Persona persona)
        {
            try
            {
                Init();
                conn.Update(persona);
                statusMessage = "Persona actualizada correctamente.";
            }
            catch (Exception ex)
            {
                statusMessage = $"Error al actualizar la persona: {ex.Message}";
            }
        }
    }
}
