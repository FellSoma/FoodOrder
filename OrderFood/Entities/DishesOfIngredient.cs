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
    
    public partial class DishesOfIngredient
    {
        public int id { get; set; }
        public int id_Dishes { get; set; }
        public int id_ingridient { get; set; }
        public Nullable<double> weigth { get; set; }
    
        public virtual Dish Dish { get; set; }
        public virtual Product Product { get; set; }
    }
}
