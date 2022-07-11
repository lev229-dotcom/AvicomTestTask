using Avicom.ViewModel;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avicom.ForTests
{
    public class CommandHandler
    {
        Exception ex;

        #region Client
        public bool CreateClientCommand(string name, string status, int manager_id)
        {
            using (var db = new ApplicationContext())
            {
                try
                {
                    Client client = new Client { Name = name, Status = status, Manager_ID = manager_id };

                    db.Client.Add(client);
                    db.SaveChanges();

                }
                catch (Exception e)
                {
                    ex = e;
                }

                if (ex == null)
                    return true;
                else
                    return false;

            }
        }

        public bool UpdateClientCommand(string name, string status, int manager_id)
        {
            using (var db = new ApplicationContext())
            {
                try
                {
                    Client client = db.Client.ToArray().Last();

                    client.Name = name;
                    client.Status = status;
                    client.Manager_ID = manager_id;

                    db.Client.Update(client);
                    db.SaveChanges();


                }
                catch (Exception e)
                {
                    ex = e;
                }

                if (ex == null)
                    return true;
                else
                    return false;
            }

        }

        public bool DeleteClientCommand()
        {
            using (var db = new ApplicationContext())
            {
                try
                {
                    Client client = db.Client.ToArray().Last();



                    db.Client.Remove(client);
                    db.SaveChanges();


                }
                catch (Exception e)
                {
                    ex = e;
                }

                if (ex == null)
                    return true;
                else
                    return false;
            }

        }
        #endregion

        #region Manager
        public bool CreateManagerCommand(string name)
        {
            using (var db = new ApplicationContext())
            {
                try
                {
                    Manager manager = new Manager { Name = name };

                    db.Manager.Add(manager);
                    db.SaveChanges();


                }
                catch (Exception e)
                {
                    ex = e;
                }

                if (ex == null)
                    return true;
                else
                    return false;

            }
        }

        public bool UpdateManagerCommand(string name)
        {
            using (var db = new ApplicationContext())
            {
                try
                {
                    Manager manager = db.Manager.ToArray().Last();

                    manager.Name = name;


                    db.Manager.Update(manager);
                    db.SaveChanges();


                }
                catch (Exception e)
                {
                    ex = e;
                }

                if (ex == null)
                    return true;
                else
                    return false;
            }

        }

        public bool DeleteManagerCommand()
        {
            using (var db = new ApplicationContext())
            {
                try
                {
                    Manager manager = db.Manager.ToArray().Last();



                    db.Manager.Remove(manager);
                    db.SaveChanges();


                }
                catch (Exception e)
                {
                    ex = e;
                }

                if (ex == null)
                    return true;
                else
                    return false;
            }

        }
        #endregion

        #region Product

        public bool CreateProductCommand(string name, decimal price, string type, string subperiod)
        {
            using (var db = new ApplicationContext())
            {
                try
                {
                    Product product = new Product { Name = name, Price = price, Type = type, SubPeriod = subperiod };

                    db.Product.Add(product);
                    db.SaveChanges();


                }
                catch (Exception e)
                {
                    ex = e;
                }

                if (ex == null)
                    return true;
                else
                    return false;

            }
        }

        public bool UpdateProductCommand(string name, decimal price, string type, string subperiod)
        {
            using (var db = new ApplicationContext())
            {
                try
                {
                    Product product = db.Product.ToArray().Last();

                    product.Name = name;
                    product.Price = price;
                    product.Type = type;
                    product.SubPeriod = subperiod;

                    db.Product.Update(product);
                    db.SaveChanges();


                }
                catch (Exception e)
                {
                    ex = e;
                }

                if (ex == null)
                    return true;
                else
                    return false;
            }

        }

        public bool DeleteProductCommand()
        {
            using (var db = new ApplicationContext())
            {
                try
                {
                    Product product = db.Product.ToArray().Last();



                    db.Product.Remove(product);
                    db.SaveChanges();


                }
                catch (Exception e)
                {
                    ex = e;
                }

                if (ex == null)
                    return true;
                else
                    return false;
            }

        }
        #endregion
    }
}
