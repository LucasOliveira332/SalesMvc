﻿using SalesMvc.Models.Enums;
using SalesMvc.Data;

namespace SalesMvc.Models.Services
{

    public class SeedingService
    {

        private readonly SalesMvcContext _context;

        public SeedingService(SalesMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Departments!.Any())
            {
                return;
            }

            Department d1 = new("Human Resources");
            Department d2 = new("IT");
            Department d3 = new("Marketing");

            Seller s1 = new("Bob Brown", "bob@gmail.com", new DateTime(2004, 9 ,7).Date, 1000.0, d1);
            Seller s2 = new("Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31).Date, 3500.0, d2);
            Seller s3 = new("Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15).Date, 2200.0, d1);
            Seller s4 = new("Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30).Date, 3000.0, d3);
            Seller s5 = new("Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9).Date, 4000.0, d3);
            Seller s6 = new("Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4).Date, 3000.0, d2);

            SalesRecord r1 = new(new DateTime(2022, 09, 25), 11000.0, SaleStatus.Billed, s1);
            SalesRecord r2 = new(new DateTime(2022, 09, 4), 7000.0, SaleStatus.Billed, s5);
            SalesRecord r3 = new(new DateTime(2022, 09, 13), 4000.0, SaleStatus.Canceled, s4);
            SalesRecord r4 = new(new DateTime(2022, 09, 1), 8000.0, SaleStatus.Billed, s1);
            SalesRecord r5 = new(new DateTime(2022, 09, 21), 3000.0, SaleStatus.Billed, s3);
            SalesRecord r6 = new(new DateTime(2022, 09, 15), 2000.0, SaleStatus.Billed, s1);
            SalesRecord r7 = new(new DateTime(2022, 09, 28), 13000.0, SaleStatus.Billed, s2);
            SalesRecord r8 = new(new DateTime(2022, 09, 11), 4000.0, SaleStatus.Billed, s4);
            SalesRecord r9 = new(new DateTime(2022, 09, 14), 11000.0, SaleStatus.Pending, s6);
            SalesRecord r10 = new(new DateTime(2022, 09, 7), 9000.0, SaleStatus.Billed, s6);
            SalesRecord r11 = new(new DateTime(2022, 09, 13), 6000.0, SaleStatus.Billed, s2);
            SalesRecord r12 = new(new DateTime(2022, 09, 25), 7000.0, SaleStatus.Pending, s3);
            SalesRecord r13 = new(new DateTime(2022, 09, 29), 10000.0, SaleStatus.Billed, s4);
            SalesRecord r14 = new(new DateTime(2022, 09, 4), 3000.0, SaleStatus.Billed, s5);
            SalesRecord r15 = new(new DateTime(2022, 09, 12), 4000.0, SaleStatus.Billed, s1);
            SalesRecord r16 = new(new DateTime(2022, 10, 5), 2000.0, SaleStatus.Billed, s4);
            SalesRecord r17 = new(new DateTime(2022, 10, 1), 12000.0, SaleStatus.Billed, s1);
            SalesRecord r18 = new(new DateTime(2022, 10, 24), 6000.0, SaleStatus.Billed, s3);
            SalesRecord r19 = new(new DateTime(2022, 10, 22), 8000.0, SaleStatus.Billed, s5);
            SalesRecord r20 = new(new DateTime(2022, 10, 15), 8000.0, SaleStatus.Billed, s6);
            SalesRecord r21 = new(new DateTime(2022, 10, 17), 9000.0, SaleStatus.Billed, s2);
            SalesRecord r22 = new(new DateTime(2022, 10, 24), 4000.0, SaleStatus.Billed, s4);
            SalesRecord r23 = new(new DateTime(2022, 10, 19), 11000.0, SaleStatus.Canceled, s2);
            SalesRecord r24 = new(new DateTime(2022, 10, 12), 8000.0, SaleStatus.Billed, s5);
            SalesRecord r25 = new(new DateTime(2022, 10, 31), 7000.0, SaleStatus.Billed, s3);
            SalesRecord r26 = new(new DateTime(2022, 10, 6), 5000.0, SaleStatus.Billed, s4);
            SalesRecord r27 = new(new DateTime(2022, 10, 13), 9000.0, SaleStatus.Pending, s1);
            SalesRecord r28 = new(new DateTime(2022, 10, 7), 4000.0, SaleStatus.Billed, s3);
            SalesRecord r29 = new(new DateTime(2022, 10, 23), 12000.0, SaleStatus.Billed, s5);
            SalesRecord r30 = new(new DateTime(2022, 10, 12), 5000.0, SaleStatus.Billed, s2);

            _context.Departments!.AddRange(d1, d2, d3);

            _context.Sellers!.AddRange(s1, s2, s3, s4, s5, s6);

            _context.SalesRecords!.AddRange(
                r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r25, r26, r27, r28, r29, r30
            );

            _context.SaveChanges();

        }
    }
}
