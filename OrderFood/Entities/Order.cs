//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrderFood.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int id_Dish { get; set; }
        public decimal Prise { get; set; }
    
        public virtual Dish Dish { get; set; }
    }
}