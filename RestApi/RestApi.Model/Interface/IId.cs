﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RestApi.Model.Interface
{
    public interface IId<T>
    {
        [Key]
        T Id { get; set; }
    }
}
