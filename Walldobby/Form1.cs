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
using System.Threading;

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

        private void GlobalLumos_Click(object sender, EventArgs e)
        {
            button1_Click(null, null);
            Thread.Sleep(200);
            DiningTableSpotLumos_Click(null, null);
            Thread.Sleep(200);
            HallwayLumos_Click(null, null);
            Thread.Sleep(200);
            button10_Click(null, null);
            Thread.Sleep(200);
            WorkspaceLumos_Click(null, null);
        }

        private void GlobalNox_Click(object sender, EventArgs e)
        {
            WindowSpotNox_Click(null, null);
            Thread.Sleep(300);
            DiningTableSpotNox_Click(null, null);
            Thread.Sleep(300);
            HallwayNox_Click(null, null);
            Thread.Sleep(300);
            LargeBedroomLightNox_Click(null, null);
            Thread.Sleep(300);
            WorkspaceNox_Click(null, null);
            Thread.Sleep(300);
            MainKitchenLightNox_Click(null, null);
            Thread.Sleep(300);
            PCLedNox_Click(null, null);
            Thread.Sleep(300);
            CouchLedNox_Click(null, null);
            Thread.Sleep(300);
            BedsideLightNox_Click(null, null);
            
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            API.DeviceOnOff(Constants.KITCHEN, Constants.MAIN_LIGHT, State.On);
        }

        private void MainKitchenLightNox_Click(object sender, EventArgs e)
        {
            API.DeviceOnOff(Constants.KITCHEN, Constants.MAIN_LIGHT, State.Off);
        }

        private void MainKitchenSlider_Scroll(object sender, EventArgs e)
        {
            API.Dim(Constants.KITCHEN, Constants.MAIN_LIGHT, ((TrackBar)sender).Value);
        }

        private void WorkspaceLumos_Click(object sender, EventArgs e)
        {
            API.DeviceOnOff(Constants.KITCHEN, Constants.WORK_LIGHT, State.On);
        }

        private void WorkspaceNox_Click(object sender, EventArgs e)
        {
            API.DeviceOnOff(Constants.KITCHEN, Constants.WORK_LIGHT, State.Off);
        }

        private void groupBox17_Enter(object sender, EventArgs e)
        {

        }

        private void WorkspaceSlider_Scroll(object sender, EventArgs e)
        {
            API.Dim(Constants.KITCHEN, Constants.WORK_LIGHT, ((TrackBar)sender).Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
            Thread.Sleep(100);
            DiningTableSpotLumos_Click(sender, e);
        }

        private void LivingroomNox_Click(object sender, EventArgs e)
        {
            WindowSpotNox_Click(sender, e);
            Thread.Sleep(250);
            DiningTableSpotNox_Click(sender, e);
            Thread.Sleep(300);
            PCLedNox_Click(sender, e);
            Thread.Sleep(300);
            CouchLedNox_Click(sender, e);
        }

        private void KitchenLumos_Click(object sender, EventArgs e)
        {
            WorkspaceLumos_Click(sender, e);
            Thread.Sleep(250);
            button10_Click(sender, e);
        }

        private void KitchenNox_Click(object sender, EventArgs e)
        {
            WorkspaceNox_Click(sender, e);
            Thread.Sleep(250);
            MainKitchenLightNox_Click(sender,e);
        }

        private void HallwayMasterLumos_Click(object sender, EventArgs e)
        {
            HallwayLumos_Click(sender, e);
        }

        private void HallwayMasterNox_Click(object sender, EventArgs e)
        {
            HallwayNox_Click(sender, e);
        }

        private void BedroomLumos_Click(object sender, EventArgs e)
        {
            LargeBedroomLightLumos_Click(sender, e);
            Thread.Sleep(250);
            BedsideLightLumos_Click(sender, e);
        }

        private void bedroomNox_Click(object sender, EventArgs e)
        {
            LargeBedroomLightNox_Click(sender, e);
            Thread.Sleep(250);
            BedsideLightNox_Click(sender, e);
        }

        private void GlobalNox_Click_1(object sender, EventArgs e)
        {
            GlobalNox_Click(sender, e);
        }

        private void GlobalLumos_Click_1(object sender, EventArgs e)
        {
            GlobalLumos_Click(sender, e);
        }
    }
}
