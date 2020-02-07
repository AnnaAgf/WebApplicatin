using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplicatin.Domain.Entities.Base.Interfaces;

namespace WebApplicatin.Domain.Entities.Base
{
    public abstract class BaseEntity : IBaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        //идентификатор на первичный ключ
        // атрибуты нужны для связывания доменной модели с бд
        public int Id { get; set; }
    }
}
