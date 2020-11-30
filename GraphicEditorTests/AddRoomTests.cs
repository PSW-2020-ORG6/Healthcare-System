using System;
using System.Collections.Generic;
using System.Text;
using GraphicEditor.Repositories;
using GraphicEditor.View.UserControls;
using GraphicEditor.ViewModel;
using Xunit;

namespace GraphicEditorTests
{
    public class AddRoomTests
    {
        private readonly HospitalMapUserControlViewModel _hospitalMapUserControlViewModel;
        private readonly MapContentUserControlViewModel _mapContentUserControlViewModel;
        public AddRoomTests()
        {
            // Arrange
            _mapContentUserControlViewModel = new MapContentUserControlViewModel();
            _hospitalMapUserControlViewModel = new HospitalMapUserControlViewModel(_mapContentUserControlViewModel);
        }

        //[Fact]
        //public void Constructor_Test_ReturnNull()
        //{

        //    HospitalMapUserControlViewModel hospitalMapConstructorTest = new HospitalMapUserControlViewModel(_mapContentUserControlViewModel); 
            
        //    //_hospitalMapUserControlViewModel.InitialGridRender();

        //    // Assert
        //    //Assert.NotNull(hospitalMapConstructorTest);
        //}
    }
}
