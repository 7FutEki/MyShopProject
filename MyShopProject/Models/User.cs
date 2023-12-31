﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyShopProject.Models
{
    /// <summary>
    /// Id - Идентификатор пользователя в базе данных
    /// Login - Имя пользователя, как идентификатор в программе
    /// Password - Пароль пользователя
    /// Email - Почта пользователя
    /// Surname - Фамилия пользователа
    /// Name - Имя пользователя
    /// Patronymic - Отчество пользователя
    /// NumberPhone - Номер телефона пользователя
    /// Birthday - День рождения пользователя
    /// PhotoByte - Фотография пользователя в виде массива байтов
    /// Sex - Пол пользователя
    /// Tag - Тэг пользователя для сотрудников
    /// </summary>
    public class User
    {
        //Первичный ключ и автоинкремент для ид пользователя
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Patronymic { get; set; }
        public string? NumberPhone { get; set; }
        public string? Birthday { get; set; }
        public byte[]? PhotoByte { get; set; }
        public string? Sex { get; set; }
        public string? Tag { get; set; }
    }
}
