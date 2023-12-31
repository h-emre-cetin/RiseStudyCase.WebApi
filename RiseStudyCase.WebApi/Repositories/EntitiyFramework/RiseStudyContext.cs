﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RiseStudyCase.WebApi.Models;

namespace RiseStudyCase.WebApi.Repositories.EntitiyFramework
{
    public class RiseStudyContext : DbContext
    {
        public RiseStudyContext() : base()
        {

        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("");
        //    base.OnConfiguring(optionsBuilder);
        //}

        public DbSet<ContactModel> Contacts { get; set; }

        public DbSet<ContactInfoModel> ContactsInfos { get; set; }
    }
}
