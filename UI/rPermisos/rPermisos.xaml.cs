using Registro_Roles.BLL;
using Registro_Roles.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Registro_Roles.UI.rPermisos
{
    /// <summary>
    /// Lógica de interacción para rPermisos.xaml
    /// </summary>
    public partial class rPermisos : Window

    {
        private rPermiso Permiso;
        public rPermisos()
        {
            InitializeComponent();
            Permiso = new rPermiso();
            this.DataContext = Permiso;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var registro = rPermisosBLL.Buscar(Permiso.RolId);
            if (registro != null)
            {
                Permiso = registro;
                this.DataContext = Permiso;
            }
            else
            {
                MessageBox.Show("No se encontro el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (rPermisosBLL.Guardar(Permiso))
            {
                MessageBox.Show("Guardado", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se logro guardar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (rPermisosBLL.Eliminar(Permiso.RolId))
            {
                MessageBox.Show("Elimando", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se logro eliminar", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Limpiar()
        {
            Permiso = new rPermiso();
            this.DataContext = Permiso;
        }
    }
}
