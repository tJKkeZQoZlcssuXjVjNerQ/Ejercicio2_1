using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Diagnostics;

namespace Exercise2_1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mapita : ContentPage
    {

        public Mapita()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            String NombreP = txtNombre.Text;
            String CapitalP = txtCapital.Text;
            double Latitud = Convert.ToDouble(txtLatitud.Text);
            double Longitud = Convert.ToDouble(txtLongitud.Text);
            String Mmoneda = txtMoneda.Text;
            String Lang = txtidioma.Text;
            //CREANDO EL OBJETO PIN
            Pin pin = new Pin
            {
                Label = "Pais: " + NombreP + " Capital: " + CapitalP,
                Address = "Moneda: " + Mmoneda + " Lenguaje: " + Lang,
                Type = PinType.Generic,
                Position = new Position(Latitud, Longitud)
            };
            Maps.Pins.Add(pin);
            //MOVERSE A LA REGION DE LA LOCALIZACION OBTENIDA
            var location = await Geolocation.GetLocationAsync();
            if (location == null) { location = await Geolocation.GetLastKnownLocationAsync(); }
            Maps.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Latitud, Longitud), Distance.FromMiles(1)));

            //ACTUALIZAR LA UBICACION Y PONERSE A LA ESCUCHA DE CUANDO VOLVER A LA MISMA LOCALIZACION
            Plugin.Geolocator.Abstractions.IGeolocator geotoCelphone = CrossGeolocator.Current;
            if (geotoCelphone != null)
            {
                geotoCelphone.PositionChanged += Locatilazion_PositionChanged;
                if (!geotoCelphone.IsListening)
                {
                    await geotoCelphone.StartListeningAsync(TimeSpan.FromSeconds(10), 120);
                }
                await geotoCelphone.GetPositionAsync();
                Maps.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Latitud, Longitud), Distance.FromMiles(1)));
            }
            else
            {
                await geotoCelphone.GetLastKnownLocationAsync();
                await geotoCelphone.GetPositionAsync();
                Maps.MoveToRegion(new MapSpan(new Position(Latitud, Longitud), 1, 1));
            }
        }

        //MOVER AL CAMBIAR LA POSICION
        private void Locatilazion_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            int value1 = 1; int value2 = 1;
            Position movetomaps = new Position(Convert.ToDouble(txtLatitud.Text), Convert.ToDouble(txtLongitud.Text));
            Maps.MoveToRegion(new MapSpan(movetomaps, value1, value2));
        }

    }
}