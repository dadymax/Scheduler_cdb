﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Scheduler_Controls_Interfaces;
using Scheduler_Forms_Interfaces;
using Scheduler_Common_Interfaces;

namespace Scheduler_Forms
{
    public partial class FindClientCard : Form
    {
        IClientList clientList;

        IClient selectedClient;

        IFactory entityFactory;

        bool doNothingNow;

        public FindClientCard()
        {
            InitializeComponent();
            clientInfoCard.OnSaveChanges += new SaveChangesHandler<IClient>(clientInfoCard_OnSaveChanges);

            Init();
        }

        public FindClientCard(IClientList clientList, IFactory entityFactory)
        {
            InitializeComponent();

            this.clientList = clientList;
            this.entityFactory = entityFactory;
            clientInfoCard.OnSaveChanges += new SaveChangesHandler<IClient>(clientInfoCard_OnSaveChanges);
            Init();
        }

        void Init()
        {
            //grpEditMode.Location = grpSelectClient.Location;
            doNothingNow = false;
            if (clientList == null)
                return;

            lstClientList.DataSource = clientList.List.Cast<INamedEntity>().ToList();
            lstClientList.DisplayMember = "Name";

            var customAutoComplete = new AutoCompleteStringCollection();
            customAutoComplete.AddRange(lstClientList.Items.Cast<IClient>().Select(c => c.Name).ToArray());
            txtClientName.AutoCompleteCustomSource = customAutoComplete;

            customAutoComplete = new AutoCompleteStringCollection();
            customAutoComplete.AddRange(lstClientList.Items.Cast<IClient>().SelectMany(c => c.Telephones).ToArray());
            txtTelephone.AutoCompleteCustomSource = customAutoComplete;


            clientInfoCard.EntityFactory = entityFactory;
        }

        void clientInfoCard_OnSaveChanges(object source, SaveChangesEventArgs<IClient> e)
        {
            DeactivateEditMode();
        }

        public IClientList ClientList
        {
            get { return clientList; }
            set
            {
                clientList = value;
                Init();
            }
        }

        public IFactory EntityFactory
        {
            get { return entityFactory; }
            set
            {
                entityFactory = value;
                clientInfoCard.EntityFactory = entityFactory;
            }
        }

        public IClient SelectedClient
        {
            get { return selectedClient; }
            set
            {
                selectedClient = value;
                if (selectedClient == null)
                    return;
                doNothingNow = true;
                txtClientName.Text = selectedClient.Name;
                txtTelephone.Text = String.IsNullOrEmpty(selectedClient.Telephones.FirstOrDefault(t => t.StartsWith(txtTelephone.Text))) ? selectedClient.Telephones.FirstOrDefault()
                    : selectedClient.Telephones.FirstOrDefault(t => t.StartsWith(txtTelephone.Text));
                lstClientList.SelectedItem = selectedClient;
                doNothingNow = false;
                clientInfoCard.Client = selectedClient;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditClient_Click(object sender, EventArgs e)
        {
            if (lstClientList.SelectedIndex == -1)
                return;
            ActivateEditMode((IClient)lstClientList.SelectedItem);
        }

        private void ActivateEditMode(IClient clientInfo)
        {
            clientInfoCard.Client = clientInfo;
            /*//grpSelectClient.Visible = false;*/
            grpSelectClient.Enabled = false;
            grpSelectClient.Visible = false;

            grpEditMode.Visible = true;
            grpEditMode.Enabled = true;
            clientInfoCard.Enabled = true;
        }

        private IClient DeactivateEditMode()
        {
            IClient result = clientInfoCard.Client;

            if (result != null) //если значение не установилось - пользователь отменил закрытие.
            {
                foreach (var tel in result.Telephones)
                {
                    var existClient = ClientList.FindClientByTelephone(tel, false);
                    if (existClient != null && existClient != result)
                    {
                        var dlgResult = MessageBox.Show(
                            String.Format("Один из введённых телефонных номеров уже присутсвует в базе данных: телефон <{0}> приписан клиенту с именем <{1}>.{2}" +
                            "Использовать запись уже существующего клиента?{2}(Нет - создать запись с дублирующимся телефоном.{2}" +
                            "ВНИМАНИЕ! Поиск по номеру телефона выдает первую найденную запись!)", tel, existClient.Name, Environment.NewLine),
                            "Телефон уже внесён в базу", MessageBoxButtons.YesNoCancel);
                        switch (dlgResult)
                        {
                            case System.Windows.Forms.DialogResult.Yes:
                                result = existClient;
                                break;
                            case System.Windows.Forms.DialogResult.No:
                                break;
                            default:
                                return result;
                        }
                    }

                    if (existClient == result)
                    {
                        grpSelectClient.Visible = true;
                        grpSelectClient.Enabled = true;
                        grpEditMode.Visible = false;
                        grpEditMode.Enabled = false;
                        clientInfoCard.Enabled = false;

                        lstClientList.DataSource = clientList.List.Cast<INamedEntity>().ToList();
                        lstClientList.SelectedItem = result;
                        return result;
                    }
                }

                if (!clientList.List.Contains(result))
                {

                    grpSelectClient.Visible = true;
                    grpSelectClient.Enabled = true;
                    grpEditMode.Visible = false;
                    grpEditMode.Enabled = false;
                    clientInfoCard.Enabled = false;

                    clientList.Add(result);
                }
                lstClientList.DataSource = clientList.List.Cast<INamedEntity>().ToList();
                lstClientList.SelectedItem = result;
            }
            return result;
            //return null;
        }

        private void btnEditModeOff_Click(object sender, EventArgs e)
        {
            DeactivateEditMode();
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            IClient newClient = entityFactory.NewClient();
            ActivateEditMode(newClient);
            //clientList.List.Add(newClient);
        }

        private void lstClientList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstClientList.SelectedIndex == -1)
                return;
            //if (SelectedClient != (IClient)lstClientList.SelectedItem)
            SelectedClient = (IClient)lstClientList.SelectedItem;

            //            clientInfoCard.Client = selectedClient;
            //             txtClientName.Text = selectedClient.Name;
            //             txtTelephone.Text = selectedClient.Telephones.FirstOrDefault();
        }

        private void txtField_TextChanged(object sender, EventArgs e)
        {
            if (doNothingNow)
                return;
            var source = sender as TextBox;
            if (source == null)
                return;
            string text = source.Text;
            if (string.IsNullOrWhiteSpace(text))
                return;
            IClient curClient;
            curClient = source == txtClientName ? clientList.List.FirstOrDefault(c => c.Name == source.Text)
                : ClientList.List.FirstOrDefault(c => c.Telephones.Contains(source.Text));
            if (curClient != null)
                lstClientList.SelectedItem = curClient;
            else
                lstClientList.SelectedIndex = -1;
        }

        private void FindClientCard_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClientList.ValidateAndUpdate();
        }

        private void lstClientList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Delete && lstClientList.SelectedIndex != -1)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить пользователя\n" + ((INamedEntity)lstClientList.SelectedItem).Name + "\nиз базы?\nОтменить удаление невозможно!",
                    "Удаление пользователя из Базы",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                    return;
                try
                {
                    ClientList.Remove((IClient)lstClientList.SelectedItem);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Substring(0, 4) == "1451")
                        System.Windows.Forms.MessageBox.Show("Произошла ошибка удаления. Удаляемый клиент используется.", "Удаление невозможно.",
                            System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
                    else
                        throw ex;
                }
                lstClientList.DataSource = ClientList.List.Cast<INamedEntity>().ToList();
            }
        }

        private void txtField_KeyDown(object sender, KeyEventArgs e)
        {
            //             var source = sender as TextBox;
            //             if (source == null)
            //                 return;
            // 
            //             if (e.KeyCode == Keys.Enter && !String.IsNullOrWhiteSpace(source.Text))
            //             {
            //                 IClient curClient;
            //                 curClient = source == txtClientName ? clientList.List.FirstOrDefault(c => c.Name == source.Text)
            //                     : ClientList.List.FirstOrDefault(c => c.Telephones.Contains(source.Text));
            //                 if (curClient != null)
            //                     lstClientList.SelectedItem = curClient;
            //                 else
            //                     lstClientList.SelectedIndex = -1;
            //             }
        }




    }
}
