using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomersList.Module.BusinessObjects;

namespace CustomersList.Module.DatabaseUpdate
{
    public class InitialData
    {
        public static List<Customer> GetCustomers(City city1, City city2, City city3)
        {
            List<Customer> customers = new List<Customer>
                {
                    new Customer()
                        {
                            FirstName = "Иван",
                            LastName = "Иванов",
                            MiddleName = "Иванович",
                            Birthday = new DateTime(1961, 04, 12),
                            Phone = "+74951234567",
                            Email = "ivanov@mail.com",
                            Addresses = new List<Address>
                                {
                                    new Address
                                        {
                                            City = city1,
                                            Street = "Проспект Мира",
                                            House = "12",
                                            Building = "38",
                                            Type = AdddressType.Home
                                        },
                                    new Address
                                        {
                                            City = city1,
                                            Street = "Доброслободская",
                                            House = "19",
                                            Type = AdddressType.Working
                                        },
                                    new Address
                                        {
                                            City = city1,
                                            Street = "Казакова",
                                            House = "3",
                                            Building = "18",
                                            Type = AdddressType.Registration
                                        }
                                }
                        },
                    new Customer()
                        {
                            FirstName = "Петр",
                            LastName = "Петров",
                            MiddleName = "Петрович",
                            Birthday = new DateTime(1980, 01, 01),
                            Phone = "+79034030487",
                            Email = "petrov@mail.com",
                            Addresses = new List<Address>
                                {
                                    new Address
                                        {
                                            City = city2,
                                            Street = "Красная",
                                            House = "5",
                                            Type = AdddressType.Home
                                        },
                                    new Address
                                        {
                                            City = city3,
                                            Street = "Вятская",
                                            House = "44A",
                                            Building = "3",
                                            Type = AdddressType.Working
                                        },
                                    new Address
                                        {
                                            City = city2,
                                            Street = "Российская",
                                            House = "39",
                                            Building = "66",
                                            Type = AdddressType.Registration
                                        }
                                }
                        }
                };

            return customers;
        }

        public static List<City> GetCities()
        {
            return new List<City>
                {
                    new City {Name = "Москва"},
                    new City {Name = "Санкт-Петербург"},
                    new City {Name = "Екатеринбург"},
                    new City {Name = "Нижний Новгород"},
                    new City {Name = "Казань"},
                    new City {Name = "Самара"},
                    new City {Name = "Омск"},
                    new City {Name = "Челябинск"},
                    new City {Name = "Ростов-на-Дону"},
                    new City {Name = "Уфа"},
                    new City {Name = "Волгоград"},
                    new City {Name = "Пермь"},
                    new City {Name = "Красноярск"},
                    new City {Name = "Воронеж"},
                    new City {Name = "Саратов"},
                    new City {Name = "Краснодар"},
                    new City {Name = "Владивосток"},
                    new City {Name = "Хабаровск"}
                };
        }
    }
}
