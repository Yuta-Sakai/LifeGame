using System;
using System.Collections.Generic;

using Xamarin.Forms;

using LifeGame.Model;

namespace LifeGame
{
    public partial class MyPage : ContentPage
    {
        private Cells cells;


        public MyPage()
        {
            InitializeComponent();


            this.cells = new Cells();

            var rowCollections = new RowDefinitionCollection();
            for (var i = 0; i < 10; i++)
            {
                rowCollections.Add(new RowDefinition { Height = 20 });

            }

            this.CellGrid.RowDefinitions = rowCollections;


            var columnCollections = new ColumnDefinitionCollection();
            for (var i = 0; i <10; i++)
            {
                columnCollections.Add(new ColumnDefinition { Width = 20 });
            }

            this.CellGrid.ColumnDefinitions = columnCollections;


            for(var column = 0; column <= cells.MaxColumn ; column++)
            {
                for(var row = 0; row <= cells.MaxRow; row++)
                {
                    var label = new Label();
                    label.BackgroundColor = Color.LightGray;

                    var point = new LifeGame.Model.Point(column, row);

                    var cell = cells.GetCell(point);

                    cell.SubscribeChangeToAlive
                        (() => Device.BeginInvokeOnMainThread(() => label.BackgroundColor = Color.Black));

                    cell.SubscribeChangeToDead
                        (() => Device.BeginInvokeOnMainThread(() => label.BackgroundColor = Color.LightGray));

                    label.BackgroundColor = Color.LightGray;
                    cell.ToDead();

                    this.CellGrid.Children.Add(label, column, row);
                }
            }


            ////列、行
            //this.CellGrid.Children.Add(new Label { Text = "po0" }, 0, 0);
            //this.CellGrid.Children.Add(new Label { Text = "po1" }, 0, 1);
        }



        private void Run()
        {
            while (true)
            {
                this.cells.Next();
            }
        }




        private void OnClicked(object sender, EventArgs args)
        {
            this.labelHelloWorld.Text = "こんにちは、世界";
        }
    }
}
