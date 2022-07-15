using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Exercise2_1.Models;
using Exercise2_1.Controllers;
using System.Reflection;

namespace Exercise2_1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Principal : ContentPage
    {
        public Principal()
        {
            InitializeComponent();
        }

        private async void listaContinentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelMostrarpais.IsVisible = true;
            if (Connectivity.NetworkAccess != NetworkAccess.Internet) 
            {
                await DisplayAlert("INFO", "Parece que no tienes Conexion!", "OK");
            }
            else 
            {
                var objetopicker = (Picker)sender;
                if (objetopicker.SelectedIndex == 0)
                {
                    List<Paises.Pais> listPaises = new List<Paises.Pais>();
                    listPaises = await PaisesController.getPaisesAf();
                    listaPais.ItemsSource = listPaises;
                }
                if (objetopicker.SelectedIndex == 1)
                {
                    List<Paises.Pais> listPaises = new List<Paises.Pais>();
                    listPaises = await PaisesController.getPaisesA();
                    listaPais.ItemsSource = listPaises;
                }
                if (objetopicker.SelectedIndex == 2)
                {
                    List<Paises.Pais> listPaises = new List<Paises.Pais>();
                    listPaises = await PaisesController.getPaisesAs();
                    listaPais.ItemsSource = listPaises;
                }
                if (objetopicker.SelectedIndex == 3)
                {
                    List<Paises.Pais> listPaises = new List<Paises.Pais>();
                    listPaises = await PaisesController.getPaisesE();
                    listaPais.ItemsSource = listPaises;
                }
                if (objetopicker.SelectedIndex == 4)
                {
                    List<Paises.Pais> listPaises = new List<Paises.Pais>();
                    listPaises = await PaisesController.getPaisesOs();
                    listaPais.ItemsSource = listPaises;
                }
            }
        }

        private async void listaPais_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //se obtiene el objeto pais de la lista
            Paises.Pais pais = (Paises.Pais)e.SelectedItem;
            string nombre = pais.name.common;
            //Se busca en otro http request a otro mismo api pero mas ordenado para sacar algunos valores donde solo se busca por pais
            List<Pais2> list = new List<Pais2>();
            list = await PaisesController.getOnePais(nombre);
            string capital = list[0].capital;
            string moneda = list[0].currencies[0].name;
            string lenguaje = list[0].languages[0].nativeName;
            Double Latitud = pais.latlng[0];
            Double Longitud = pais.latlng[1];

            LatiLongi paisubicacion = new LatiLongi
            {
                latitud = Latitud, longitud = Longitud, CapitalPais = capital, nombrePais = nombre, moneda = moneda, lenguaje = lenguaje
            };
            //se manda al mapa toda la info
            Mapita map = new Mapita();
            map.BindingContext = paisubicacion;
            map.Title = "COORDENADAS: " + Latitud + "," + Longitud;
            await Navigation.PushAsync(map);
        }
    }
}