using System;
using System.Collections.Generic;
using System.Linq;
using CustomersList.Module.BusinessObjects;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.EF;
using DevExpress.Persistent.BaseImpl.EF;

namespace CustomersList.Module.DatabaseUpdate {
    // For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppUpdatingModuleUpdatertopic
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion) {
        }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();

            using (var context = DbContextFactory.Create())
            {
                List<City> cities;

                if (!context.Cities.Any())
                {
                    cities = InitialData.GetCities();
                    context.Cities.AddRange(cities);
                    context.SaveChanges();
                }
                else
                {
                    cities = context.Cities.Take(3).ToList();
                }

                City city1 = cities[0];
                City city2 = cities[1];
                City city3 = cities[2];

                var customers = InitialData.GetCustomers(city1, city2, city3);
                if (!context.Customers.Any())
                {
                    context.Customers.AddRange(customers);
                    context.SaveChanges();
                }
            }
        }
        public override void UpdateDatabaseBeforeUpdateSchema() {
            base.UpdateDatabaseBeforeUpdateSchema();
        }
    }
}
