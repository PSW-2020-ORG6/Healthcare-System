using GraphicEditor.HelpClasses;
using GraphicEditor.ViewModel;
using HealthClinicBackend.Backend.Controller;
using HealthClinicBackend.Backend.Model.Hospital;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace GraphicEditor.View.UserControls
{
    public partial class FloorUserControl : UserControl
    {
        public FloorUserControlViewModel Viewmodel;
        private bool mouseDown = false; // Set to 'true' when mouse is held down.
        private Point mouseDownPos; // The point where the mouse button was clicked down.
        private (int, int) firstGridCell;
        private (int, int) lastGridCell;
        public int SelectedCellsColumn;
        public int SelectedCellsRow;
        public int SelectedCellsColumnSpan;
        public int SelectedCellsRowSpan;
        public Dictionary<string, RoomButton> connections = new Dictionary<string, RoomButton>();
        private RoomRenovationController roomRenovationController = new RoomRenovationController();

        public FloorUserControl(MainWindowViewModel mapParent, BuildingUserControlViewModel buildingParent, Floor floor)
        {
            InitializeComponent();
            Viewmodel = new FloorUserControlViewModel(mapParent, buildingParent, this.Grid, floor, ref connections);
            this.DataContext = Viewmodel;

            TimeManaged();
        }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Release the mouse capture and stop tracking it.
            mouseDown = false;
            Grid.ReleaseMouseCapture();

            // Hide the drag selection box.
            selectionBox.Visibility = Visibility.Collapsed;

            Point mouseUpPos = e.GetPosition(Grid);

            // Find first selected Grid cell
            int row = 0;
            int col = 0;
            double accumulatedHeight = 0.0;
            double accumulatedWidth = 0.0;

            // calc row mouse was over
            foreach (var rowDefinition in Grid.RowDefinitions)
            {
                accumulatedHeight += rowDefinition.ActualHeight;
                if (accumulatedHeight >= mouseUpPos.Y)
                    break;
                row++;
            }

            // calc col mouse was over
            foreach (var columnDefinition in Grid.ColumnDefinitions)
            {
                accumulatedWidth += columnDefinition.ActualWidth;
                if (accumulatedWidth >= mouseUpPos.X)
                    break;
                col++;
            }

            lastGridCell = (col, row);

            (int, int) span = (Math.Abs(lastGridCell.Item1 - firstGridCell.Item1) + 1, Math.Abs(lastGridCell.Item2 - firstGridCell.Item2) + 1);

            if (firstGridCell.Item1 <= lastGridCell.Item1) Grid.SetColumn(selectedGridCells, firstGridCell.Item1);
            else Grid.SetColumn(selectedGridCells, lastGridCell.Item1);

            if (firstGridCell.Item2 <= lastGridCell.Item2) Grid.SetRow(selectedGridCells, firstGridCell.Item2);
            else Grid.SetRow(selectedGridCells, lastGridCell.Item2);

            Grid.SetColumnSpan(selectedGridCells, span.Item1);
            Grid.SetRowSpan(selectedGridCells, span.Item2);

            SelectedCellsColumn = firstGridCell.Item1;
            SelectedCellsRow = firstGridCell.Item2;
            SelectedCellsColumnSpan = span.Item1;
            SelectedCellsRowSpan = span.Item2;

            selectedGridCells.Visibility = Visibility.Visible;
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Capture and track the mouse.
            mouseDown = true;
            mouseDownPos = e.GetPosition(Grid);
            Grid.CaptureMouse();

            // Initial placement of the drag selection box.         
            Canvas.SetLeft(selectionBox, mouseDownPos.X);
            Canvas.SetTop(selectionBox, mouseDownPos.Y);
            selectionBox.Width = 0;
            selectionBox.Height = 0;

            // Make the drag selection box visible.
            selectionBox.Visibility = Visibility.Visible;
            selectedGridCells.Visibility = Visibility.Collapsed;

            // Find first selected Grid cell
            int row = 0;
            int col = 0;
            double accumulatedHeight = 0.0;
            double accumulatedWidth = 0.0;

            // calc row mouse was over
            foreach (var rowDefinition in Grid.RowDefinitions)
            {
                accumulatedHeight += rowDefinition.ActualHeight;
                if (accumulatedHeight >= mouseDownPos.Y)
                    break;
                row++;
            }

            // calc col mouse was over
            foreach (var columnDefinition in Grid.ColumnDefinitions)
            {
                accumulatedWidth += columnDefinition.ActualWidth;
                if (accumulatedWidth >= mouseDownPos.X)
                    break;
                col++;
            }

            firstGridCell = (col, row);
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Grid.ShowGridLines = true;
                // When the mouse is held down, reposition the drag selection box.

                Point mousePos = e.GetPosition(Grid);

                if (mouseDownPos.X < mousePos.X)
                {
                    Canvas.SetLeft(selectionBox, mouseDownPos.X);
                    selectionBox.Width = mousePos.X - mouseDownPos.X;
                }
                else
                {
                    Canvas.SetLeft(selectionBox, mousePos.X);
                    selectionBox.Width = mouseDownPos.X - mousePos.X;
                }

                if (mouseDownPos.Y < mousePos.Y)
                {
                    Canvas.SetTop(selectionBox, mouseDownPos.Y);
                    selectionBox.Height = mousePos.Y - mouseDownPos.Y;
                }
                else
                {
                    Canvas.SetTop(selectionBox, mousePos.Y);
                    selectionBox.Height = mouseDownPos.Y - mousePos.Y;
                }
            }
            else
            {
                Grid.ShowGridLines = false;
            }
        }
        private void TimeManaged()
        {
            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += ExecuteRefresh;
            LiveTime.Start();
        }

        private void ExecuteRefresh(object sender, EventArgs e)
        {
            roomRenovationController.ExecuteRoomRenovation();
            Viewmodel = new FloorUserControlViewModel(Viewmodel);
        }
    }
}
