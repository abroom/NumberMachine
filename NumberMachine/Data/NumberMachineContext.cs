using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NumberMachine.Models;

namespace NumberMachine.Models
{
    public class NumberMachineContext : DbContext
    {
        public NumberMachineContext (DbContextOptions<NumberMachineContext> options)
            : base(options)
        {
        }

        public DbSet<NumberMachine.Models.NumberInput> NumberInput { get; set; }

        public DbSet<NumberMachine.Models.NumberOutput> NumberOutput { get; set; }
    }
}
