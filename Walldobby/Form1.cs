using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using LightwaveRF;

namespace Walldobby
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            API.DeviceOnOff(Constants.LIVING_ROOM, Constants.WINDOW_SPOT, State.On);


        }

        

        private void TemperatureUpdateTimer_Tick(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();

            string temp_indoor = wc.DownloadString("http://temp.buttsecks.net/temp.cgi");
            temp_indoor = temp_indoor.Replace("temperature:", "").Replace("\n", "") + " °C";

            string temp_outdoor = wc.DownloadString("http://api.openweathermap.org/data/2.5/find?q=London&units=metric&appid=44db6a862fba0b067b1930da0d769e98");
            int base_pos = temp_outdoor.IndexOf("{\"temp\":");
            temp_outdoor = temp_outdoor.Substring( base_pos + 8, temp_outdoor.IndexOf(",", base_pos) - base_pos - 8 ) + " °C"; 

            InsideTemperatureLabel.Text = temp_indoor;
            OutsideTemperatureLabel.Text = temp_outdoor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TemperatureUpdateTimer_Tick(null, null);
        }

        private void WindowSpotNox_Click(object sender, EventArgs e)
        {
            API.DeviceOnOff(Constants.LIVING_ROOM, Constants.WINDOW_SPOT, State.Off);
        }

        private void WindowSpotSlider_Scroll(object sender, EventArgs e)
        {
            API.Dim(Constants.LIVING_ROOM, Constants.WINDOW_SPOT, ((TrackBar)sender).Value);
        }

        private void DiningTableSpotSlider_Scroll(object sender, EventArgs e)
        {
            API.Dim(Constants.LIVING_ROOM, Constants.DINING_ROOM_SPOT, ((TrackBar)sender).Value);
        }

        private void DiningTableSpotNox_Click(object sender, EventArgs e)
        {
            API.DeviceOnOff(Constants.LIVING_ROOM, Constants.DINING_ROOM_SPOT, State.Off);
        }

        private void DiningTableSpotLumos_Click(object sender, EventArgs e)
        {
            API.DeviceOnOff(Constants.LIVING_ROOM, Constants.DINING_ROOM_SPOT, State.On);
        }

        private void PCLedLumos_Click(object sender, EventArgs e)
        {
            API.DeviceOnOff(Constants.LIVING_ROOM, Constants.PC_XMASS, State.On);
        }

        private void PCLedNox_Click(object sender, EventArgs e)
        {
            API.DeviceOnOff(Constants.LIVING_ROOM, Constants.PC_XMASS, State.Off);
        }

        private void CouchLedLumos_Click(object sender, EventArgs e)
        {
            API.DeviceOnOff(Constants.LIVING_ROOM, Constants.COUCH_XMASS, State.On);

        }

        private void CouchLedNox_Click(object sender, EventArgs e)
        {
            API.DeviceOnOff(Constants.LIVING_ROOM, Constants.COUCH_XMASS, State.Off);
        }

        private void HallwaySlider_Scroll(object sender, EventArgs e)
        {
            API.Dim(Constants.HALLWAY, Constants.HALLWAY_LIGHT, ((TrackBar)sender).Value);
        }

        private void HallwayLumos_Click(object sender, EventArgs e)
        {
            API.DeviceOnOff(Constants.HALLWAY, Constants.HALLWAY_LIGHT, State.On);
        }

        private void HallwayNox_Click(object sender, EventArgs e)
        {
            API.DeviceOnOff(Constants.HALLWAY, Constants.HALLWAY_LIGHT, State.Off);
        }

        private void LargeBedroomLightSlider_Scroll(object sender, EventArgs e)
        {
            API.Dim(Constants.BEDROOM, Constants.BEDROOM_LIGHT, ((TrackBar)sender).Value);
        }

        private void LargeBedroomLightNox_Click(object sender, EventArgs e)
        {
            API.DeviceOnOff(Constants.BEDROOM, Constants.BEDROOM_LIGHT, State.Off);
        }

        private void LargeBedroomLightLumos_Click(object sender, EventArgs e)
        {
            API.DeviceOnOff(Constants.BEDROOM, Constants.BEDROOM_LIGHT, State.On);
        }

        private void BedsideLightLumos_Click(object sender, EventArgs e)
        {
            API.DeviceOnOff(Constants.BEDROOM, Constants.BEDSIDE_LIGHT, State.On);
        }

        private void BedsideLightNox_Click(object sender, EventArgs e)
        {
            API.DeviceOnOff(Constants.BEDROOM, Constants.BEDSIDE_LIGHT, State.Off);
        }
    }
}
