﻿/*
 * Created by SharpDevelop.
 * User: ANC_04
 * Date: 09.05.2013
 * Time: 14:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Scheduler
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainView = new System.Windows.Forms.SplitContainer();
            this.datePicker = new System.Windows.Forms.TextBox();
            this.buttonShowToday = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.расписаниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выбратьДатуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сформироватьОтчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.приемыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.назначитьПриемToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйКлиентToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.найтиКлиентаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.просмотретьЧерныйСписокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.специалистыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйСпециалистToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.найтиСпециалистаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кабинетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйКабинетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьКабинетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.базаДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сделатьРезервнуюКопиюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.развернутьРезервнуюКопиюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.инструкцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.контактыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.mainView)).BeginInit();
            this.mainView.Panel2.SuspendLayout();
            this.mainView.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainView
            // 
            this.mainView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainView.Location = new System.Drawing.Point(0, 24);
            this.mainView.Name = "mainView";
            // 
            // mainView.Panel1
            // 
            this.mainView.Panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            // 
            // mainView.Panel2
            // 
            this.mainView.Panel2.Controls.Add(this.datePicker);
            this.mainView.Panel2.Controls.Add(this.buttonShowToday);
            this.mainView.Panel2.Controls.Add(this.label1);
            this.mainView.Panel2.Controls.Add(this.monthCalendar);
            this.mainView.Size = new System.Drawing.Size(920, 407);
            this.mainView.SplitterDistance = 683;
            this.mainView.TabIndex = 3;
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(31, 32);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(163, 20);
            this.datePicker.TabIndex = 7;
            this.datePicker.TextChanged += new System.EventHandler(this.DatePickerTextChanged);
            // 
            // buttonShowToday
            // 
            this.buttonShowToday.Enabled = false;
            this.buttonShowToday.Location = new System.Drawing.Point(31, 238);
            this.buttonShowToday.Name = "buttonShowToday";
            this.buttonShowToday.Size = new System.Drawing.Size(163, 35);
            this.buttonShowToday.TabIndex = 6;
            this.buttonShowToday.Text = "Вернуться к расписанию на сегодня";
            this.buttonShowToday.UseVisualStyleBackColor = true;
            this.buttonShowToday.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(31, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Расписание  на";
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(31, 64);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 3;
            this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.MonthCalendarDateChanged);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.расписаниеToolStripMenuItem,
            this.приемыToolStripMenuItem,
            this.клиентыToolStripMenuItem,
            this.специалистыToolStripMenuItem,
            this.кабинетыToolStripMenuItem,
            this.базаДанныхToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(920, 24);
            this.mainMenu.TabIndex = 4;
            this.mainMenu.Text = "mainMenu";
            // 
            // расписаниеToolStripMenuItem
            // 
            this.расписаниеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выбратьДатуToolStripMenuItem,
            this.сформироватьОтчетToolStripMenuItem,
            this.закрытьToolStripMenuItem});
            this.расписаниеToolStripMenuItem.Name = "расписаниеToolStripMenuItem";
            this.расписаниеToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.расписаниеToolStripMenuItem.Text = "Расписание";
            // 
            // выбратьДатуToolStripMenuItem
            // 
            this.выбратьДатуToolStripMenuItem.Name = "выбратьДатуToolStripMenuItem";
            this.выбратьДатуToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.выбратьДатуToolStripMenuItem.Text = "Выбрать дату";
            // 
            // сформироватьОтчетToolStripMenuItem
            // 
            this.сформироватьОтчетToolStripMenuItem.Name = "сформироватьОтчетToolStripMenuItem";
            this.сформироватьОтчетToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.сформироватьОтчетToolStripMenuItem.Text = "Сформировать отчет";
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            // 
            // приемыToolStripMenuItem
            // 
            this.приемыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.назначитьПриемToolStripMenuItem});
            this.приемыToolStripMenuItem.Name = "приемыToolStripMenuItem";
            this.приемыToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.приемыToolStripMenuItem.Text = "Приемы";
            // 
            // назначитьПриемToolStripMenuItem
            // 
            this.назначитьПриемToolStripMenuItem.Name = "назначитьПриемToolStripMenuItem";
            this.назначитьПриемToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.назначитьПриемToolStripMenuItem.Text = "Назначить прием";
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйКлиентToolStripMenuItem,
            this.найтиКлиентаToolStripMenuItem,
            this.просмотретьЧерныйСписокToolStripMenuItem});
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            // 
            // новыйКлиентToolStripMenuItem
            // 
            this.новыйКлиентToolStripMenuItem.Name = "новыйКлиентToolStripMenuItem";
            this.новыйКлиентToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.новыйКлиентToolStripMenuItem.Text = "Новый клиент";
            // 
            // найтиКлиентаToolStripMenuItem
            // 
            this.найтиКлиентаToolStripMenuItem.Name = "найтиКлиентаToolStripMenuItem";
            this.найтиКлиентаToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.найтиКлиентаToolStripMenuItem.Text = "Найти клиента";
            // 
            // просмотретьЧерныйСписокToolStripMenuItem
            // 
            this.просмотретьЧерныйСписокToolStripMenuItem.Name = "просмотретьЧерныйСписокToolStripMenuItem";
            this.просмотретьЧерныйСписокToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.просмотретьЧерныйСписокToolStripMenuItem.Text = "Просмотреть черный список";
            // 
            // специалистыToolStripMenuItem
            // 
            this.специалистыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйСпециалистToolStripMenuItem,
            this.найтиСпециалистаToolStripMenuItem});
            this.специалистыToolStripMenuItem.Name = "специалистыToolStripMenuItem";
            this.специалистыToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.специалистыToolStripMenuItem.Text = "Специалисты";
            // 
            // новыйСпециалистToolStripMenuItem
            // 
            this.новыйСпециалистToolStripMenuItem.Name = "новыйСпециалистToolStripMenuItem";
            this.новыйСпециалистToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.новыйСпециалистToolStripMenuItem.Text = "Новый специалист";
            // 
            // найтиСпециалистаToolStripMenuItem
            // 
            this.найтиСпециалистаToolStripMenuItem.Name = "найтиСпециалистаToolStripMenuItem";
            this.найтиСпециалистаToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.найтиСпециалистаToolStripMenuItem.Text = "Найти  специалиста";
            // 
            // кабинетыToolStripMenuItem
            // 
            this.кабинетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйКабинетToolStripMenuItem,
            this.редактироватьКабинетыToolStripMenuItem});
            this.кабинетыToolStripMenuItem.Name = "кабинетыToolStripMenuItem";
            this.кабинетыToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.кабинетыToolStripMenuItem.Text = "Кабинеты";
            // 
            // новыйКабинетToolStripMenuItem
            // 
            this.новыйКабинетToolStripMenuItem.Name = "новыйКабинетToolStripMenuItem";
            this.новыйКабинетToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.новыйКабинетToolStripMenuItem.Text = "Новый кабинет";
            // 
            // редактироватьКабинетыToolStripMenuItem
            // 
            this.редактироватьКабинетыToolStripMenuItem.Name = "редактироватьКабинетыToolStripMenuItem";
            this.редактироватьКабинетыToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.редактироватьКабинетыToolStripMenuItem.Text = "Редактировать кабинеты";
            // 
            // базаДанныхToolStripMenuItem
            // 
            this.базаДанныхToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сделатьРезервнуюКопиюToolStripMenuItem,
            this.развернутьРезервнуюКопиюToolStripMenuItem});
            this.базаДанныхToolStripMenuItem.Name = "базаДанныхToolStripMenuItem";
            this.базаДанныхToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.базаДанныхToolStripMenuItem.Text = "База данных";
            // 
            // сделатьРезервнуюКопиюToolStripMenuItem
            // 
            this.сделатьРезервнуюКопиюToolStripMenuItem.Name = "сделатьРезервнуюКопиюToolStripMenuItem";
            this.сделатьРезервнуюКопиюToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.сделатьРезервнуюКопиюToolStripMenuItem.Text = "Сделать резервную копию";
            // 
            // развернутьРезервнуюКопиюToolStripMenuItem
            // 
            this.развернутьРезервнуюКопиюToolStripMenuItem.Name = "развернутьРезервнуюКопиюToolStripMenuItem";
            this.развернутьРезервнуюКопиюToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.развернутьРезервнуюКопиюToolStripMenuItem.Text = "Развернуть резервную копию";
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.инструкцииToolStripMenuItem,
            this.контактыToolStripMenuItem});
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // инструкцииToolStripMenuItem
            // 
            this.инструкцииToolStripMenuItem.Name = "инструкцииToolStripMenuItem";
            this.инструкцииToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.инструкцииToolStripMenuItem.Text = "Инструкции";
            // 
            // контактыToolStripMenuItem
            // 
            this.контактыToolStripMenuItem.Name = "контактыToolStripMenuItem";
            this.контактыToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.контактыToolStripMenuItem.Text = "Контакты";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 431);
            this.Controls.Add(this.mainView);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Scheduler";
            this.mainView.Panel2.ResumeLayout(false);
            this.mainView.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainView)).EndInit();
            this.mainView.ResumeLayout(false);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.ToolStripMenuItem контактыToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem инструкцииToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem развернутьРезервнуюКопиюToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem сделатьРезервнуюКопиюToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem базаДанныхToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem редактироватьКабинетыToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem новыйКабинетToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem кабинетыToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem найтиСпециалистаToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem новыйСпециалистToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem специалистыToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem просмотретьЧерныйСписокToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem найтиКлиентаToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem новыйКлиентToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem назначитьПриемToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem приемыToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem сформироватьОтчетToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem выбратьДатуToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem расписаниеToolStripMenuItem;
		private System.Windows.Forms.MenuStrip mainMenu;
		private System.Windows.Forms.Button buttonShowToday;
        private System.Windows.Forms.TextBox datePicker;
		private System.Windows.Forms.SplitContainer mainView;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar monthCalendar;
	}
}
