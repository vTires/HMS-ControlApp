using HMS_ControlApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_ControlApp.Service
{
    public class ExceptionsService
    {
        private static BindingList<ExceptionsServiceModel> _exceptionsList = new BindingList<ExceptionsServiceModel>();

        public static BindingList<ExceptionsServiceModel> exceptionsList
        {
            get { return _exceptionsList; }
            set
            {
                _exceptionsList = value;
            }
        }

        public static void ExceptionCatcher(Exception ex)
        {
            try
            {
                var newException = new ExceptionsServiceModel
                {
                    exceptionNo = exceptionsList.Count + 1,
                    exceptionTime = DateTime.Now.ToShortTimeString(),
                    exception = ex.Message,
                    exceptionStackTrace = ex.StackTrace
                };
                exceptionsList.Add(newException);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

    }
}
