﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LightwaveRF
{
    public enum State
    {
        On =1,Off =0,Open =2,Close=3,Stop=4
    }

    public static class StateStrings
    {
        public const string On = "1";
        public const string Off = "0";
        public const string Open = ")";
        public const string Close = "(";
        public const string Stop = "^";
        /// <summary>
        /// Gets a State enum from the original state string in the commmand.
        /// eg 1 returns State.On 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static State GetStateFromString(string state)
        {
            switch (state)
            {
                case On: return State.On;
                case Off: return State.Off;
                case Open: return State.Open;
                case Close: return State.Close;
                case Stop: return State.Stop;
                default: return State.Off;
            }
        }

        /// <summary>
        /// returns the string to match the state (eg. .State.On returns 1)
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static string GetStateString(State state)
        {
            switch(state)
            {
                case State.On : return On;
                case State.Off: return Off; 
                case State.Open: return Open;
                case State.Close: return Close;
                case State.Stop: return Stop;
                default:  return "";
            }
        }
    }
}
