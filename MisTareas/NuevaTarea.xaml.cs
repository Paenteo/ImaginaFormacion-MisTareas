using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MisTareas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NuevaTarea : ContentPage
    {
        public NuevaTarea()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Animaciones_Imagen();
            AnimacionAsync();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Tarea tarea = new Tarea()
            {
                Nombre = nombreTarea.Text
            };

            // Utilizamos una using sentence, de modo que la variable conn 
            // sólo existe en este contexto y al finalizar la ejecución del bloque,
            // la variable conn es 'disposed' de forma equivalente 
            // (y mejor práctica) que usar: conn.Dispose();
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                // Creamos la tabla si no existe, y se inserta la nueva tarea. 
                // Si se inserta la fila con éxito,
                // se mostrará un aviso, y en caso contrario, otro distinto.
                conn.CreateTable<Tarea>();
                var numeroFilas = conn.Insert(tarea);

                if (numeroFilas > 0)
                    DisplayAlert("Success", "Tarea correctamente guardada.", "¡Bien!");
                else
                    DisplayAlert("Failure", "Fallo al guardar la tarea.", "¡Lo sentimos!");
            }
        }

        private void Animaciones_Imagen()
        {
            img_calendario.RotateTo(360, 2000, Easing.Linear);
            img_calendario.Rotation = 0;
            img_calendario.Opacity = 0;
            img_calendario.FadeTo(1, 2000);
        }
        private async Task AnimacionAsync()
        {
            uint duration = 10 * 60 * 1000;

            await Task.WhenAll(
              img_calendario2.RotateTo(307 * 360, duration),
              img_calendario2.RotateXTo(251 * 360, duration),
              img_calendario2.RotateYTo(199 * 360, duration)
            );
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            boxView.TranslationY -= 25;
        }
    }
}