using System;
using TesterMask.Data;
using TesterMask;
using TesterMask.Data.Models;
using TesterMask.Data.Models.Enum;

namespace TesterMask
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new TesterMaskContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
