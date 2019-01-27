using System;
using System.Collections.Generic;

namespace LifeGame.Model
{
    public class Status
    {
        private CellStatus status;
        private CellStatus nextStatus;

        private List<Action> subscribersChangeToAlive;
        private List<Action> subscribersChangeToDead;

        private enum CellStatus { Alive, Dead};


        public Status()
        {
            this.subscribersChangeToDead = new List<Action>();
            this.subscribersChangeToAlive = new List<Action>();

        }



        public bool IsAlive => this.status == CellStatus.Alive;



        public void Change()
        { 
            switch (this.status)
            {
                case CellStatus.Alive:
                    this.ToDead();
                    break;

                case CellStatus.Dead:
                    this.ToAlive();
                    break;
            }

            this.NotifyStatusIsChanged();
        }



        public void ToAlive()
        {
            this.Change(CellStatus.Alive);
        }



        public void ToDead()
        {
            this.Change(CellStatus.Dead);
        }



        public void NextIsAlive()
        {
            this.nextStatus = CellStatus.Alive;
        }



        public void NextIsDead()
        {
            this.nextStatus = CellStatus.Dead;
        }



        public  void Next()
        {
            this.Change(this.nextStatus);
        }



        private void Change(CellStatus cellStatus)
        {
            if(this.status != cellStatus)
            {
                this.status = cellStatus;
                this.NotifyStatusIsChanged();
            }
        }



        public void SubscribeChangeAlive(Action action)
        {
            this.subscribersChangeToAlive.Add(action);
        }



        public void SubscribeChangeDead(Action action)
        {
            this.subscribersChangeToDead.Add(action);
        }


        public void NotifyStatusIsChanged()
        {
            switch (this.status)
            {
                case CellStatus.Alive:
                    this.subscribersChangeToAlive.ForEach(x => x());
                    break;

                case CellStatus.Dead:
                    this.subscribersChangeToDead.ForEach(x => x());
                    break;
            }
        }
    }
}
