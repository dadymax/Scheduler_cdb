﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scheduler_Controls_Interfaces
{
    /// <summary>
    /// Интерфейс, обобщающий значимые. Для типизированных template.
    /// </summary>
    public interface IDummy
    {

    }

    /// <summary>
    /// Коренной интерфейс для сущностей, имеющих имя/название.
    /// </summary>
    public interface INamedEntity
    {
        string Name { get; set; }
    }

    /// <summary>
    /// Интерфейс клиента.
    /// </summary>
    public interface IClient : INamedEntity, IDummy
    {
        string Comment { get; set; }

        bool BlackListed { get; set; }

        HashSet<string> Telephones { get; set; }

        /// <summary>
        /// Проверить, входит ли переданный телефон в список телефонов клиента.
        /// </summary>
        /// <param name="telNumber">Строка с номером телефона.</param>
        /// <returns>true если входит.</returns>
        bool CheckTelephone(string telNumber);
        // 
        //         /// <summary>
        //         /// Добавляет (если ещё нет) или удаляет (если уже есть) номер телефона.
        //         /// </summary>
        //         string Telephone { set; }

        List<string> Receptions { get; }
    }

    /// <summary>
    /// Интерфейс специалиста.
    /// </summary>
    public interface ISpecialist : INamedEntity, IDummy
    {
        bool NotWorking { get; set; }

        HashSet<string> Specialisations { get; set; }

        //         /// <summary>
        //         /// Добавляет (если ещё нет) или удаляет (если уже есть) специализацию.
        //         /// </summary>
        //         string Specialisation { set; }

    }

    /// <summary>
    /// Интерфейс кабинета.
    /// </summary>
    public interface ICabinet : INamedEntity, IDummy
    {
        bool Availability { get; set; }
    }

    /// <summary>
    /// Интерфейс записи на приём.
    /// </summary>
    public interface IReception: IDummy
    {
        ITimeInterval ReceptionTimeInterval { get; set; }
        IClient Client { get; set; }
        ISpecialist Specialist { get; set; }
        ICabinet Cabinet { get; set; }

        string Specialization { get; set; }
        bool Rent { get; set; }

        /// <summary>
        /// Проверить данные на валидность.
        /// </summary>
        /// <returns>null в случае отсутствия проблем. Сообщение с пояснениями, что не так, в случае ошибки.</returns>
        string Validate();
    }

    /// <summary>
    /// Интерфейс временного интервала приёма.
    /// </summary>
    public interface ITimeInterval
    {
        DateTime Date { get; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }

    public interface ISpecializationList: IDummy
    {
        HashSet<string> SpecializationList { get; set; }
    }

    public interface ITelephone
    {
        /// <summary>
        /// Номер телефона как строка из цифр.
        /// </summary>
        string TelephoneNumber { get; set; }

        /// <summary>
        /// Номер телефона в виде отформатированной строки.
        /// </summary>
        string FormattedTelephoneNumber { get; }

    }

    public interface IFactory
    {
        T Create<T>();
    }

    public delegate void SaveChangesHandler<T>(object source, SaveChangesEventArgs<T> e) where T: IDummy;

    public class SaveChangesEventArgs<T> : EventArgs where T: IDummy
    {
        private T ChangedEntity;
        public SaveChangesEventArgs(T input)
        {
            ChangedEntity = input;
        }

        public T Entity
        {
            get { return ChangedEntity; }
        }
    }
}
