using Lesconario.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LESCOnario.ViewModels
{
    public class EditarProfesorViewModel
    {
        Profesor p = new Profesor();
        public EditarProfesorViewModel() { }

        public void EditarProfesor(string nombre, string apellidos, int id, string email,
            string password, int telefono, int idU)
        {
            p.nombre = nombre;
            p.apellidos = apellidos;
            p.id = id;
            p.email = email;
            p.password = password;
            p.telefono = telefono;
            p.IsVisible = false;
            p.idU = idU;
        }

        public Profesor getProfesor()
        {
            return p;
        }

    }
}