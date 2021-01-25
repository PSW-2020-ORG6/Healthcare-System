﻿using GraphicEditor.HelpClasses;
using HealthClinicBackend.Backend.Controller;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Util;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace GraphicEditor
{
    public partial class MainWindow : Window
    {
        private const double SCREEN_FACTOR = 0.93;
        public static TypeOfUser TypeOfUser = TypeOfUser.NoUser;
        public static Account UserProfile = null;
        public static double MainScreenWidth = SystemParameters.PrimaryScreenWidth * SCREEN_FACTOR;
        public static double MainScreenHeight = SystemParameters.PrimaryScreenHeight * SCREEN_FACTOR;
        private EquipmentRelocationController equipmentRelocationController = new EquipmentRelocationController();
        private RoomRenovationController roomRenovationController = new RoomRenovationController();

        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow.Width = MainScreenWidth;
            Application.Current.MainWindow.Height = MainScreenHeight;
            this.DataContext = new MainWindowViewModel(this);

            TimeManaged();
            TimeForEquipmentRelocation();
        }

        public MainWindow(TypeOfUser typeOfUser)
        {
            Application.Current.MainWindow.Width = MainScreenWidth;
            Application.Current.MainWindow.Height = MainScreenHeight;
            TypeOfUser = typeOfUser;

            InitializeComponent();
            TimeManaged();
            TimeForEquipmentRelocation();
        }
        private void ExecuteMethod(object sender, EventArgs e)
        {
            equipmentRelocationController.RelocateEquipmentIfItIsTime();
            roomRenovationController.ExecuteRoomRenovation();
        }
        private void TimeForEquipmentRelocation()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += ExecuteMethod;
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Start();
        }


        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (this.IsActive && this.IsEnabled)
            {
                string str = HelpProvider.GetHelpKey(this);
                HelpProvider.ShowHelp(str, this);
            }
        }

        private void TimeManaged()
        {
            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += CurrentTime;
            LiveTime.Start();
        }

        private void CurrentTime(object sender, EventArgs e)
        {
            LiveTimeLabel.Content = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
