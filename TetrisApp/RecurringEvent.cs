﻿using System;

namespace TetrisApp
{
    public class RecurringEvent
    {
        #region VARS
        public delegate void EventActionDelegate();     //delegate
        public EventActionDelegate EventAction;         // Attribut welches mit dem auszuführenden Code befüllt wird
        public DateTime Start;
        public DateTime Stop;
        Game spiel;
        TimeSpan Interval;
        public bool EventTrigger;
        #endregion VARS


        #region CONS
        public RecurringEvent(TimeSpan IntervalMillis, Game spiel) 
        {
            Interval = IntervalMillis;
            Stop = new DateTime();
            this.spiel = spiel;
        }
        #endregion CONS


        #region METHS


        public void Execute()             // Ist die Methode des Event-Objekts (RecurringEvent), welche mit dem neu befülltem Code bestückt wurde
        {
            
            this.EventAction.Invoke();   // hier wird eine Methode (Code) aufgerufen, welche von "außen" verknüpft bzw. befüllt wird
        }


        public void Event_StartAndReset() // ...
        {
            this.Start = DateTime.Now;
            this.Stop = Start.Add(Interval);
        }


        public void GetNewBlockDownIntervall()
        {
            this.Interval = this.spiel.Config.BlockDownIntervalMS;
        }


        public void Event_IntervalCheck()
        {
            if (this.Stop < DateTime.Now)
            {
                this.Execute();
                this.Event_StartAndReset();
            }
        }

        #endregion METHS
    }
}
