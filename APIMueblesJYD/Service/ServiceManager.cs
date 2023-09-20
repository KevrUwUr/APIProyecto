using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICargoService> _cargoService;
        private readonly Lazy<ICategoriaService> _categoriaService;
        private readonly Lazy<IContactoEmpleadoService> _contactoEmpleadoService;
        private readonly Lazy<IContactoProveedorService> _contactoProveedorService;
        private readonly Lazy<IContactoUsuarioService> _contactoUsuarioService;
        private readonly Lazy<IDetFacturaCompraService> _detFacturaCompraService;
        private readonly Lazy<IDetFacturaVentaService> _detFacturaVentaService;
        private readonly Lazy<IEmpleadoCargoService> _empleadoCargoService;
        private readonly Lazy<IEmpleadoService> _empleadoService;
        private readonly Lazy<IFacturaCompraService> _facturaCompraService;
        private readonly Lazy<IFacturaVentaService> _facturaVentaService;
        private readonly Lazy<IHistoricoPreciosService> _historicoPreciosService;
        private readonly Lazy<IMetodoPagoService> _metodoPagoService;
        private readonly Lazy<IPerdidaProductoService> _perdidaProductoService;
        private readonly Lazy<IPerdidaService> _perdidaService;
        private readonly Lazy<IProductoService> _productoService;
        private readonly Lazy<IProveedorService> _proveedorService;
        private readonly Lazy<IUsuarioService> _usuarioService;


        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger
            , IMapper mapper)
        {
            _cargoService = new Lazy<ICargoService>(() => 
            new CargoService(repositoryManager, logger, mapper));

            _categoriaService = new Lazy<ICategoriaService>(() =>
            new CategoriaService(repositoryManager, logger, mapper));

            _contactoEmpleadoService = new Lazy<IContactoEmpleadoService>(() =>
            new ContactoEmpleadoService(repositoryManager, logger, mapper));

            _contactoProveedorService = new Lazy<IContactoProveedorService>(() =>
            new ContactoProveedorService(repositoryManager, logger, mapper));

            _contactoUsuarioService = new Lazy<IContactoUsuarioService>(() =>
            new ContactoUsuarioService(repositoryManager, logger, mapper));

            _detFacturaCompraService = new Lazy<IDetFacturaCompraService>(() =>
            new DetFacturaCompraService(repositoryManager, logger, mapper));

            _detFacturaVentaService = new Lazy<IDetFacturaVentaService>(() =>
            new DetFacturaVentaService(repositoryManager, logger, mapper));

            _empleadoCargoService = new Lazy<IEmpleadoCargoService>(() =>
            new EmpleadoCargoService(repositoryManager, logger, mapper));

            _empleadoService = new Lazy<IEmpleadoService>(() =>
            new EmpleadoService(repositoryManager, logger, mapper));

            _facturaCompraService = new Lazy<IFacturaCompraService>(() =>
            new FacturaCompraService(repositoryManager, logger, mapper));

            _facturaVentaService = new Lazy<IFacturaVentaService>(() =>
            new FacturaVentaService(repositoryManager, logger, mapper));

            _historicoPreciosService = new Lazy<IHistoricoPreciosService>(() =>
            new HistoricoPreciosService(repositoryManager, logger, mapper));

            _metodoPagoService = new Lazy<IMetodoPagoService>(() =>
            new MetodoPagoService(repositoryManager, logger, mapper));

            _perdidaProductoService = new Lazy<IPerdidaProductoService>(() =>
            new PerdidaProductoService(repositoryManager, logger, mapper));

            _perdidaService = new Lazy<IPerdidaService>(() =>
            new PerdidaService(repositoryManager, logger, mapper));

            _productoService = new Lazy<IProductoService>(() =>
            new ProductoService(repositoryManager, logger, mapper));

            _proveedorService = new Lazy<IProveedorService>(() =>
            new ProveedorService(repositoryManager, logger, mapper));

            _usuarioService = new Lazy<IUsuarioService>(() =>
            new UsuarioService(repositoryManager, logger, mapper));
        }
        public ICargoService CargoService => _cargoService.Value;

        public ICategoriaService CategoriaService => _categoriaService.Value;

        public IContactoEmpleadoService ContactoEmpleadoService => _contactoEmpleadoService.Value;

        public IContactoProveedorService ContactoProveedorService => _contactoProveedorService.Value;

        public IContactoUsuarioService ContactoUsuarioService => _contactoUsuarioService.Value;

        public IDetFacturaCompraService DetFacturaCompraService => _detFacturaCompraService.Value;

        public IDetFacturaVentaService DetFacturaVentaService =>_detFacturaVentaService.Value;

        public IEmpleadoCargoService EmpleadoCargoService => _empleadoCargoService.Value;

        public IEmpleadoService EmpleadoService => _empleadoService.Value;

        public IFacturaCompraService FacturaCompraService => _facturaCompraService.Value;

        public IFacturaVentaService FacturaVentaService => _facturaVentaService.Value;

        public IHistoricoPreciosService HistoricoPreciosService => _historicoPreciosService.Value;

        public IMetodoPagoService MetodoPagoService => _metodoPagoService.Value;

        public IPerdidaProductoService PerdidaProductoService => _perdidaProductoService.Value;

        public IPerdidaService PerdidaService => _perdidaService.Value;

        public IProductoService ProductoService => _productoService.Value;

        public IProveedorService ProveedorService => _proveedorService.Value;

        public IUsuarioService UsuarioService => _usuarioService.Value;
    }
}
