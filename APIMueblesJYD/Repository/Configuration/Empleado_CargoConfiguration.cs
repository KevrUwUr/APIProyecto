﻿using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class Empleado_CargoConfiguration : IEntityTypeConfiguration<Empleado_Cargo>
    {
        public void Configure(EntityTypeBuilder<Empleado_Cargo> builder)
        {
            builder.HasData
            (
            new Empleado_Cargo
            {
                FechaInicio = new DateTime(1995, 5, 15),
                FechaFin = new DateTime(2015, 5, 15),
                NumeroContrato = 1,
                IdCargo = 1,
                IdEmpleado = 1
            },
            new Empleado_Cargo
            {
                FechaInicio = new DateTime(2000, 10, 03),
                FechaFin = new DateTime(2010, 12, 31),
                NumeroContrato = 2,
                IdCargo = 2,
                IdEmpleado = 2
            },

            new Empleado_Cargo
            {
                FechaInicio = new DateTime(2005, 3, 20),
                FechaFin = null,
                NumeroContrato = 3,
                IdCargo = 3,
                IdEmpleado = 3
            },

            new Empleado_Cargo
            {
                FechaInicio = new DateTime(2012, 8, 10),
                FechaFin = null,
                NumeroContrato = 4,
                IdCargo = 4,
                IdEmpleado = 4
            },

            new Empleado_Cargo
            {
                FechaInicio = new DateTime(2010, 6, 15),
                FechaFin = new DateTime(2018, 9, 30),
                NumeroContrato = 5,
                IdCargo = 5,
                IdEmpleado = 5
            });

        }
    }
}
