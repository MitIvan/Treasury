using Blagajna.DataAccess;
using Blagajna.DataAccess.Implementations;
using Blagajna.Domain;
using Blagajna.Domain.Den.Bl.Models;
using Blagajna.Domain.Shared.Models;
using Blagajna.Services.Implementation;
using Blagajna.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blagajna.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DenBlDbContext>(x =>
                x.UseSqlServer(connectionString));
        }
        public static void InjectionRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<DenDocument>, DenDocumentRepo>();
            services.AddTransient<IRepository<Vraboten>, VrabotenRepo>();
            services.AddTransient<IRepository<PresmetkovnaEd>, PresmetkovnaEdRepo>();
            services.AddTransient<IRepository<DenIzvod>, DenIzvodRepo>();

        }
        public static void InjectionSrevices(IServiceCollection services)
        {
            services.AddTransient<IDenDocumentService, DenDocumentService>();
            services.AddTransient<IDenIzvodService, DenIzvodService>();
            services.AddTransient<IVraboten, VrabotenService>();
            services.AddTransient<IPresmetkovnaEd, PresmetkovnaEdService>();


        }
    }
}
