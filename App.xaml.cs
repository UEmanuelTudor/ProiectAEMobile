using System;
using ProiectAEMobile.Data;
using System.IO;

namespace ProiectAEMobile;

public partial class App : Application
{
    static ProgramariListDatabase database;
    public static ProgramariListDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               ProgramariListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "ProgramariList.db3"));
            }
            return database;
        }
    }

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
