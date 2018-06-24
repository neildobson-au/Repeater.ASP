using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repeater.ASP.Data;
using Repeater.ASP.Models;

namespace Repeater.ASP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<IRepository<State>, StateRepository>();
        }

        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env, 
            IApplicationLifetime lifetime,
            IRepository<State> stateRepository)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseMvc();

            lifetime.ApplicationStarted.Register(() => SeedData(stateRepository));
        }

        private void SeedData(IRepository<State> stateRepository)
        {
            var states = new List<State>
            {
                new State
                {
                    Name = "ACT",
                    IsTerritory = true
                },
                new State
                {
                    Name = "NSW",
                    Locations = new List<Location>
                    {
                        new Location {PostCode = 2000, Suburb = "Sydney"},
                        new Location
                        {
                            PostCode = 2065,
                            Suburb = "Wollstonecraft",
                            Streets = new List<Street>
                            {
                                new Street
                                {
                                    Name = "Nicholson St",
                                    Homes = new List<Home>
                                    {
                                        new Home
                                        {
                                            Number = 1,
                                            Rooms = new List<Room>
                                            {
                                                new Room {Name = "Lounge", Length = 650, Width = 450},
                                                new Room {Name = "Kitchen", Length = 280, Width = 330},
                                                new Room {Name = "Bedroom", Length = 400, Width = 250}
                                            }
                                        },
                                        new Home
                                        {
                                            Number = 2,
                                            Rooms = new List<Room>
                                            {
                                                new Room {Name = "Lounge", Length = 550, Width = 630},
                                                new Room {Name = "Kitchen", Length = 300, Width = 340},
                                                new Room {Name = "Bedroom 1", Length = 420, Width = 275},
                                                new Room {Name = "Bedroom 2", Length = 420, Width = 245}
                                            }
                                        }
                                    }
                                },
                                new Street {Name = "Belmont St"}
                            }
                        }
                    }
                },
                new State {Name = "NT", IsTerritory = true},
                new State {Name = "QLD"},
                new State {Name = "SA"},
                new State {Name = "TAS"},
                new State {Name = "VIC"},
                new State {Name = "WA"},
            };

            foreach (var state in states)
            {
                stateRepository.Insert(state);
            }
        }
    }
}
