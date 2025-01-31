using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data;

public class PhoneBookContext : DbContext
{
    private readonly string _connectionString;
    public DbSet<Contact> Contacts { get; set; }
    
    public PhoneBookContext()
    {
        _connectionString = ConfigurationManager.AppSettings.Get("ConnectionString") ??
            throw new Exception("Key value pair doesn't exist in the config-file!");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
}
