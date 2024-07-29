namespace PressureUpper;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
       
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        ApplicationConfiguration.Initialize();

        //var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "reg.dat");

        //if (File.Exists(filePath) == false)
        //{
        //    FormRegister formReg = new();
        //    formReg.ShowDialog();
        //    if (File.Exists(filePath) == false)
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        //Application.Restart();
        //    }
        //}


        //LicenseChecker lc = new LicenseChecker();
        //string message = string.Empty;
        //bool isCheck = lc.Check(filePath, out message);
        //if (!isCheck)
        //{
        //    MessageBox.Show(message);
        //    return;
        //}

        FormLogin formLogin = new();
        if (formLogin.ShowDialog() == DialogResult.OK)
        {
            Application.Run(new FormMainMenu()); //TestPort());// 
        }
    }    
}