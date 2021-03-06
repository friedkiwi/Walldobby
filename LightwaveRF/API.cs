﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Json;
using System.Diagnostics;

namespace LightwaveRF
{
    public delegate void OnOffEventHandler(object sender, int room, int device, State state);
    public delegate void AllOffEventHandler(object sender, int room);
    public delegate void moodEventHandler(object sender, int room, int mood);
    public delegate void dimEventHandler(object sender, int room,int device, int pct);
    public delegate void heatEventHandler(object sender, int room, State state);
    public delegate void rawEventHandler(object sender, string rawData);
    public delegate void responseEventHandler(object sender, string Data);

    /// <summary>
    /// holds all the parts of a heating valve response so that they can be queried
    /// </summary>
    public class HeatingValveResponse
    {
        //!R1F*r
        //*!{"trans":62,"mac":"03:09:3D","time":1412277443,"prod":"valve","serial":"BF4102","signal":0,"type":"temp","batt":2.50,"ver":56,"state":"run","cTemp":21.5,"cTarg":22.0,"output":100,"nTarg":18.0,"nSlot":"06:00","prof":4}
        /// <summary>
        /// the raw response from the valve
        /// </summary>
        public string rawResponse { get; set; }
        /// <summary>
        /// Transmit power?
        /// </summary>
        public string trans {get;set;}
        /// <summary>
        /// mac address of the wifilink?
        /// </summary>
        public string mac { get; set; }
        /// <summary>
        /// time of last state received from valve
        /// </summary>
        public DateTime time { get; set; }
        /// <summary>
        /// product eg 'valve'
        /// </summary>
        public string product { get; set; }
        /// <summary>
        /// serial no of the valve
        /// </summary>
        public string serial { get; set; }
        /// <summary>
        /// signal strength
        /// </summary>
        public int signal { get; set; }
        public string type { get; set; }
        /// <summary>
        /// current valve position % 10% = 10% closed.
        /// </summary>
        public int output { get; set; }

        /// <summary>
        /// battery (volts)
        /// </summary>
        public double batt { get; set; }
        /// <summary>
        /// Current Temperature
        /// </summary>
        public double cTemp { get; set; }
        /// <summary>
        /// Target Temperature
        /// </summary>
        public double cTarg { get; set; }
        /// <summary>
        /// Next target temperature
        /// </summary>
        public double nTarg { get; set; }
        /// <summary>
        /// Time that next target is active
        /// </summary>
        public string nSlot { get; set; }
        /// <summary>
        /// positioner offset (from calibration)
        /// </summary>
        public double prof { get; set; }

        /// <summary>
        /// version of the valve?
        /// </summary>
        public double ver { get; set; }

        /// <summary>
        /// state of the valve ('run' , 'calib', 'man' )
        /// </summary>
        public string state { get; set; }
        public HeatingValveResponse(string LightWaveLinkresponse)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            try
            {
                rawResponse = LightWaveLinkresponse.Split('!')[1];
                JsonValue parsedJson = JsonValue.Parse(rawResponse);
                trans = (string)parsedJson["trans"];
                mac = (string)parsedJson["mac"];
                time = epoch.AddSeconds((int)parsedJson["time"]);
                product = (string)parsedJson["prod"];
                serial = (string)parsedJson["serial"];
                output = (int)parsedJson["output"];
                state = (string)parsedJson["state"];
                signal = (int)parsedJson["signal"];
                type = (string)parsedJson["type"];
                batt = (double)parsedJson["batt"];
                cTemp = (double)parsedJson["cTemp"];
                cTarg = (double)parsedJson["cTarg"];
                nTarg = (double)parsedJson["nTarg"];
                nSlot = (string)parsedJson["nSlot"];
                prof = (double)parsedJson["prof"];
                ver = (double)parsedJson["ver"];
            }
            catch (Exception e)
            {
                Debug.Write(e + rawResponse);
            }
            Debug.Write(this.ToString());
        }
        public override string ToString() 
        {
            return "Raw: " + rawResponse + "\n" +
            "trans: " + trans + "\n" +
            "mac: " + mac + "\n" +
            "time: " + time + "\n" +
            "product: " + product + "\n" +
            "serial: " + serial + "\n" +
            "signal: " + signal + "\n" +
            "state: " + state + "\n" +
            "type: " + type + "\n" +
            "batt: " + batt + "\n" +
            "output: " + output + "\n" +
            "cTemp: " + cTemp + "\n" +
            "cTarg: " + cTarg + "\n" +
            "nTarg: " + nTarg + "\n" +
            "nSlot: " + nSlot + "\n" +
            "ver" + ver + "\n" +
            "prof: " + prof + "\n";
        }
    }

    public static class API
    {
        /// <summary>
        /// Shuts down all worker threads 
        /// </summary>
        /// 
        public static void Dispose()
        {
            if(radiatorStateThread!=null) radiatorStateThread.Abort();
            if (listenthread != null) { listenthread.Abort(); LightwaveRF.API.GetMeterReading(); }
            //we need to send a datagram to stop the listening threads locking - so call GetMeterReading as that doesn't actually change anything.
            if(recordsequencethread!=null) {recordsequencethread.Abort(); LightwaveRF.API.GetMeterReading(); }
        }
        private static string RecordedSequence = "";
        private static string RecordedSequenceName = "";
        private static Thread HeatingDemand = null;
        private static Thread recordsequencethread = null;
        public static int radiatorRefreshMins = 20;
        public static TimeSpan keepRadiatorStatefor = new TimeSpan(1, 0, 0, 0);
        private static Device heatingDevice = null;
        public static string lastHeatingDemandSerial = "";
        public static bool MaintainRadiatorState
        {
            get
            {
                if(radiatorStateThread != null)
                {
                    if (radiatorStateThread.ThreadState == System.Threading.ThreadState.Aborted || radiatorStateThread.ThreadState == System.Threading.ThreadState.Stopped || radiatorStateThread.ThreadState == System.Threading.ThreadState.WaitSleepJoin)
                    {
                        radiatorStateThread = null;
                    }
                }
                return radiatorStateThread != null;
            }
            set
            {
                if (value)
                {
                    KeepRadiatorState(radiatorRefreshMins, DateTime.Now.Add(keepRadiatorStatefor));
                }
                else
                {
                    radiatorStateThread.Abort();
                    radiatorStateThread = null;
                }
            }
        }
        private static Thread radiatorStateThread = null;
        private static int radiatorStateRefreshMins = 10;
        private static DateTime radiatorStateUntilDate;
        private static Dictionary<string,Device> LastDeviceState = new Dictionary<string,Device>();
        public static    List<Room> Rooms;
        public static List<Device> Devices = new List<Device>();
        public static Dictionary<string, Device> GetDevices
        {
            get
            {
                return LastDeviceState;
            }
        }

        /// <summary>
        /// index used for requests to the wifilink
        /// </summary>
        static int ind = -999;
        /// <summary>
        /// get the next index and return it.
        /// </summary>
        private static string nextind
        {
            get
            {
                if (ind == -999)//index not yet initialised. - set it to a random number.
                {
                    Random r = new Random();
                    ind = r.Next(999);
                }
                ind++;
                if (ind > 999) ind = 1;
                return(ind.ToString("000"));
            }
        }
        private static Thread listenthread;
        public static event OnOffEventHandler OnOff;
        /// <summary>
        /// Regex for on/off
        /// matches :Room, Device, and State
        /// </summary>
        public const string OnOffRegEx ="...,(!R)(?<Room>[0-9]?[0-9])(D)(?<Device>[0-9])(F)(?<State>[0,1,(,),k,l,u,\\^])";
        public static event AllOffEventHandler OnAllOff;
        /// <summary>
        /// Regex for All off
        /// Matches: Room
        /// </summary>
        public const string allOffRegEx = "...,(!R)(?<Room>[0-9])(Fa)";
        public static event moodEventHandler OnMood;
        /// <summary>
        /// Regex for Mood
        /// Matches: Room, Mood
        /// </summary>
        public const string moodRegEx = "...,(!R)(?<Room>[0-9])(FmP)(?<mood>[0-9])";//"533,!R"+ Room + "FmP" + mood + "|"
        public static event dimEventHandler OnDim;
        /// <summary>
        /// Regex for Dim
        /// Matches: Room, Device, State
        /// </summary>
        public const string dimRegEx = "...,(!R)(?<Room>[0-9])(D)(?<Device>[0-9])(FdP)(?<State>[0-9]?[0-9])";//"533,!R" + Room + "D" + Device + "FdP" + pstr + "|"
        public static event heatEventHandler OnHeat;
        /// <summary>
        /// Regex for Heat commands
        /// Matches: Room, State.
        /// </summary>
        public const string heatRegEx = "...,(!R)(?<Room>[0-9])(DhF)(?<State>[0-9])";//"533,!R" + Room + "DhF" + statestr + "|";
        public static event rawEventHandler Raw;

        /// <summary>
        /// Listen for commands from other devices (and this device) be sure to call Dispose() to stop this.
        /// </summary>
        public static void Listen()
        {
            if (listenthread == null)
            {
                listenthread = new Thread(new ThreadStart(listenThreadWorker));
                //responsethread = new Thread(new ThreadStart(responseThreadWorker));
                listenthread.Start();
                //responsethread.Start();
            }
        }

        /// <summary>
        /// Start monitoring all valves 
        /// where any valve requires heat - switch on the device which is passed.
        /// </summary>
        /// <param name="newHeatingDevice"></param>
        public static void HeatingControlFromValveTemp(Device newHeatingDevice = null)
        {
            //set to old boiler control
            if (newHeatingDevice == null) newHeatingDevice = new Device(new Room(16), 1, "Boiler", DeviceType.OnOff, State.Open);
            heatingDevice = newHeatingDevice;
            if(HeatingDemand == null)
            {
                HeatingDemand = new Thread(new ThreadStart(heatingDemandWorker));
                HeatingDemand.Start();
            }
        }

        /// <summary>
        /// Worker process for heating demand thread
        /// this is an endless loop to monitor the temperatures in the values
        /// and switch on the boiler if there is a demand from any of the valves
        /// </summary>
        private static void heatingDemandWorker()
        {
            while(true)
            {
                switch (checkHeatingDemand())
                {
                    case null:
                    break;
                    case true:
                        if(heatingDevice.state != State.On)
                        {
                            heatingDevice.On();
                        }
                    break;
                    default:
                        if(heatingDevice.state != State.Off)
                        {
                            heatingDevice.Off();
                        }
                    break;
                }
                Thread.Sleep(60000);
            }
        }

        /// <summary>
        /// Updates a device
        /// </summary>
        /// <param name="thisDevice"></param>
        public static void updateLastDeviceState(Device thisDevice)
        {
            lock (LastDeviceState)
            {
                if (LastDeviceState.ContainsKey(thisDevice.deviceIdentifier)) LastDeviceState.Remove(thisDevice.deviceIdentifier);
                LastDeviceState.Add(thisDevice.deviceIdentifier, thisDevice);
                var device = (from x in Devices
                              where x.room.RoomNum == thisDevice.room.RoomNum
                              && x.devicenum == thisDevice.devicenum
                              select x);
                if (device == null)
                {
                    Devices.Add(thisDevice);
                }
                else
                {
                    Devices.Remove(device.FirstOrDefault());
                    Devices.Add(thisDevice);
                }
            }
        }

        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <returns>full string response from wifilink</returns>
        private static string getResponse(int nResponses)
        {
            Socket sock = new Socket(AddressFamily.InterNetwork,
                SocketType.Dgram, ProtocolType.Udp);
            sock.ReceiveTimeout = 30000;
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, 9761);
            sock.Bind(iep);
            EndPoint ep = (EndPoint)iep;
            string stringData = "";
            try
            {
                for (int i = 0; i < nResponses; i++)
                {
                    byte[] data = new byte[1024];
                    int recv = sock.ReceiveFrom(data, ref ep);
                    stringData += Encoding.ASCII.GetString(data, 0, recv);
                    stringData += "\n";
                }
                return stringData;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                sock.Close();
            }
        }

        /// <summary>
        /// Gets the current state of valve no [index]
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static HeatingValveResponse getHeatingDevice(int index)
        {
            //!R1F*r
            //*!{"trans":62,"mac":"03:09:3D","time":1412277443,"prod":"valve","serial":"BF4102","signal":0,"type":"temp","batt":2.50,"ver":56,"state":"run","cTemp":21.5,"cTarg":22.0,"output":100,"nTarg":18.0,"nSlot":"06:00","prof":4}
            string response = sendRaw(nextind + ",!R" + index.ToString() + "F*r",2);
            return new HeatingValveResponse(response);
            
        }

        /// <summary>
        /// Checks all radiators to see if any need heat, and if so returns true.
        /// else returns false
        /// </summary>
        /// <returns></returns>
        private static bool? checkHeatingDemand()
        {
            bool? demand = null;
            for (int i = 1; i < 5; i++)
            {
                var radiator = getHeatingDevice(i);
                if (radiator.cTarg != 0)
                {
                    //if demand greater than 10 percent, then fire up boiler
                    if (radiator.output > 0)
                    {//demand is greater than target and value was retrieved.
                        demand = true;
                        lastHeatingDemandSerial = radiator.serial;
                    }
                    else
                    {//if the demand hasn't been set then set it to false if it matches the last on device.
                        if (demand == null)
                        {//(don't set it to false if it is true...)
                            if(radiator.serial == lastHeatingDemandSerial)
                            { //original demand has reset, switch off demand.
                                demand = false;
                            }
                        }
                    }
                }
                if(radiator.cTarg != 0)
                { 
                string newFileName = "C:\\temp\\valves" + i +".csv";
                string csvline = radiator.time + "," + radiator.cTarg + "," + radiator.cTemp + "," + radiator.output + Environment.NewLine;


                if (!System.IO.File.Exists(newFileName))
                {
                    string clientHeader = "Time" + "," + "TI300" + i + ".SP,TI300" + i + ".PV,TI300" + i + ".OP" + Environment.NewLine;
                    System.IO.File.WriteAllText(newFileName, clientHeader);
                }

                System.IO.File.AppendAllText(newFileName, csvline);
                }
            }
            return demand;
        }

        /// <summary>
        /// 
        /// </summary>
        private static void listenThreadWorker()
        {
            Socket sock = new Socket(AddressFamily.InterNetwork,
                            SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, 9760);
            sock.Bind(iep);
            EndPoint ep = (EndPoint)iep;
            Console.WriteLine("Ready to receive...");
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024];
                    int recv = sock.ReceiveFrom(data, ref ep);
                    string stringData = Encoding.ASCII.GetString(data, 0, recv);
                    if(Raw !=null) Raw(null,stringData);
                    Match OnOffMatch = new Regex(OnOffRegEx).Match(stringData);
                    Match AllOffMatch = new Regex(allOffRegEx).Match(stringData);
                    Match MoodMatch = new Regex(moodRegEx).Match(stringData);
                    Match DimMatch = new Regex(dimRegEx).Match(stringData);
                    Match HeatMatch = new Regex(heatRegEx).Match(stringData);
                    if (OnOffMatch.Success)
                    {
                        var thisDevice = new Device(new Room(int.Parse(OnOffMatch.Groups["Room"].Value)), int.Parse(OnOffMatch.Groups["Device"].Value),"Dev " + int.Parse(OnOffMatch.Groups["Device"].Value),DeviceType.OnOff, StateStrings.GetStateFromString(OnOffMatch.Groups["State"].Value));
                        updateLastDeviceState(thisDevice);
                        if (OnOff != null)
                        {
                            OnOff(null, thisDevice.room.RoomNum, thisDevice.devicenum, thisDevice.state);
                        }
                    }
                    if (AllOffMatch.Success && OnAllOff!=null)
                    {
                        OnAllOff(null, int.Parse(AllOffMatch.Groups["Room"].Value));
                    }
                    if (MoodMatch.Success && OnMood!=null)
                    {
                        OnMood(null, int.Parse(MoodMatch.Groups["Room"].Value), int.Parse(MoodMatch.Groups["Mood"].Value));
                    }
                    if (DimMatch.Success)
                    {
                        State deviceState = new State();
                        if (DimMatch.Groups["State"].Value == "0")
                            deviceState = State.Off;
                        else
                            deviceState = State.On;
                        var thisDevice = new Device(new Room(int.Parse(DimMatch.Groups["Room"].Value)), int.Parse(DimMatch.Groups["Device"].Value), "Dev " + int.Parse(DimMatch.Groups["Device"].Value), DeviceType.OnOff, deviceState);
                        thisDevice.DimLevel = (int)Math.Round(double.Parse(DimMatch.Groups["State"].Value)/32*100);
                        updateLastDeviceState(thisDevice);
                        if (OnDim != null)
                        {
                            OnDim(null, thisDevice.room.RoomNum, thisDevice.devicenum, thisDevice.DimLevel);
                        }
                    }
                    if (HeatMatch.Success)
                    {
                        var thisDevice = new Device(new Room(int.Parse(HeatMatch.Groups["Room"].Value)), 0, "Rad " + int.Parse(HeatMatch.Groups["Room"].Value), DeviceType.Radiator, StateStrings.GetStateFromString(HeatMatch.Groups["State"].Value));
                        updateLastDeviceState(thisDevice);
                        if (OnHeat != null)
                        {
                            OnHeat(null, thisDevice.room.RoomNum, thisDevice.state);
                        }
                    }
                }
            }
            finally
            {
                sock.Close();
            }
        }

        /// <summary>
        /// Switches off all devices in room
        /// </summary>
        /// <param name="Room">Room to switch all off in.</param>
        /// <returns>String "OK" otherwise error message</returns>
        public static string AllOff(int room, string message = "")
        {
            string text = nextind + ",!R" + room + @"Fa|" + message;
            return sendRaw(text).Replace(ind + ",", "");
        }

        /// <summary>
        /// capture commands and store them as a sequence. 
        /// will listen for 1 minute after it is told to do this, and record all the commands in that minute to a sequence
        /// </summary>
        /// <param name="SequenceName"></param>
        /// <returns>String "OK" otherwise error message</returns>
        public static string RecordSequence(string SequenceName)
        {
            if (recordsequencethread == null || recordsequencethread.ThreadState==System.Threading.ThreadState.Stopped)
            {
                RecordedSequenceName = SequenceName;
                recordsequencethread = new Thread(new ThreadStart(recordSequenceWorker));
                recordsequencethread.Start();
                return "Recording for 20 seconds and will save as " + SequenceName;
            }
            return "All ready recording" + RecordedSequenceName + ", wait till that is finished";
        }

        /// <summary>
        /// capture commands for 20 seconds and store them in the sequence
        /// </summary>
        private static void recordSequenceWorker()
        {
            try
            {
                RecordedSequence = nextind + "!FeP\"" + RecordedSequenceName + "\"=";
                Raw += AddEventToSequence;
                Listen();
                System.Threading.Thread.Sleep(20000);
                RecordedSequence = RecordedSequence.Substring(0,RecordedSequence.Length -1);
                Raw -= AddEventToSequence;
                sendRaw(RecordedSequence);
                RecordedSequence = "";
            }
            finally
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="rawData"></param>
        private static void AddEventToSequence(object sender, string rawData)
        {
            //!FeP"Test"=!R1D1F1,00:00:03,!R1Fa,00:00:03,!R1D2F0,00:00:03
            //remove any comments that would be displayed on the wifilink - they are not allowed in a sequence.
            int endchar;
            if (rawData.Contains("|"))
                endchar = rawData.IndexOf('|') - 4;
            else
                endchar = rawData.Length -4;

            string command = rawData.Substring(4,endchar);
            RecordedSequence = RecordedSequence + command +",00:00:03,";
        }

        /// <summary>
        /// Delete named sequence
        /// </summary>
        /// <param name="SequenceName"></param>
        /// <returns>String "OK" otherwise error message</returns>
        public static string deleteSequence(string SequenceName)
        {
            string text = nextind + ",!FxP\"" + SequenceName +"\"";
            return sendRaw(text).Replace(ind + ",", "");
        }

        /// <summary>
        /// runs a sequence at the specified time
        /// </summary>
        /// <returns></returns>
        public static string saveTimer(string timername, string SequenceName, DateTime AtDateTime)
        {
            //130,!FiP"T20120920233337"=!FqP"Test",T01:20,S25/09/12
            DateTime now = DateTime.Now;
            string atdatetimeformatted = "T" + AtDateTime.Hour.ToString("00") + ":" + AtDateTime.Minute.ToString("00") + ",S" + AtDateTime.Day.ToString("00") + "/" + AtDateTime.Month.ToString("00") + "/" + AtDateTime.Day.ToString("00");
            string formattednowstring = "T" + now.Year.ToString("0000") + now.Month.ToString("00") + now.Day.ToString("00") + now.Hour.ToString("00") + now.Minute.ToString("00") + now.Second.ToString("00");
            string text = nextind + "!FiPT\"" + timername +"\"=FqP\"" + SequenceName + "\"," + atdatetimeformatted;
            return sendRaw(text).Replace(ind + ",", "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timername"></param>
        /// <returns></returns>
        public static string cancelTimer(string timername)
        {
            //440,!FiP"T20120920234815"=!FqP"Test",T00:50,E20/11/12,S01/00/00
            //441,!FxP"T201209202348"
            string text = "!FxP\"" + timername + "\"";
            return sendRaw(text).Replace(ind + ",", "");
        }

        /// <summary>
        /// Start named sequence
        /// </summary>
        /// <param name="SequenceName"></param>
        /// <returns>String "OK" otherwise error message</returns>
        public static string startSequence(string SequenceName)
        {
            string text =nextind + "!FqP\"" + SequenceName +"\"|Start Sequence|\"" + SequenceName +"\"";
            return sendRaw(text).Replace(ind + ",", "");
        }

        /// <summary>
        /// sets mood in room
        /// </summary>
        /// <param name="Room">room number </param>
        /// <param name="mood">mood number</param>
        /// <returns>String "OK" otherwise error message</returns>
        public static string Mood(int room, int mood)
        {
            string text = nextind + ",!R"+ room + @"FmP" + mood + @"|Room " + room.ToString() + " Mood " + mood.ToString();
            return sendRaw(text).Replace(ind + ",", "");
        }

        /// <summary>
        /// Save the mood preset
        /// </summary>
        /// <param name="room">room number </param>
        /// <param name="mood">mood number</param>
        /// <returns>String "OK" otherwise error message</returns>
        public static string SaveMood(int room, int mood)
        {
            string text = nextind + ",!R"+ room + @"FsP" + mood + @"|MOOD NOW SET";
            return sendRaw(text).Replace(ind + ",", "");
        }

        /// <summary>
        /// Get reading from the wireless meter.
        /// </summary>
        public static MeterReading GetMeterReading()
        {
            string text = nextind + ",@?W";
            return new MeterReading(sendRaw(text).Substring(4)); //Replace(ind + ",", "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Room">room number </param>
        /// <param name="Device">device number</param>
        /// <param name="percent">percentage level for the dim< eg. 50/param>
        /// <returns>String "OK" otherwise error message</returns>
        public static string Dim(int room, int device, int percent)
        {
            string pstr;
            if (percent == 0) return(DeviceOnOff(room,device,State.Off));
            pstr = Math.Round(((double)percent / 100 * 32)).ToString();
            string text = nextind + ",!R" + room + @"D" + device + @"FdP" + pstr + @"|";
            return sendRaw(text).Replace(ind + ",", "");
        }

        /// <summary>
        /// send on/off command to a room/device
        /// </summary>
        /// <param name="Room">room number </param>
        /// <param name="Device">device number</param>
        /// <param name="state">state (0 or 1)</param>
        /// <returns>String "OK" otherwise error message</returns>
        public static  string DeviceOnOff(int room, int device, State state)
        {
            string text = nextind + ",!R " + room + @"D" + device + @"F" + StateStrings.GetStateString(state) + @"|";
            return sendRaw(text).Replace(ind + ",", "");
        }

        /// <summary>
        /// send on/off command to a room/device
        /// </summary>
        /// <param name="Room">room number </param>
        /// <param name="state">state 1 = on 0 = off</param>
        /// <param name="message">message to display on wifilink</param>
        /// <returns>String "OK" otherwise error message</returns>
        public static string HeatOnOff(int room, State state, string message = "")
        {
            string text = nextind + ",!R" + room + @"DhF" + StateStrings.GetStateString(state) + @"|" + message;
            return sendRaw(text).Replace(ind + ",", "");
        }

        /// <summary>
        /// Switch on/off the central heating
        /// </summary>
        /// <param name="state">0=off 1=on</param>
        /// <param name="message">mesage to display on wifilink</param>
        /// <returns></returns>
        public static string CentralHeatOnOff(State state, string message = "")
        {
            string text = nextind + ",!R16D1F" + StateStrings.GetStateString(state) + @"|" + message;
            return sendRaw(text).Replace(ind + ",", "");
        }

        /// <summary>
        /// Switch on/off the hot water
        /// </summary>
        /// <param name="state">0=off 1=on</param>
        /// <param name="message">mesage to display on wifilink</param>
        /// <returns></returns>
        public static string HotWaterOnOff(State state, string message = "")
        {
            string text = nextind + ",!R16D2F" + StateStrings.GetStateString(state) + @"|" + message;
            return sendRaw(text).Replace(ind + ",", "");
        }

        /// <summary>
        /// Switch off heat in all rooms
        /// </summary>
        /// <returns></returns>
        public static string AllHeat(State state)
        {
            string retval = "";
            for (int room = 1; room <= 8; room++)
            {
                string ret = HeatOnOff(room, state, "All Heat");
                if (ret != "OK") retval = retval + ret + ";";
                Thread.Sleep(6000);
            }
            if(retval == "") retval = "OK";//all ok so return ok
            return retval;
        }

        /// <summary>
        /// Switch off all devices in all rooms
        /// </summary>
        /// <returns></returns>
        public static string AllDevicesOff()
        {
            string retval = "";
            for (int room = 1; room <= 8; room++)
            {
                string ret = AllOff(room, "All Devices Off");
                if (ret != "OK") retval = retval + ret + ";";
                Thread.Sleep(800);
            }
            if (retval == "") retval = "OK";//all ok so return ok
            return retval;
        }

        /// <summary>
        /// lock the manual switch of a device (eg socket)
        /// </summary>
        /// <param name="Room">room number </param>
        /// <param name="Device">device number</param>
        /// <returns>String "OK" otherwise error message</returns>
        public static string ManualLockDevice(int room, int device)
        {
            string text = nextind + ",!R" + room + @"D" + device + "Fk|";
            return sendRaw(text).Replace(ind + ",", "");
        }

        /// <summary>
        /// full lock the device (eg socket) (wifi, and radio)
        /// </summary>
        /// <param name="Room">room number </param>
        /// <param name="Device">device number</param>
        /// <returns>String "OK" otherwise error message</returns>
        public static string FullLockDevice(int room, int device)
        {
            string text = nextind + ",!R" + room + @"D" + device + "Fl|";
            return sendRaw(text).Replace(ind + ",", "");
        }

        /// <summary>
        /// unlock device
        /// </summary>
        /// <param name="Room">room number </param>
        /// <param name="Device">device number</param>
        /// <returns>String "OK" otherwise error message</returns>
        public static string UnLockDevice(int room, int device)
        {
            string text = nextind + ",!R" + room + @"D" + device + "Fu|";
            return sendRaw(text).Replace(ind + ",", "");
        }

        /// <summary>
        /// open the device
        /// </summary>
        /// <param name="Room">room number </param>
        /// <param name="Device">device number</param>
        /// <returns>String "OK" otherwise error message</returns>
        public static string OpenDevice(int room, int device)
        {
            string text = nextind + ",!R" + room + @"D" + device + "F)|";
            return sendRaw(text).Replace(ind + ",", "");
        }

        /// <summary>
        /// close the device
        /// </summary>
        /// <param name="Room">room number </param>
        /// <param name="Device">device number</param>
        /// <returns>String "OK" otherwise error message</returns>
        public static string CloseDevice(int room, int device)
        {
            string text = nextind + ",!R" + room + @"D" + device + "F(|";
            return sendRaw(text).Replace(ind + ",", "");
        }

        /// <summary>
        /// stop the device
        /// </summary>
        /// <param name="Room">room number </param>
        /// <param name="Device">device number</param>
        /// <returns>String "OK" otherwise error message</returns>
        public static string StopDevice(int room, int device)
        {
            string text = nextind + ",!R" + room + @"D" + device + "F^|";
            return sendRaw(text).Replace(ind + ",", "");
        }

        /// <summary>
        /// Cancels all sequences and timers in the wifilink box
        /// </summary>
        /// <returns>String "OK" otherwise error message</returns>
        public static string CancelAllSequencesAndTimers()
        {
            string text = nextind + ",!FcP\"*\"|";
            return sendRaw(text).Replace(ind + ",", "");
        }

        /// <summary>
        /// Delete all sequences and timers in the wifilink box
        /// </summary>
        /// <returns>String "OK" otherwise error message</returns>
        public static string DeleteAllSequencesAndTimers()
        {
            string text = nextind + ",!FxP\"*\"|";
            return sendRaw(text).Replace(ind + ",", "");
        }

        /// <summary>
        /// 
        /// </summary>
        private static void RadiatorStateWorker()
        {
            while (radiatorStateUntilDate > DateTime.Now)
            {
                lock (LastDeviceState)
                {
                    foreach (var item in LastDeviceState)
                    {
                        if (item.Value.deviceType == DeviceType.Radiator)
                        {
                            if (item.Value.state == State.Off)
                            {
                                HeatOnOff(item.Value.room.RoomNum, item.Value.state, "API R State");
                                Thread.Sleep(7000);//Radiators take a while for the command....
                            }
                        }
                    }
                }
                Thread.Sleep(radiatorStateRefreshMins * 60000);
            }
        }

        /// <summary>
        /// listens for radiator off commands and resends them until an on command is received 
        /// (workaround for air bug in old lightwaverf valves - and pegler Itemp terriers).
        /// </summary>
        /// <param name="minutesToRefresh">number of minutes to wait before refreshing the state of the valves.</param>
        /// 
        /// <returns></returns>
        private static void KeepRadiatorState(int refreshMins, DateTime untilDate)
        {
            Listen();
            radiatorStateUntilDate = untilDate;
            radiatorStateRefreshMins = refreshMins;
            if (radiatorStateThread == null || radiatorStateThread.ThreadState == System.Threading.ThreadState.Stopped)
            {
                radiatorStateThread = new Thread(new ThreadStart(RadiatorStateWorker));
                radiatorStateThread.Start();
            }
        }

        /// <summary>
        /// Send raw packet containing 'text' to the wifilink
        /// </summary>
        /// <param name="text">contents of packet.</param>
        public static string sendRaw(string text,int nResponse =1)
        {
            var udpClient = new UdpClient(9761);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, 9760);
            byte[] send_buffer = Encoding.ASCII.GetBytes(text);
            udpClient.Send(send_buffer, send_buffer.Length, endPoint);
            udpClient.Close();
            //return "";
            return getResponse(nResponse).Replace(ind + ",", "").Trim();
        }
    }
}
