using IPT_TMS_GoFare.Views;

namespace IPT_TMS_GoFare
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //Set the Destination to DestinationForm() to reset

            //Application.Run(new AdminPanelForm());
            //Application.Run(new RegisterForm());
            //Application.Run(new DestinationForm());
            //Application.Run(new ScanForm());
              Application.Run(new ScannerForm());

        }
    }
}