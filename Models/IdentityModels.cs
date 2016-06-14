using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Http;

namespace CarFinder.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Cars> Car { get; set; }

        
        public async Task<List<string>> Years()
        {
            return await this.Database.SqlQuery<string>("Years").ToListAsync();
        }

        public async Task<List<string>> ModelYears(string model_name, string model_year)
        {
            return await this.Database.SqlQuery<string>("ModelYears @model_name, @model_year",
                new SqlParameter("model_name", model_name),
                new SqlParameter("model_year", model_year)).ToListAsync();
        }


        public async Task<List<string>> EngineCylinders()
        {
            return await this.Database.SqlQuery<string>("EngineCylinders").ToListAsync();
        }

        public async Task<List<string>> EngineSizes()
        {
            return await this.Database.SqlQuery<string>("EngineSizes").ToListAsync();
        }

        //public async Task<List<string>> HorsepowerOver300(string engine_power_ps)
        //{
        //    return await this.Database.SqlQuery<string>("HorsepowerOver300 @engine_power_ps",
        //        new SqlParameter("engine_power_ps", engine_power_ps)).ToListAsync();
        //}

        public async Task<List<string>> HorsepowerOver300()
        {
            return await this.Database.SqlQuery<string>("HorsepowerOver300").ToListAsync();
        }

        public async Task<List<string>> YearMakes(string model_year)
        {
            return await this.Database.SqlQuery<string>("YearMakes @model_year",
                new SqlParameter("model_year", model_year)).ToListAsync();
        }

        public async Task<List<string>> YearMakeModels(string model_year, string make)
        {
            return await this.Database.SqlQuery<string>("YearMakeModels @model_year, @make",
                new SqlParameter("model_year", model_year),
                new SqlParameter("make", make)).ToListAsync();
        }

        public async Task<List<string>> YearMakeModelTrims(string model_year, string make, string model_name)
        {
            return await this.Database.SqlQuery<string>("YearMakeModelTrims @model_year, @make, @model_name",
                new SqlParameter("model_year", model_year),
                new SqlParameter("make", make),
                new SqlParameter("model_name", model_name)).ToListAsync();
        }

        public async Task<List<string>> WeightUnder2000Kg(string weight_kg)
        {
            return await this.Database.SqlQuery<string>("WeightUnder2000Kg @weight_kg",
                new SqlParameter("Weight_kg", weight_kg)).ToListAsync();
        }

        public async Task<List<string>> WeightUnder2000Kg()
        {
            return await this.Database.SqlQuery<string>("WeightUnder2000Kg").ToListAsync();
        }

        //public async Task<List<string>> WeightUnder2000Kg_HorsepowerOver300(string weight_kg, string engine_horsepower_ps)
        //{
        //    return await this.Database.SqlQuery<string>("WeightUnder2000Kg_HorsepowerOver300 @weight_kg, @engine_horsepower_ps",
        //        new SqlParameter("weight_kg", weight_kg), 
        //        new SqlParameter("engine_horsepower_ps", engine_horsepower_ps)).ToListAsync();
        //}

        public async Task<List<string>> WeightUnder2000Kg_HorsepowerOver300()
        {
            return await this.Database.SqlQuery<string>("WeightUnder2000Kg_HorsepowerOver300").ToListAsync();
        }

        public async Task<List<string>> YearMakeModels(string model_year, string make, string model_name)
        {
            return await this.Database.SqlQuery<string>("YearMakeModels",
                new SqlParameter("model_year", model_year), new SqlParameter("make", make),
                new SqlParameter("model_name", model_name)).ToListAsync();
        }

        public async Task<Cars> GetCar(string model_year, string make, string model_name, string model_trim)
        {
            return await this.Database.SqlQuery<Cars>("GetCar @model_year, @make, @model_name, @model_trim",
                new SqlParameter("model_year", model_year),
                new SqlParameter("make", make),
                new SqlParameter("model_name", model_name),
                new SqlParameter("model_trim",model_trim)).FirstOrDefaultAsync();
        }

        public async Task<List<Cars>> YearMakes(string model_year, string make)
        {
            return await this.Database.SqlQuery<Cars>("YearMakes @model_year, @make",
                new SqlParameter("model_year", model_year),
                new SqlParameter("make", make)).ToListAsync();
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}