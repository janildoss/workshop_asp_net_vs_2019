using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc_n.Models;
using SalesWebMvc_n.Models.Enums;

namespace SalesWebMvc_n.Data
{   //Serviço para inicializar tabelas de banco, faz somente qundo as tabela ainda vazias.
    public class SeedingService
    {
        private SalesWebMvc_nContext _context;

        public SeedingService(SalesWebMvc_nContext context) {
            _context = context;
        }
       //O metodo seed eh chamado dentro do startup.cs
        public void Seed()
        {//testa se as tabelas ja foram inicializadas 
        if (_context.Department.Any() ||
            _context.Seller.Any() ||
            _context.SalesRecord.Any()) 
        {
           return;//DB has been seeded
        }

        //Inicializando os departamentos
        Department d1 = new Department(1, "Computers");
        Department d2 = new Department(2, "Electronics");
        Department d3 = new Department(3, "Fashion");
        Department d4 = new Department(4, "Books");

        //Inicializando os vendedores
        Seller s1 = new Seller(1, "Bob Brown","bob@gmail.com",1000.0,   new DateTime(1988,04,21),d1);
        Seller s2 = new Seller(2, "Maria Green","maria@gmail.com",1200.0, new DateTime(1972,5,1),d2);
        Seller s3 = new Seller(3, "Alex Gray","alex@gmail.com",6000.0, new DateTime(1987,9,24),d1);
        Seller s4 = new Seller(4, "Marta red","marta@gmail.com",2000.0, new DateTime(1949,3,12),d4);
        Seller s5 = new Seller(5, "Donald trump","Donald@gmail.com",2800.0,new DateTime(1990,4,26),d3);
        Seller s6 = new Seller(6, "Alex Peixoto","alexpeixoto@gmail.com",1300.0, new DateTime(1991,8,18),d2);
        
        //Inicializando salesRecord
        SalesRecord r1 = new SalesRecord(1, new DateTime(2019,06,12),100.0, SalesStatus.Billed,s1);
        SalesRecord r2 = new SalesRecord(2, new DateTime(2019,06,12),110.0, SalesStatus.Billed,s1);
        SalesRecord r3 = new SalesRecord(3, new DateTime(2019,07,12),1100.0, SalesStatus.Billed,s1);
        SalesRecord r4 = new SalesRecord(4, new DateTime(2019,06,12),1200.0, SalesStatus.Billed,s1);
        SalesRecord r5 = new SalesRecord(5, new DateTime(2019,08,12),500.0, SalesStatus.Billed,s1);
        SalesRecord r6 = new SalesRecord(6, new DateTime(2019,10,12),1150.0, SalesStatus.Billed,s1);
        SalesRecord r7 = new SalesRecord(7, new DateTime(2019,11,12),100.0, SalesStatus.Billed,s1);
        SalesRecord r8 = new SalesRecord(8, new DateTime(2019,06,12),780.0, SalesStatus.Billed,s1);
        SalesRecord r9 = new SalesRecord(9, new DateTime(2019,06,12),600.0, SalesStatus.Billed,s2);
        SalesRecord r10 = new SalesRecord(10, new DateTime(2019,06,12),1000.0, SalesStatus.Billed,s2);
        SalesRecord r11 = new SalesRecord(11, new DateTime(2019,06,13),1000.0, SalesStatus.Pending,s2);
        SalesRecord r12 = new SalesRecord(12, new DateTime(2019,06,14),1000.0, SalesStatus.Billed,s2);
        SalesRecord r13 = new SalesRecord(13, new DateTime(2019,06,15),580.0, SalesStatus.Billed,s2);
        SalesRecord r14 = new SalesRecord(14, new DateTime(2019,06,16),900.0, SalesStatus.Billed,s2);
        SalesRecord r15 = new SalesRecord(15, new DateTime(2019,06,17),2100.0, SalesStatus.Billed,s2);
        SalesRecord r16= new SalesRecord(16, new DateTime(2019,06,18),1180.0,  SalesStatus.Billed,s2);
        SalesRecord r17 = new SalesRecord(17, new DateTime(2019,06,05),1160.0, SalesStatus.Billed,s3);
        SalesRecord r18 = new SalesRecord(18, new DateTime(2019,06,06),7000.0, SalesStatus.Billed,s3);
        SalesRecord r19 = new SalesRecord(19, new DateTime(2019,06,07),1180.0, SalesStatus.Billed,s4);
        SalesRecord r20 = new SalesRecord(20, new DateTime(2019,06,08),100.0, SalesStatus.Billed,s4);
        SalesRecord r21 = new SalesRecord(21, new DateTime(2019,06,09),100.0, SalesStatus.Billed,s4);
        SalesRecord r22 = new SalesRecord(22, new DateTime(2019,06,10),100.0, SalesStatus.Pending,s4);        
        SalesRecord r23 = new SalesRecord(23, new DateTime(2019,06,11),200.0, SalesStatus.Billed,s5);
        SalesRecord r24 = new SalesRecord(24, new DateTime(2019,08,12),11000.0, SalesStatus.Billed,s5);
        SalesRecord r25 = new SalesRecord(25, new DateTime(2019,08,12),11000.0, SalesStatus.Billed,s5);
        SalesRecord r26 = new SalesRecord(26, new DateTime(2019,08,12),11000.0, SalesStatus.Billed,s5);
        SalesRecord r27 = new SalesRecord(27, new DateTime(2019,09,12),11000.0, SalesStatus.Billed,s5);
        SalesRecord r28 = new SalesRecord(28, new DateTime(2019,09,12),1000.0, SalesStatus.Pending,s6);
        SalesRecord r29 = new SalesRecord(29, new DateTime(2019,07,13),1000.0, SalesStatus.Pending,s6);
        SalesRecord r30 = new SalesRecord(30, new DateTime(2019,07,13),1000.0, SalesStatus.Pending,s6);
        //Salvando no banco de dados
        _context.Department.AddRange(d1, d2, d3, d4);
        _context.Seller.AddRange(s1,s2,s3,s4);
        _context.SalesRecord.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                                     r11, r12, r13, r14, r15, r16, r17, r18, r19, r20, 
                                     r21, r22, r23, r24, r25, r26, r27, r28, r29, r30);    
        _context.SaveChanges();

        }

    }
}
