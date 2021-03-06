﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Scheduler_InterfacesRealisations
{
    public class Client : CommonObjectWithNotify, Scheduler_Controls_Interfaces.IClient
    {
        string comment;
        bool blacklisted;
        HashSet<string> telephones;
        string name;

        static Scheduler_Controls_Interfaces.GetClientReceptionsList getreceptions;


        public Client()
        {
            name = String.Empty;
            comment = String.Empty;
            telephones = new HashSet<string>();
            blacklisted = false;
        }

        string Scheduler_Controls_Interfaces.IClient.Comment
        {
            get
            {
                return comment;
            }
            set
            {
                comment = value;
                RaisePropertyChanged("Comment");
            }
        }

        bool Scheduler_Controls_Interfaces.IClient.BlackListed
        {
            get
            {
                return blacklisted;
            }
            set
            {
                blacklisted = value;
                RaisePropertyChanged("Blacklisted");
            }
        }

        HashSet<string> Scheduler_Controls_Interfaces.IClient.Telephones
        {
            get
            {
                return telephones;
            }
            set
            {
                telephones = value;
                RaisePropertyChanged("Telephones");
            }
        }

        bool Scheduler_Controls_Interfaces.IClient.CheckTelephone(string telNumber)
        {
            return telephones.Contains(telNumber);
        }


        List<Scheduler_Controls_Interfaces.IReception> Scheduler_Controls_Interfaces.IClient.GetReceptions()
        {
                if (getreceptions != null)
                    return getreceptions(this);
                else
                    return new List<Scheduler_Controls_Interfaces.IReception>();
        }

        string Scheduler_Controls_Interfaces.INamedEntity.Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        void Scheduler_Controls_Interfaces.IClient.ReceptionListFuncition(Scheduler_Controls_Interfaces.GetClientReceptionsList func)
        {
            if (getreceptions == null)
                getreceptions = func;
        }
    }

    public class ClientList : CommonList<Scheduler_Controls_Interfaces.IClient>, Scheduler_Forms_Interfaces.IClientList
    {
        //List<Scheduler_Controls_Interfaces.IClient> list;

        public ClientList(): base()
        {
            //list = new List<Scheduler_Controls_Interfaces.IClient>();
        }

        ClientList(ClientList old): base(old)
        {
            //list = new List<Scheduler_Controls_Interfaces.IClient>(old.list);
        }

        Scheduler_Controls_Interfaces.IClient Scheduler_Forms_Interfaces.IClientList.FindClientByPartialName(string partialName)
        {
            Scheduler_Controls_Interfaces.IClient result;
            result = this.List.FirstOrDefault(c => c.Name.StartsWith(partialName));
            return result;
        }

        Scheduler_Controls_Interfaces.IClient Scheduler_Forms_Interfaces.IClientList.FindClientByTelephone(string Tel, bool partial)
        {
            Scheduler_Controls_Interfaces.IClient result;
            result = partial ? this.List.FirstOrDefault(c => c.Telephones.FirstOrDefault(t => t.StartsWith(Tel)) != default(string)) :
                this.List.FirstOrDefault(c => c.Telephones.FirstOrDefault(t => t == Tel) != default(string));
            return result;
        }

//         List<Scheduler_Controls_Interfaces.IClient> Scheduler_Forms_Interfaces.IEntityList<Scheduler_Controls_Interfaces.IClient>.List
//         {
//             get { return list; }
//         }

//         Scheduler_Forms_Interfaces.IEntityList<Scheduler_Controls_Interfaces.IClient> Scheduler_Forms_Interfaces.IEntityList<Scheduler_Controls_Interfaces.IClient>.Copy()
//         {
//             return new ClientList(this);
//         }

        public override Scheduler_Forms_Interfaces.IEntityList<Scheduler_Controls_Interfaces.IClient> Copy()
        {
            return new ClientList(this);
        }
    }
}
