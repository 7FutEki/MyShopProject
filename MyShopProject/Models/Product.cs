using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopProject.Models
{
    /// <summary>
    /// Id -  Идентификатор товара
    /// Title - Название товара
    /// Price - Цена товара
    /// Manufacturer - Производитель товара
    /// Active - Активен/Неактивен товар
    /// PhotoByte - Фотография товара в массиве байтов
    /// Description - Описание товара
    /// </summary>
    public class Product
    {
        //Первичный ключ и автоинкремент для ид пользователя
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public string Manufacturer { get; set; }
        public bool Active { get; set; }
        public byte[] PhotoByte { get; set; }
        public string Description { get; set; }

    }
}
