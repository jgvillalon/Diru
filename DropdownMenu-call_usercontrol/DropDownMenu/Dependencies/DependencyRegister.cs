using ApplicationService.Informes.IService;
using ApplicationService.Informes.Service;
using ApplicationService.InversionLotes.IService;
using ApplicationService.InversionLotes.Service;
using ApplicationService.Inversions.IService;
using ApplicationService.Inversions.Service;
using ApplicationService.IServices;
using ApplicationService.Nomencladores.Generales.IService;
using ApplicationService.Nomencladores.Generales.Service;
using ApplicationService.Nomencladores.Geograficos.IService;
using ApplicationService.Nomencladores.Geograficos.Service;
using ApplicationService.Nomencladores.Otros.IService;
using ApplicationService.Nomencladores.Otros.Service;
using ApplicationService.Proyectos.IService;
using ApplicationService.Proyectos.Service;
using ApplicationService.RegulacionesUrbanas.IService;
using ApplicationService.RegulacionesUrbanas.Service;
using ApplicationService.Seguridad.IServices;
using ApplicationService.Seguridad.Service;
using ApplicationService.Service;
using DropDownMenu;
using NHibernate;
using Repository.InversionesLotes.IRepository;
using Repository.InversionesLotes.Repository;
using Repository.Inversions.IRepository;
using Repository.Inversions.Repository;
using Repository.IRepository;
using Repository.Nomencladores.Generales.IRepository;
using Repository.Nomencladores.Generales.Repository;
using Repository.Nomencladores.Geograficos.IRepository;
using Repository.Nomencladores.Geograficos.Repository;
using Repository.Nomencladores.Otros.IRepository;
using Repository.Nomencladores.Otros.Repository;
using Repository.Proyectos.IRepository;
using Repository.Proyectos.Repository;
using Repository.RegulacionesUrbanas.IRepository;
using Repository.RegulacionesUrbanas.Repository;
using Repository.Repository;
using Repository.Seguridad.IRepository;
using Repository.Seguridad.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIRU.Dependencies
{
   public class DependencyRegister
    {
        public static ISession _session;
        public static IUserRepository _userRepo;
        public static IUserService _userService;
        public static ILicenseRepository _licenseRepo;
        public static ILicenseService _licenseService;

        #region Nomencladores
       
        #region Generales
        public static IEntidadRepository _entidadRepo;
        public static IEntidadService _entidadService;
        public static IOrganismoRepository _organismoRepo;
        public static IOrganismoService _organismoService;
        public static IProvinciaRepository _provinciaRepo;
        public static IProvinciaService _provinciaService;
        public static IMunicipioRepository _municipioRepo;
        public static IMunicipioService _municipioService;
        public static IPaisRepository _paisRepo;
        public static IPaisService _paisService;
        public static IClienteRepository _clienteRepo;
        public static IClienteService _clienteService;
        public static ILocalRepository _localRepo;
        public static ILocalService _localService;
        #endregion

        #region Geograficos
        public static IUbicacionGeograficaRepository _ubicacionGeograficaRepo;
        public static IUbicacionGeograficaService _ubicacionGeograficaService;
        public static IZonaUbicacionRepository _zonaUbicacionRepo;
        public static IZonaUbicacionService _zonaUbicacionService;
        #endregion

        #region Otros
        public static IMetrosRepository _metrosRepo;
        public static IMetrosService _metrosService;
        public static IPlantaRepository _plantaRepo;
        public static IPlantaService _plantaService;
        public static IEstadoTecnicoRepository _estadoTecnicoRepo;
        public static IEstadoTecnicoService _estadoTecnicoService; 
        public static IAccionPrecioRepository _accionPrecioRepo;
        public static IAccionPrecioService _accionPrecioService;
        public static IRedRepository _redRepo;
        public static IRedService _redService;
        #endregion
        #endregion

        #region Proyectos
        public static IProyectoRepository _proyectoRepo;
        public static IProyectoService _proyectoService;
        public static IInversionRepository _inversionRepo;
        public static IInversionService _inversionService;
        public static ICapacidadRepository _capacidadRepo;
        public static ICapacidadService _capacidadService;
        #endregion

        #region InversionLotes
        public static ILocalPlantaRepository _localPlantaRepo;
        public static ILocalPlantaService _localPlantaService;
        #endregion

        #region RegulacionesUrbanas
        public static IEstructuraRepository _EstructuraRepo;
        public static IEstructuraService _EstructuraService;
        public static IAlturaRURepository _AlturaRURepo;
        public static IAlturaRUService _AlturaRUService;
        #endregion

        #region Informes
        public static IInformeService _informeService;
        #endregion

        public static void Inject(ISession session)
        {
            _session = session;
            #region Security
            _userRepo = new UserRepository(session);
            _userService = new UserService(_userRepo);
            _licenseRepo = new LicenseRepository(session);
            _licenseService = new LicenseService(_licenseRepo);
            #endregion

            #region Nomencladores Generales
            _entidadRepo = new EntidadRepository(session);
            _entidadService = new EntidadService(_entidadRepo);
            _organismoRepo = new OrganismoRepository(session);
            _organismoService = new OrganismoService(_organismoRepo);
            _provinciaRepo = new ProvinciaRepository(session);
            _provinciaService = new ProvinciaService(_provinciaRepo);
            _municipioRepo = new MunicipioRepository(session);
            _municipioService = new MunicipioService(_municipioRepo);
            _paisRepo = new PaisRepository(session);
            _paisService = new PaisService(_paisRepo);
            _clienteRepo = new ClienteRepository(session);
            _clienteService = new ClienteService(_clienteRepo);
            _localRepo = new LocalRepository(session);
            _localService = new LocalService(_localRepo);
            #endregion

            #region Nomencladores Geograficos
            _ubicacionGeograficaRepo = new UbicacionGeograficaRepository(session);
            _ubicacionGeograficaService = new UbicacionGeograficaService(_ubicacionGeograficaRepo);
            _zonaUbicacionRepo = new ZonaUbicacionRepository(session);
            _zonaUbicacionService = new ZonaUbicacionService(_zonaUbicacionRepo);
            #endregion

            #region Nomencladores Otros
            _metrosRepo = new MetrosRepository(session);
            _metrosService = new MetrosService(_metrosRepo);
            _plantaRepo = new PlantaRepository(session);
            _plantaService = new PlantaService(_plantaRepo);
            _estadoTecnicoRepo = new EstadoTecnicoRepository(session);
            //_estadoTecnicoService = new EstadoTecnicoService(_estadoTecnicoRepo); 
            _accionPrecioRepo = new AccionPrecioRepository(session);
            _accionPrecioService = new AccionPrecioService(_accionPrecioRepo);
             _redRepo = new RedRepository(session);
            _redService = new RedService(_redRepo);
            #endregion

            #region  Proyectos
            _proyectoRepo = new ProyectoRepository(session);
            _proyectoService = new ProyectoService(_proyectoRepo);
            _inversionRepo = new InversionRepository(session);
            _inversionService = new InversionService(_inversionRepo);
            _capacidadRepo = new CapacidadRepository(session);
            _capacidadService = new CapacidadService(_capacidadRepo);
            #endregion

            #region RegulacionesUrbanas
            _EstructuraRepo = new EstructuraRepository(session);
            _EstructuraService = new EstructuraService(_EstructuraRepo);
            _AlturaRURepo = new AlturaRURepository(session);
            _AlturaRUService = new AlturaRUService(_AlturaRURepo);
            #endregion

            #region InversionLotes
            _localPlantaRepo = new LocalPlantaRepository(session);
            _localPlantaService = new LocalPlantaService(_localPlantaRepo);
            #endregion

            #region Informes
            _informeService = new InformeService(_proyectoRepo, _capacidadRepo);
            #endregion


        }

        public static void CreateConfigFile(DatabaseConfig databaseConfigs)
        {


            var fileFormat = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
            <hibernate-configuration xmlns=""urn:nhibernate-configuration-2.2"">
              <session-factory>
                <property name=""connection.connection_string"">
                  Server = {0}; Database = {1}; User ID = {2} ; Password = ""{3}"";
                </property>
                <property name=""connection.driver_class"">NHibernate.Driver.NpgsqlDriver</property>
                <property name=""dialect"">NHibernate.Dialect.PostgreSQL82Dialect</property>
                <property name=""hbm2ddl.keywords"">auto-quote</property>
                <property name=""hbm2ddl.auto"">update</property>
                <property name=""current_session_context_class"">thread</property>

              
              </session-factory>
            </hibernate-configuration> ";
            var fileContents = string.Format(fileFormat, databaseConfigs.Server, databaseConfigs.DatabaseName, databaseConfigs.DatabaseUser, databaseConfigs.Password);


            File.WriteAllText(@"hibernate.cfg.xml", fileContents);
        }


    }

    //public class DatabaseConfig
    //{
    //    public string Server { get; set; }
    //    public string Port { get; set; }
    //    public string DatabaseUser { get; set; }
    //    public string Password { get; set; }
    //    public string DatabaseName { get; set; }

    //}
}

