//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sheldon.база
{
    using System;
    using System.Collections.Generic;
    
    public partial class Personazh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personazh()
        {
            this.Foto = new HashSet<Foto>();
            this.Personazh_and_Acter = new HashSet<Personazh_and_Acter>();
        }
    
        public int id { get; set; }
        public string Names { get; set; }
        public string Familia_personazh { get; set; }
        public Nullable<System.DateTime> Date_of_birth { get; set; }
        public int id_Gender { get; set; }
        public string Iq { get; set; }
        public Nullable<int> id_Religia { get; set; }
        public Nullable<int> id_Nacionalnost { get; set; }
        public Nullable<int> id_Proisxozhenie { get; set; }
        public string Rod_zanatiy { get; set; }
        public string Informacia { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Foto> Foto { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Nacionalnost Nacionalnost { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personazh_and_Acter> Personazh_and_Acter { get; set; }
        public virtual Proisxozhenie Proisxozhenie { get; set; }
        public virtual Religia Religia { get; set; }
    }
}
