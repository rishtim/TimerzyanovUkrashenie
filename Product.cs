//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ukrashenie
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Media;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.OrderProduct = new HashSet<OrderProduct>();
        }

        public string GetPhoto { get
            {
                if (ProductPhoto == null)
                {
                    return "Res/picture.png";
                }
                else
                {
                    return "Res/" + ProductPhoto;
                }
            }
        }

        public SolidColorBrush FonStyle
        {
            get
            {
                if (ProductMaxDiscount > 20)
                {
                    return (SolidColorBrush)new BrushConverter().ConvertFromString("LightGreen");
                }
                else
                {
                    return (SolidColorBrush)new BrushConverter().ConvertFromString("White");
                }
            }
        }
        public string ProductArticleNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductEdIzm { get; set; }
        public decimal ProductCost { get; set; }
        public Nullable<int> ProductMaxDiscount { get; set; }
        public string ProductManufacturer { get; set; }
        public string ProductPost { get; set; }
        public string ProductCategory { get; set; }
        public Nullable<int> ProductDiscountAmount { get; set; }
        public int ProductQuantityInStock { get; set; }
        public string ProductDescription { get; set; }
        public string ProductPhoto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
    }
}