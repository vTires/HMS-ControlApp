using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_ControlApp.Service
{
    public class Commands
    {
        public static string PA_NEW = "PA_NEW\r\n";
        //Feedback: PA_NEW\r\n
        //Description: Switch to extended interface protocol
        public static string PA_OLD = "PA_OLD\r\n";
        //Feedback:  PA_OLD\r\n
        //Description: Switch to old interface protocol compatible to magnetic stirrer MR Hei-End
        public static string SetTemperature = "OUT_SP_1 Y\r\n";
        //Feedback: OUT_SP_1 X\r\n
        //Description: Set temperature sample/hotplate (°C)
        public static string SetSpeed = "OUT_SP_3 Y\r\n";
        //Feedback: OUT_SP_3 X\r\n
        //Description: Set speed (rpm)
        public static string StartHeating = "START_1\r\n";
        //Feedback: START_1\r\n
        //Description: Start heating: Remote active; „PC” blinking in display MR
        public static string StartRotation = "START_2\r\n";
        //Feedback: START_2\r\n
        //Description: Start rotation: Remote active; „PC” blinking in display MR






    }
}
