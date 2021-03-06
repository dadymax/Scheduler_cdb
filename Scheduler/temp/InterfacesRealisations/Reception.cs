﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfacesRealisations
{
    public class Reception : Scheduler_DBobjects_Intefraces.IEntity
    {
        Scheduler_Controls_Interfaces.ITimeInterval receptionTimeInterval;
        Scheduler_Controls_Interfaces.IClient client;
        Scheduler_Controls_Interfaces.ISpecialist specialist;
        Scheduler_Controls_Interfaces.ICabinet cabinet;
        string specialisation;
        bool isRented;
        public delegate void DisposeThis();
        DisposeThis DisposeThisFunction;

        Scheduler_Controls_Interfaces.ITimeInterval Scheduler_Controls_Interfaces.IReception.ReceptionTimeInterval
        {
            get { return receptionTimeInterval; }
            set { receptionTimeInterval = value; }
        }

        Scheduler_Controls_Interfaces.IClient Scheduler_Controls_Interfaces.IReception.Client
        {
            get { return client; }
            set { client = value; }
        }

        Scheduler_Controls_Interfaces.ISpecialist Scheduler_Controls_Interfaces.IReception.Specialist
        {
            get { return specialist; }

            set { specialist = value; }
        }

        Scheduler_Controls_Interfaces.ICabinet Scheduler_Controls_Interfaces.IReception.Cabinet
        {
            get { return cabinet; }
            set { cabinet = value; }
        }

        string Scheduler_Controls_Interfaces.IReception.Specialization
        {
            get { return specialisation; }
            set { specialisation = value; }
        }

        bool Scheduler_Controls_Interfaces.IReception.Rent
        {
            get { return isRented; }
            set { isRented = value; }
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
                    result += "Клиент не задан.";
            }
            return result == String.Empty ? null : result;
        }



        void Scheduler_Controls_Interfaces.IReception.Dispose()
        {
            if (DisposeThisFunction != null)
                DisposeThisFunction();
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
                    return receptionTimeInterval.Interval() + Environment.NewLine + specialist + Environment.NewLine + specialisation + Environment.NewLine + client;
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

        ulong CalendarControl3_Interfaces.IEntity2ControlInterface.ID
        {
            get { throw new NotImplementedException(); }
        }
    }
}
