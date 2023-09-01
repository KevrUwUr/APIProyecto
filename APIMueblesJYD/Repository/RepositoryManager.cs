﻿using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ICargoRepository> _cargoRepository;
        private readonly Lazy<ICategoriaRepository> _categoriaRepository;
        private readonly Lazy<IContactoEmpleadoRepository> _contactoEmpleadoRepository;
        private readonly Lazy<IContactoProveedorRepository> _contactoProveedorRepository;
        private readonly Lazy<IContactoUsuarioRepository> _contactoUsuarioRepository;
        private readonly Lazy<IDetFacturaCompraRepository> _detFacturaCompraRepository;
        private readonly Lazy<IDetFacturaVentaRepository> _detFacturaVentaRepository;
        private readonly Lazy<IEmpleadoCargoRepository> _empleadoCargoRepository;
        private readonly Lazy<IEmpleadoRepository> _empleadoRepository;
        private readonly Lazy<IFacturaCompraRepository> _facturaCompraRepository;
        private readonly Lazy<IFacturaVentaRepository> _facturaVentaRepository;
        private readonly Lazy<IHistoricoPreciosRepository> _historicoPreciosRepository;
        private readonly Lazy<IMetodoPagoRepository> _metodoPagoRepository;
        private readonly Lazy<IPerdidaProductoRepository> _perdidaProductoRepository;
        private readonly Lazy<IPerdidaRepository> _perdidaRepository;
        private readonly Lazy<IProductoRepository> _productoRepository;
        private readonly Lazy<IProveedorRepository> _proveedorRepository;
        private readonly Lazy<IUsuarioRepository> _UsuarioRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _cargoRepository = new Lazy<ICargoRepository>(() => 
            new CargoRepository(repositoryContext));
        }
        public ICargoRepository Cargo => _cargoRepository.Value;

        public void Save() => _repositoryContext.SaveChanges();
    }
}
