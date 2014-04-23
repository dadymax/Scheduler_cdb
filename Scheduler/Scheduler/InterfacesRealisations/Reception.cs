﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scheduler_InterfacesRealisations
{
    public class Reception : CommonObjectWithNotify, Scheduler_DBobjects_Intefraces.IEntity
    {
        Scheduler_Controls_Interfaces.ITimeInterval receptionTimeInterval;
        Scheduler_Controls_Interfaces.IClient client;
        Scheduler_Controls_Interfaces.ISpecialist specialist;
        Scheduler_Controls_Interfaces.ICabinet cabinet;
        string specialisation;
        bool isRented;

        static Scheduler_DBobjects_Intefraces.IMainDataBase database;

        int id;

        Scheduler_Controls_Interfaces.ITimeInterval Scheduler_Controls_Interfaces.IReception.ReceptionTimeInterval
        {
            get { return receptionTimeInterval; }
            set { receptionTimeInterval = value; RaisePropertyChanged("ReceptionTimeInterval"); }
        }

        Scheduler_Controls_Interfaces.IClient Scheduler_Controls_Interfaces.IReception.Client
        {
            get { return client; }
            set { client = value; RaisePropertyChanged("Client"); }
        }

        Scheduler_Controls_Interfaces.ISpecialist Scheduler_Controls_Interfaces.IReception.Specialist
        {
            get { return specialist; }

            set { specialist = value; RaisePropertyChanged("Specialist"); }
        }

        Scheduler_Controls_Interfaces.ICabinet Scheduler_Controls_Interfaces.IReception.Cabinet
        {
            get { return cabinet; }
            set { cabinet = value; RaisePropertyChanged("Cabinet"); }
        }

        string Scheduler_Controls_Interfaces.IReception.Specialization
        {
            get { return specialisation; }
            set { specialisation = value; RaisePropertyChanged("Specialization"); }
        }

        bool Scheduler_Controls_Interfaces.IReception.Rent
        {
            get { return isRented; }
            set { isRented = value; RaisePropertyChanged("Rent"); }
        }

        string Scheduler_Controls_Interfaces.IReception.Validate()
        {
            string result = String.Empty;
            if (receptionTimeInterval == null)
                result += "Временной интервал не задан." + Environment.NewLine;
            if (specialist == null)
                result += "Специалист не задан." + Environment.NewLine;

            if (isRented)
            {

            }
            else
            {
                if (String.IsNullOrWhiteSpace(specialisation))
                    result += "Специализация не задана." + Environment.NewLine;
                if (client == null)
                    result += "Клиент не задан." + Environment.NewLine;
            }

            if (database != null)
            {
                List<Scheduler_DBobjects_Intefraces.IEntity> receptionsIntersectedWith = new List<Scheduler_DBobjects_Intefraces.IEntity>();
                foreach (var r in database.SelectReceptionsFromDate(this.receptionTimeInterval.Date).Where(r => r.Cabinet.ID == this.cabinet.ID && r.IsIntersectWith(this)))
                    receptionsIntersectedWith.Add(r);
                if (receptionsIntersectedWith.Count != 0)
                    result += "Время посещения пересекается с другими: " + Environment.NewLine;
                foreach (var r in receptionsIntersectedWith)
                    result += r.DisplayString + Environment.NewLine;//r.ReceptionTimeInterval.Interval() + Environment.NewLine;
            }

            return result == String.Empty ? null : result;
        }

        string CalendarControl3_Interfaces.IEntity2ControlInterface.StringToShow
        {
            get
            {
                if (isRented)
                {
                    return receptionTimeInterval.Interval() + Environment.NewLine + specialist;
                }
                else
                {
                    return receptionTimeInterval.Interval() + Environment.NewLine + specialist.Name + Environment.NewLine + specialisation + Environment.NewLine + client.Name;
                }
            }
        }

        int CalendarControl3_Interfaces.IEntity2ControlInterface.TopLevel
        {
            get { return Convert.ToInt32(Math.Truncate(receptionTimeInterval.StartDate.TimeOfDay.TotalMinutes)); }
        }

        int CalendarControl3_Interfaces.IEntity2ControlInterface.BottomLevel
        {
            get { return Convert.ToInt32(Math.Truncate(receptionTimeInterval.EndDate.TimeOfDay.TotalMinutes)); }
        }

        //         ulong CalendarControl3_Interfaces.IEntity2ControlInterface.ID
        //         {
        //             get { return Convert.ToUInt64(id); }
        //         }


        bool CalendarControl3_Interfaces.IEntity2ControlInterface.IsIntersectWith(CalendarControl3_Interfaces.IEntity2ControlInterface second)
        {
            CalendarControl3_Interfaces.IEntity2ControlInterface theThis = this as CalendarControl3_Interfaces.IEntity2ControlInterface;
            bool topIntersect = theThis.TopLevel > second.TopLevel && theThis.TopLevel < second.BottomLevel;
            bool bottomIntersect = theThis.BottomLevel < second.BottomLevel && theThis.BottomLevel > second.TopLevel;
            return topIntersect || bottomIntersect;
        }

        int Scheduler_Controls_Interfaces.IHaveID.ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value; RaisePropertyChanged("ID");
            }
        }


        string Scheduler_Controls_Interfaces.IReception.DisplayString
        {
            get { return receptionTimeInterval.Interval() + " " + specialist.Name + " " + specialisation + " " + cabinet.Name; }
        }

        void Scheduler_DBobjects_Intefraces.IEntity.SetDatabase(Scheduler_DBobjects_Intefraces.IMainDataBase db)
        {
            if (database == null)
                database = db;
        }

    }
}
