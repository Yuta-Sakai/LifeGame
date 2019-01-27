using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LifeGame
{
    public partial class MyPage : ContentPage
    {
        public MyPage()
        {
            InitializeComponent();


            var rowDefinitions = new RowDefinition[10];
            var rowCollections = new RowDefinitionCollection();

            for (var i = 0; i < 10; i++)
            {
                rowDefinitions[i] = new RowDefinition { Height = 40 };
                rowCollections.Add(rowDefinitions[i]);
            }


            //列、行
            this.CellGrid.Children.Add(new Label { Text = "po0" }, 0, 0);
            this.CellGrid.Children.Add(new Label { Text = "po1" }, 0, 1);
        }

        private void OnClicked(object sender, EventArgs args)
        {
            this.labelHelloWorld.Text = "こんにちは、世界";
        }
    }
}
