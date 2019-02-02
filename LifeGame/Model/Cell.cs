using System;
using System.Linq;
using System.Collections.Generic;


namespace LifeGame.Model
{
    public class Cell
    {
        private Point point;
        private Status status;
        private List<Action> subscriberChangeToDead;
        private List<Action> subscriberChangeToAlive;


        public Cell(Point point)
        {
            this.point = point;

            this.subscriberChangeToDead = new List<Action>();
            this.subscriberChangeToAlive = new List<Action>();

            this.status = new Status();
            this.status.SubscribeChangeAlive(this.NotifyChangeToAlive);
            this.status.SubscribeChangeDead(this.NotifyChangeToDead);

            this.status.ToDead();
        }

        public void ChangeStatus() => this.status.Change();

        public Point Point => this.point;

        public Status Status => this.status;

        public Boolean IsAlive => this.status.IsAlive;




        public void SetNextIsAliveOrDead(int alives)
        {
            switch (alives)
            {
                case 1:
                    this.status.NextIsDead();
                    break;

                case 2:
                    if (this.IsAlive)
                    {
                        this.status.NextIsAlive();
                    }
                    else
                    {
                        this.status.NextIsDead();
                    };
                    break;

                case 3:
                    this.status.NextIsAlive();
                    break;

                default:
                    this.status.NextIsDead();
                    break;
            }
        }



        public void ToDead()
        {
            this.status.ToDead();
        }


        public void ToAlive()
        {
            this.status.ToAlive();
        }


        public void Next()
        {
            this.status.Next();
        }


        public void SubscribeChangeToDead(Action action)
        {
            this.subscriberChangeToDead.Add(action);

        }


        public void NotifyChangeToDead()
        {
            this.subscriberChangeToDead.ForEach(action => action());
        }



        public void SubscribeChangeToAlive(Action action)
        {
            this.subscriberChangeToAlive.Add(action);
        }




        public void NotifyChangeToAlive()
        {
            this.subscriberChangeToAlive.ForEach(action => action());
        }
    }
}
