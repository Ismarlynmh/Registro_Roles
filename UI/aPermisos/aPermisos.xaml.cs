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

namespace Registro_Roles.UI.aPermisos
{
    /// <summary>
    /// Interaction logic for aPermiso.xaml
    /// </summary>
    public partial class aPermisos : Window

    {
        private aPermiso Permisoo;
        private rPermiso Permiso;
        public aPermisos()
        {
            InitializeComponent();
            Permiso = new rPermiso();
            this.DataContext = Permiso;
            //Llenamos el combobox
            RolIdComboBox.ItemsSource = rPermisosBLL.GetList(X => true);
            RolIdComboBox.SelectedValue = "RolId";
            RolIdComboBox.DisplayMemberPath = "PermisoId";
        }
       
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var registro = aPermisosBLL.Buscar(Permisoo.RolId);
            if (registro != null)
            {
                Permisoo = registro;
                this.DataContext = Permisoo;
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
            if (aPermisosBLL.Guardar(Permisoo))
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
            if (aPermisosBLL.Eliminar(Permisoo.RolId))
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
            Permisoo = new aPermiso();
            this.DataContext = Permisoo;
        }

        private void ButtonAgregar_Click(object sender, RoutedEventArgs e)
        {
            var detalle = new aPermisosDetalle
            {
                Permiso = Permiso,
                RolId = Permisoo.RolId
            };

            Permisoo.aPermisosDetalle.Add(detalle);
            Cargar();
            RolIdComboBox.SelectedIndex = -1;
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.SelectedIndex != -1)
            {
                Permisoo.aPermisosDetalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Permisoo;
        }

        private void RolIdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RolIdComboBox.SelectedIndex != -1)
            {
                Permiso = (rPermiso)RolIdComboBox.SelectedItem;
                Permiso.RolId = 0;
            }
        }
       
    }
}
