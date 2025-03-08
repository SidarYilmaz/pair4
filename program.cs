using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerManagementConsoleApp
{
    // Base Customer Class
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    // Individual Customer Class (Bireysel Müşteri)
    public class IndividualCustomer : Customer
    {
        public string NationalId { get; set; } // TC Kimlik Numarası
    }

    // Corporate Customer Class (Kurumsal Müşteri)
    public class CorporateCustomer : Customer
    {
        public string TaxNumber { get; set; } // Vergi Numarası
    }

    // Individual Customer Manager
    public class IndividualCustomerManager
    {
        private List<IndividualCustomer> individualCustomers = new List<IndividualCustomer>();

        public void Add(IndividualCustomer customer)
        {
            individualCustomers.Add(customer);
            Console.WriteLine($"Bireysel müşteri eklendi: {customer.Name}");
        }

        public List<IndividualCustomer> GetList()
        {
            return individualCustomers;
        }

        public IndividualCustomer GetById(int id)
        {
            return individualCustomers.FirstOrDefault(c => c.Id == id);
        }

        public void Delete(int id)
        {
            var customer = individualCustomers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                individualCustomers.Remove(customer);
                Console.WriteLine($"Bireysel müşteri silindi: {customer.Name}");
            }
        }
    }

    // Corporate Customer Manager
    public class CorporateCustomerManager
    {
        private List<CorporateCustomer> corporateCustomers = new List<CorporateCustomer>();

        public void Add(CorporateCustomer customer)
        {
            corporateCustomers.Add(customer);
            Console.WriteLine($"Kurumsal müşteri eklendi: {customer.Name}");
        }

        public List<CorporateCustomer> GetList()
        {
            return corporateCustomers;
        }

        public CorporateCustomer GetById(int id)
        {
            return corporateCustomers.FirstOrDefault(c => c.Id == id);
        }

        public void Delete(int id)
        {
            var customer = corporateCustomers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                corporateCustomers.Remove(customer);
                Console.WriteLine($"Kurumsal müşteri silindi: {customer.Name}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            IndividualCustomerManager individualManager = new IndividualCustomerManager();
            CorporateCustomerManager corporateManager = new CorporateCustomerManager();

            while (true)
            {
                Console.WriteLine("\n--- Müşteri Yönetim Sistemi ---");
                Console.WriteLine("1- Bireysel Müşteri Ekle");
                Console.WriteLine("2- Kurumsal Müşteri Ekle");
                Console.WriteLine("3- Bireysel Müşterileri Listele");
                Console.WriteLine("4- Kurumsal Müşterileri Listele");
                Console.WriteLine("5- ID'ye Göre Bireysel Müşteri Bul");
                Console.WriteLine("6- ID'ye Göre Kurumsal Müşteri Bul");
                Console.WriteLine("7- ID'ye Göre Bireysel Müşteri Sil");
                Console.WriteLine("8- ID'ye Göre Kurumsal Müşteri Sil");
                Console.WriteLine("0- Çıkış");
                Console.Write("Seçiminizi yapın: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Müşteri Adı: ");
                        string indName = Console.ReadLine();
                        Console.Write("TC Kimlik No: ");
                        string tc = Console.ReadLine();

                        IndividualCustomer indCustomer = new IndividualCustomer
                        {
                            Id = new Random().Next(1000, 9999),
                            Name = indName,
                            NationalId = tc
                        };
                        individualManager.Add(indCustomer);
                        break;

                    case "2":
                        Console.Write("Şirket Adı: ");
                        string corpName = Console.ReadLine();
                        Console.Write("Vergi Numarası: ");
                        string taxNo = Console.ReadLine();

                        CorporateCustomer corpCustomer = new CorporateCustomer
                        {
                            Id = new Random().Next(1000, 9999),
                            Name = corpName,
                            TaxNumber = taxNo
                        };
                        corporateManager.Add(corpCustomer);
                        break;

                    case "3":
                        Console.WriteLine("\n--- Bireysel Müşteriler ---");
                        foreach (var c in individualManager.GetList())
                            Console.WriteLine($"ID: {c.Id}, Ad: {c.Name}, TC: {c.NationalId}");
                        break;

                    case "4":
                        Console.WriteLine("\n--- Kurumsal Müşteriler ---");
                        foreach (var c in corporateManager.GetList())
                            Console.WriteLine($"ID: {c.Id}, Şirket Adı: {c.Name}, Vergi No: {c.TaxNumber}");
                        break;

                    case "5":
                        Console.Write("Bireysel Müşteri ID: ");
                        int searchIndId = Convert.ToInt32(Console.ReadLine());
                        var foundIndCustomer = individualManager.GetById(searchIndId);
                        if (foundIndCustomer != null)
                            Console.WriteLine($"Bulunan Müşteri: {foundIndCustomer.Name}, TC: {foundIndCustomer.NationalId}");
                        else
                            Console.WriteLine("Müşteri bulunamadı.");
                        break;

                    case "6":
                        Console.Write("Kurumsal Müşteri ID: ");
                        int searchCorpId = Convert.ToInt32(Console.ReadLine());
                        var foundCorpCustomer = corporateManager.GetById(searchCorpId);
                        if (foundCorpCustomer != null)
                            Console.WriteLine($"Bulunan Şirket: {foundCorpCustomer.Name}, Vergi No: {foundCorpCustomer.TaxNumber}");
                        else
                            Console.WriteLine("Müşteri bulunamadı.");
                        break;

                    case "7":
                        Console.Write("Silinecek Bireysel Müşteri ID: ");
                        int delIndId = Convert.ToInt32(Console.ReadLine());
                        individualManager.Delete(delIndId);
                        break;

                    case "8":
                        Console.Write("Silinecek Kurumsal Müşteri ID: ");
                        int delCorpId = Convert.ToInt32(Console.ReadLine());
                        corporateManager.Delete(delCorpId);
                        break;

                    case "0":
                        Console.WriteLine("Programdan çıkılıyor...");
                        return;

                    default:
                        Console.WriteLine("Geçersiz seçim! Lütfen tekrar deneyin.");
                        break;
                }
            }
        }
    }
}
