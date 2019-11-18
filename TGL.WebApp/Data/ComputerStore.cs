﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TGL.WebApp.Models;

namespace TGL.WebApp.Data
{
    public class ComputerStore
    {
        //private List<Computer> Computers { get; set; } = new List<Computer>();
        public TGLContext Context { get; set; }
        public ComputerStore(TGLContext context)
        {
            Context = context;
        }

        internal void EditComputer(Computer computer)
        {
            Computer currentComputer = GetComputerById(computer.Id);
            currentComputer.Model = computer.Model;
            currentComputer.Brand = computer.Brand;
            currentComputer.Cpu = computer.Cpu;
            currentComputer.StudentId = computer.StudentId;

            Context.Computer.Update(currentComputer);
            Context.SaveChanges();
        }

        internal Computer GetComputerById(Guid id)
        {
            return Context.Computer.FirstOrDefault(x => x.Id == id);
        }

        internal void AddComputer(Computer computer)
        {
            Context.Computer.Add(computer);
            Context.SaveChanges();
        }

        internal void DeleteComputer(Guid id)
        {
            var computer = Context.Computer.FirstOrDefault(x => x.Id == id);
            Context.Computer.Remove(computer);
            Context.SaveChanges();
        }

        public List<Computer> GetComputers() {
            return Context.Computer.ToList();
        }
    }
}
