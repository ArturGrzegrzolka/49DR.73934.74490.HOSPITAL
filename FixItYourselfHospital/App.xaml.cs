using FixItYourselfHospital.Forms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FixItYourselfHospital
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // MainHub ref for possibility of opening new windows in the same window (MainHub)
        public static MainHub MainHubRef;
    }
}
