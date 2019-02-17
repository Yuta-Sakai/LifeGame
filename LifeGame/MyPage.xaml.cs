using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;

using LifeGame.Model;

namespace LifeGame
{
    public partial class MyPage : ContentPage
    {
        private Cells cells;
        private bool isStop;
        private bool isStarted;

        public MyPage()
        {
            InitializeComponent();

            this.isStarted = false;


            this.cells = new Cells();

            var rowCollections = new RowDefinitionCollection();
            for (var row = 0; row < cells.MaxRow(); row++)
            {
                rowCollections.Add(new RowDefinition { Height = 20 });
            }

            this.CellGrid.RowDefinitions = rowCollections;


            var columnCollections = new ColumnDefinitionCollection();
            for (var columun = 0; columun < cells.MaxColumn(); columun++)
            {
                columnCollections.Add(new ColumnDefinition { Width = 20 });
            }

            this.CellGrid.ColumnDefinitions = columnCollections;


            for(var column = 0; column < cells.MaxColumn() ; column++)
            {
                for(var row = 0; row < cells.MaxRow(); row++)
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

                    var tgr = new TapGestureRecognizer();
                    tgr.Tapped += (sendr, e) =>
                    {
                        this.isStop = true;
                        this.isStarted = false;
                        cell.ChangeStatus();
                    };

                    label.GestureRecognizers.Add(tgr);

                    this.CellGrid.Children.Add(label, column, row);
                }
            }


            ///bttonGrid

            ////列、行
            //this.CellGrid.Children.Add(new Label { Text = "po0" }, 0, 0);
            //this.CellGrid.Children.Add(new Label { Text = "po1" }, 0, 1);
        }



        private async void OnStartClicked(object sender , EventArgs args)
        {
            if (this.isStarted) return;

            this.isStop = false;
            this.isStarted = true;

            await Task.Run( () =>
            {
                while (!isStop)
                {
                    this.cells.Next();
                    Thread.Sleep(500);
                }
            });
        }



        private void OnStopClicked(object sender, EventArgs args)
        {
            this.isStarted = false;
            this.isStop = true;

        }
    }
}
